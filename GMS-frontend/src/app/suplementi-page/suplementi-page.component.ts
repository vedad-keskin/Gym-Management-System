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
import {
  DobavljacGetAllResponse,
  DobavljacGetAllResponseDobavljaci,
  DobavljaciGetAllEndpoint
} from "../endpoints/dobavljaci-endpoints/dobavljaci-getall-endpoint";
import {
  KategorijaGetAllResponse,
  KategorijaGetAllResponseKategorija,
  KategorijeGetAllEndpoint
} from "../endpoints/kategorije-endpoints/kategorije-getall-endpoint";


@Component({
  selector: 'app-suplementi-page',
  templateUrl: './suplementi-page.component.html',
  styleUrls: ['./suplementi-page.component.css']
})
export class SuplementiPageComponent implements OnInit{

  constructor(private SuplementigetAllEndpoint:SuplementiGetallEndpoint,
              private Korisnik_SuplementAddEndpoint:Korisnik_SuplementAddEndpoint,
              private MyAuthService:MyAuthService,
              private DobavljaciGetAllEndpoint:DobavljaciGetAllEndpoint,
              private KategorijeGetAllEndpoint:KategorijeGetAllEndpoint) {

  }

  public prikaziAdd:boolean = false;

  public SuccessPopUp:boolean = false;
  public ErrorPopUp:boolean = false;
  public ErrorPopUp2:boolean = false;

  id:number = 0
  ukupnaCijena: number = 0

  odabraniSuplement : SuplementGetAllResponseSuplement | null = null;
  suplementi: SuplementGetAllResponseSuplement[] = [];
  dobavljaci: DobavljacGetAllResponseDobavljaci[] = [];
  kategorije: KategorijaGetAllResponseKategorija[] = [];


  PretragaNaziv: string = "";
  PretragaDobavljac: string = "";
  PretragaKategorija: string = "";


  public noviSuplement:Korisnik_SuplementAddRequest = {
    korisnikID: this.id,
    suplementID: 1,
    kolicina: 1,
    isporuceno: false
  };

  ngOnInit():void {
    this.id = this.MyAuthService.returnId()!;
    this.noviSuplement.korisnikID = this.id;

    this.fetchSuplementi();
    this.fetchDobavljaci();
    this.fetchKategorije();
  }
  GetFiltiraniSuplementi() {
    return this.suplementi.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) &&
      (x.nazivDobavljaca.toLowerCase().includes(this.PretragaDobavljac.toLowerCase()) || this.PretragaDobavljac == "Svi" ) &&
      (x.nazivKategorija.toLowerCase().includes(this.PretragaKategorija.toLowerCase()) || this.PretragaKategorija =="Sve" ));
  }

  Save() {
    this.Korisnik_SuplementAddEndpoint.Handle(this.noviSuplement).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;
      this.SuccessPopUp = true;
    })
  }

  Close() {
    this.prikaziAdd = false;
    this.noviSuplement.kolicina = 1;
  }

  Odaberi(x: SuplementGetAllResponseSuplement) {
    if(this.MyAuthService.nijelLogiran()) {
      this.ErrorPopUp = true;
    }
    else if(this.MyAuthService.isAdmin()) {
      this.ErrorPopUp2 = true;
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

  private fetchKategorije() {
    this.KategorijeGetAllEndpoint.Handle().subscribe((x:KategorijaGetAllResponse )=>{
      this.kategorije = x.kategorije;
    });
  }

  private fetchDobavljaci() {
    this.DobavljaciGetAllEndpoint.Handle().subscribe((x:DobavljacGetAllResponse )=>{
      this.dobavljaci = x.dobavljaci;
    });
  }

  private fetchSuplementi() {
    this.SuplementigetAllEndpoint.Handle().subscribe((x:SuplementGetAllResponse )=>{
      this.suplementi = x.suplementi;
    });
  }

  ZatvoriPopUp() {
    this.SuccessPopUp = false;
    this.ErrorPopUp = false;
    this.ErrorPopUp2 = false;
    this.ngOnInit();
  }
}
