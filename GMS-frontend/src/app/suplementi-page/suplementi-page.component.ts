import {Component, OnInit} from '@angular/core';
import {
  SuplementGetAllResponse,
  SuplementGetAllResponseSuplement,
  SuplementiGetallEndpoint
} from "../endpoints/suplementi-endpoints/suplementi-getall-endpoint";
import {
  Korisnik_SuplementAddEndpoint, Korisnik_SuplementAddRequest
} from "../endpoints/korisnik-endpoints/korisnik-suplementi-endpoints/korisnik-suplement-add-endpoint";
import {MyAuthService} from "../services/MyAuthService";


@Component({
  selector: 'app-suplementi-page',
  templateUrl: './suplementi-page.component.html',
  styleUrls: ['./suplementi-page.component.css']
})
export class SuplementiPageComponent implements OnInit{

  constructor(private SuplementigetAllEndpoint:SuplementiGetallEndpoint,
              private Korisnik_SuplementAddEndpoint:Korisnik_SuplementAddEndpoint,
              private MyAuthService:MyAuthService) {

  }

  public prikaziAdd:boolean = false;
  id:number = 0
  ukupnaCijena: number = 0

  odabraniSuplement : SuplementGetAllResponseSuplement | null = null;
  suplementi: SuplementGetAllResponseSuplement[] = [];
  PretragaNaziv: string = "";

  public noviSuplement:Korisnik_SuplementAddRequest = {
    korisnikID: this.id,
    suplementID: 1,
    datumVrijemeNarudzbe: new Date(),
    kolicina: 1,
    isporuceno: false
  };

  ngOnInit():void {
    this.id = this.MyAuthService.returnId()!;
    this.noviSuplement.korisnikID = this.id;

    this.SuplementigetAllEndpoint.Handle().subscribe((x:SuplementGetAllResponse )=>{
      this.suplementi = x.suplementi;
    })

  }
  GetFiltiraniSuplementi() {
    return this.suplementi.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }

  Save() {
    this.Korisnik_SuplementAddEndpoint.Handle(this.noviSuplement).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;
      alert("Suplement rezervisan");
    })
  }

  Close() {
    this.prikaziAdd = false;
     this.noviSuplement.kolicina = 1;
  }

  Odaberi(x: SuplementGetAllResponseSuplement) {
    if(this.MyAuthService.nijelLogiran()) {
      alert("Morate biti prijavljeni da bi ste kupili suplement");
    }
    else if(this.MyAuthService.isAdmin()) {
      alert("Samo korisnici mogu kupovati suplemente");
    }
    else if(this.MyAuthService.isKorisnik()){
      this.prikaziAdd = true;
      this.odabraniSuplement = x;
      this.noviSuplement.suplementID = this.odabraniSuplement.id;
      this.ukupnaCijena = this.odabraniSuplement.cijena * this.noviSuplement.kolicina;
    }
  }

  IzracunajUkupno() {
    if(this.odabraniSuplement != null) {
      this.ukupnaCijena = this.odabraniSuplement?.cijena * this.noviSuplement?.kolicina;
    }
  }
}
