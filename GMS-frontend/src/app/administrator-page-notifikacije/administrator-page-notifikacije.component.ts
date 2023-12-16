import { Component, OnInit } from '@angular/core';
import {
  Korisnik_SuplementGetAllEndpoint,
  Korisnik_SuplementGetAllResponse,
  Korisnik_SuplementGetAllResponseKorisnik_Suplement,
} from "../endpoints/korisnik-endpoints/korisnik-suplementi-endpoints/korisnik-suplement-getall-endpoint";

@Component({
  selector: 'app-administrator-page-notifikacije',
  templateUrl: './administrator-page-notifikacije.component.html',
  styleUrls: ['./administrator-page-notifikacije.component.css']
})
export class AdministratorPageNotifikacijeComponent implements OnInit {
  constructor(private Korisnik_SuplementGetAllEndpoint: Korisnik_SuplementGetAllEndpoint) {}

  korisnikSuplementi: Korisnik_SuplementGetAllResponseKorisnik_Suplement[] = [];
  PretragaNaziv: string = "";

  ngOnInit(): void {
    this.Korisnik_SuplementGetAllEndpoint.Handle().subscribe((x: Korisnik_SuplementGetAllResponse) => {
      this.korisnikSuplementi = x.korisnikSuplement;
    });
  }

  GetFiltiranaKupovina() {
    return this.korisnikSuplementi.filter(
      (x) => x.imePrezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) ||
        x.nazivSuplementa.toLowerCase().includes(this.PretragaNaziv.toLowerCase())
    );
  }

  Odaberi(x: Korisnik_SuplementGetAllResponseKorisnik_Suplement) {
    x.isporuceno = true;
  }
}
