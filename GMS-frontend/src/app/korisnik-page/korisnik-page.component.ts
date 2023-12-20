import {Component, OnInit} from '@angular/core';
import {MyAuthService} from "../services/MyAuthService";
import {KorisnikGetByIdEndpoint, KorisnikGetByIdResponse} from "../endpoints/korisnik-endpoints/korisnik-get-endpoint";
import {
  Korisnik_ClanarinaGetAllEndpoint, Korisnik_ClanarinaGetAllResponse, Korisnik_ClanarinaGetAllResponseKorisnikClanarina
} from "../endpoints/korisnik-endpoints/korisnik-clanarina-endpoints/korisnik-clanarina-getall-endpoint";
import {
  SeminarGetAllResponse,
  SeminarGetAllResponseSeminari
} from "../endpoints/seminari-endpoints/seminari-getall-endpoint";
import {
  Korisnik_SuplementGetAllEndpoint, Korisnik_SuplementGetAllResponse,
  Korisnik_SuplementGetAllResponseKorisnik_Suplement
} from "../endpoints/korisnik-endpoints/korisnik-suplementi-endpoints/korisnik-suplement-getall-endpoint";


@Component({
  selector: 'app-korisnik-page',
  templateUrl: './korisnik-page.component.html',
  styleUrls: ['./korisnik-page.component.css']
})
export class KorisnikPageComponent implements OnInit{

  constructor(private myAuthService: MyAuthService,
              private KorisnikGetByIdEndpoint:KorisnikGetByIdEndpoint,
              private Korisnik_ClanarinaGetAllEndpoint:Korisnik_ClanarinaGetAllEndpoint,
              private Korisnik_SuplementGetAllEndpoint:Korisnik_SuplementGetAllEndpoint) {
  }

  korisnik_clanarine: Korisnik_ClanarinaGetAllResponseKorisnikClanarina[] = [];
  korisnikSuplement: Korisnik_SuplementGetAllResponseKorisnik_Suplement[] = [];


  public odabraniKorisnik : KorisnikGetByIdResponse | null = null;
  id:number = 0
  ngOnInit() {
    this.id = this.myAuthService.returnId()!;


    this.KorisnikGetByIdEndpoint.Handle(this.id).subscribe({
        next: x => {
          this.odabraniKorisnik = x;
        }
      }
    )

    this.Korisnik_ClanarinaGetAllEndpoint.Handle().subscribe((x:Korisnik_ClanarinaGetAllResponse )=>{
      this.korisnik_clanarine = x.korisnik_Clanarina;
    })

    this.Korisnik_SuplementGetAllEndpoint.Handle().subscribe((x:Korisnik_SuplementGetAllResponse )=>{
      this.korisnikSuplement = x.korisnikSuplement;
    })
  }


  GetFiltiraneClanarine() {
    return this.korisnik_clanarine.filter(x=> x.korisnikID == this.id );
  }

  GetFiltiraneSuplemente() {
    return this.korisnikSuplement.filter(x=> x.korisnikID == this.id );
  }

}
