import {Component, OnInit} from '@angular/core';
import {
  Korisnik_SuplementGetAllEndpoint, Korisnik_SuplementGetAllResponse, Korisnik_SuplementGetAllResponseKorisnik_Suplement
} from "../endpoints/korisnik-endpoints/korisnik-suplementi-endpoints/korisnik-suplement-getall-endpoint";
import {
  Korisnik_SuplementEditEndpoint, Korisnik_SuplementEditRequest
} from "../endpoints/korisnik-endpoints/korisnik-suplementi-endpoints/korisnik-suplement-edit-endpoint";


@Component({
  selector: 'app-administrator-page-notifikacije',
  templateUrl: './administrator-page-notifikacije.component.html',
  styleUrls: ['./administrator-page-notifikacije.component.css']
})
export class AdministratorPageNotifikacijeComponent implements OnInit{


  constructor(private Korisnik_SuplementGetAllEndpoint:Korisnik_SuplementGetAllEndpoint,
              private  Korisnik_SuplementEditEndpoint:Korisnik_SuplementEditEndpoint) {}


  public odabranaNotifikacija: Korisnik_SuplementEditRequest | null = null;

  korisnikSuplementi: Korisnik_SuplementGetAllResponseKorisnik_Suplement[] = [];
  PretragaNaziv: string = "";


  ngOnInit():void {

    this.fetchSuplementi();
  }

  GetFiltiranaKupovina() {
    return this.korisnikSuplementi.filter(x=> x.imePrezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.nazivSuplementa.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Odaberi(x: Korisnik_SuplementGetAllResponseKorisnik_Suplement) {

    this.odabranaNotifikacija = {
      isporuceno: !x.isporuceno,
      datumVrijemeNarudzbe: x.datumVrijemeNarudzbe,
      korisnikID: x.korisnikID,
      suplementID: x.suplementID,
      kolicina: x.kolicina
    } ;

    this.Korisnik_SuplementEditEndpoint.Handle(this.odabranaNotifikacija!).subscribe((x)=>{
      this.ngOnInit();
      this.odabranaNotifikacija = null
    })


  }

  private fetchSuplementi() {
    this.Korisnik_SuplementGetAllEndpoint.Handle().subscribe((x:Korisnik_SuplementGetAllResponse )=>{
      this.korisnikSuplementi = x.korisnikSuplement;
    });
  }
}
