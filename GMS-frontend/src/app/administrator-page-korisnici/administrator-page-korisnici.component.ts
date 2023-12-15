import {Component, OnInit} from '@angular/core';
import {
  KorisnikGetAllEndpoint, KorisnikGetAllResponse,
  KorisnikGetAllResponseKorisnik
} from "../endpoints/korisnik-endpoints/korisnici-getall-endpoint";

@Component({
  selector: 'app-administrator-page-korisnici',
  templateUrl: './administrator-page-korisnici.component.html',
  styleUrls: ['./administrator-page-korisnici.component.css']
})
export class AdministratorPageKorisniciComponent implements OnInit{

  constructor(private KorisnikGetAllEndpoint:KorisnikGetAllEndpoint) {
  }

  korisnici: KorisnikGetAllResponseKorisnik[] = [];
  PretragaNaziv: string = "";


  public prikaziAdd:boolean = false;



  ngOnInit() {
    this.KorisnikGetAllEndpoint.Handle().subscribe((x:KorisnikGetAllResponse )=>{
      this.korisnici = x.korisnici;
    })
  }

  Odaberi(x: KorisnikGetAllResponseKorisnik) {

  }

  GetFiltiraniKorisnici() {
    return this.korisnici.filter(x=> x.ime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.prezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.username.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) );
  }
}
