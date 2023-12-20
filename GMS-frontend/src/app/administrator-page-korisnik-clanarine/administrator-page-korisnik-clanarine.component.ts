import {Component, OnInit} from '@angular/core';
import {
  KorisnikGetAllEndpoint, KorisnikGetAllResponse,
  KorisnikGetAllResponseKorisnik
} from "../endpoints/korisnik-endpoints/korisnici-getall-endpoint";
import {
  KorisnikClanarinaGetEndpoint,
  KorisnikClanarinaGetResponse
} from "../endpoints/korisnik-endpoints/korisnik-clanarina-endpoints/korisnik-clanarina-get-endpoint";
import {
  Korisnik_ClanarinaAddEndpoint, Korisnik_ClanarinaAddRequest
} from "../endpoints/korisnik-endpoints/korisnik-clanarina-endpoints/korisnik-clanarina-add-endpoint";
import {
  ClanarinaGetAllResponse, ClanarinaGetAllResponseClanarina,
  ClanarineGetallEndpoint
} from "../endpoints/clanarine-endpoints/clanarine-getall-endpoint";


@Component({
  selector: 'app-administrator-page-korisnik-clanarine',
  templateUrl: './administrator-page-korisnik-clanarine.component.html',
  styleUrls: ['./administrator-page-korisnik-clanarine.component.css']
})
export class AdministratorPageKorisnikClanarineComponent implements OnInit{

  constructor(private KorisnikGetAllEndpoint:KorisnikGetAllEndpoint,
              private KorisnikClanarinaGetEndpoint:KorisnikClanarinaGetEndpoint,
              private Korisnik_ClanarinaAddEndpoint:Korisnik_ClanarinaAddEndpoint,
              private ClanarineGetallEndpoint:ClanarineGetallEndpoint) {

  }

  public odabraniKorisnikClanarine : KorisnikClanarinaGetResponse | null = null;
  korisnici: KorisnikGetAllResponseKorisnik[] = [];
  clanarine: ClanarinaGetAllResponseClanarina[] = [];
  PretragaNaziv: string = "";

  public prikaziAdd:boolean = false;
  public prikaziPregled:boolean = false;

  public novaKorisnikClanarina:Korisnik_ClanarinaAddRequest = {
    korisnikID: 0,
    clanarinaID: 1,
    datumUplate: "2024-01-01T17:16:40",
    datumIsteka: "2024-02-01T17:16:40"
  };
  ngOnInit():void {

    this.KorisnikGetAllEndpoint.Handle().subscribe((x:KorisnikGetAllResponse )=>{
      this.korisnici = x.korisnici;
    });

    this.ClanarineGetallEndpoint.Handle().subscribe((x:ClanarinaGetAllResponse )=>{
      this.clanarine = x.clanarine;
    });

  }
  GetFiltiriraneKorisnike() {
    return this.korisnici.filter(x=> x.ime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) ||  x.prezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) ||  x.username.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Odaberi(id: number) {
    this.KorisnikClanarinaGetEndpoint.Handle(id).subscribe({
        next: x => {
          this.odabraniKorisnikClanarine = x;
        }
      }
    )
    this.prikaziPregled = !this.prikaziPregled;
    this.prikaziAdd = false;
  }

  Close() {
    this.odabraniKorisnikClanarine = null
    this.prikaziPregled = false;
    this.ngOnInit();
  }

  OdaberizaNovi(id: number) {
    this.prikaziAdd = !this.prikaziAdd;
    this.prikaziPregled = false;
    this.novaKorisnikClanarina.korisnikID = id;
  }

  SaveNew() {
    this.Korisnik_ClanarinaAddEndpoint.Handle(this.novaKorisnikClanarina).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;

    })


  }
}
