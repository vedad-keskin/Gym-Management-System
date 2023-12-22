import {Component, OnInit} from '@angular/core';
import {
  TrenerGetallEndpoint,
  TrenerGetAllResponse,
  TrenerGetAllResponseTrener
} from "../endpoints/treneri-endpoints/treneri-getall-endpoint";
import {
  NutricionstGetAllResponse,
  NutricionstGetAllResponseNutricionst,
  NutricionstiGetallEndpoint
} from "../endpoints/nutricionsti-endpoints/nutricionsti-getall-endpoint";
import {
  Korisnik_TrenerAddEndpoint, Korisnik_TrenerAddRequest
} from "../endpoints/korisnik-endpoints/korisnik-treneri-endpoints/korisnik-trener-add-endpoint";
import {MyAuthService} from "../services/MyAuthService";
import {
  Korisnik_NutricionistAddEndpoint, Korisnik_NutricionistAddRequest
} from "../endpoints/korisnik-endpoints/korisnik-nutricionst-endpoints/korisnik-nutricionist-add-endpoint";

@Component({
  selector: 'app-osoblje-page',
  templateUrl: './osoblje-page.component.html',
  styleUrls: ['./osoblje-page.component.css']
})
export class OsobljePageComponent implements OnInit{

  constructor(private TrenergetAllEndpoint:TrenerGetallEndpoint,
              private NutricionstgetAllEndpoint:NutricionstiGetallEndpoint,
              private Korisnik_TrenerAddEndpoint:Korisnik_TrenerAddEndpoint,
              private myAuthService: MyAuthService,
              private Korisnik_NutricionistAddEndpoint:Korisnik_NutricionistAddEndpoint) {

  }
  treneri: TrenerGetAllResponseTrener[] = [];
  nutricionsti : NutricionstGetAllResponseNutricionst[] = [];


  public prikaziAddZaTrenera:boolean = false;
  public prikaziAddZaNutricionistu:boolean = false;


  odabraniTrener : TrenerGetAllResponseTrener | null = null;
  odabraniNutricionist : NutricionstGetAllResponseNutricionst | null = null;
  id:number = 0

  public noviKorisnikTrener:Korisnik_TrenerAddRequest = {
    korisnikID: this.id,
    trenerID: 1,
    datumTermina: "2024-01-01T17:16:40",
    zakazanoSati: 1
  };

  public noviKorisnikNutricionist:Korisnik_NutricionistAddRequest = {
    korisnikID: this.id,
    nutricionistID: 1,
    datumTermina: "2024-01-01T17:16:40",
    zakazanoSati: 1
  };


  ngOnInit():void {
    this.id = this.myAuthService.returnId()!;
    this.noviKorisnikTrener.korisnikID = this.id;
    this.noviKorisnikNutricionist.korisnikID = this.id;




    this.fetchTreneri();
    this.fetchNutricionsti();
  }





  SaveZaTrenera() {
    this.Korisnik_TrenerAddEndpoint.Handle(this.noviKorisnikTrener).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAddZaTrenera = false;
      alert("Termin zakazan");
    })
  }

  OdaberiTrenera(x: TrenerGetAllResponseTrener) {

    if(this.myAuthService.nijelLogiran()) {
      alert("Morate biti prijavljeni da bi zakazali termine");
    }
    else if(this.myAuthService.isAdmin()) {
      alert("Samo korisnici mogu zakazivati termine");
    }
    else if(this.myAuthService.isKorisnik()){
      this.prikaziAddZaTrenera = true;
      this.odabraniTrener = x;
      this.noviKorisnikTrener.trenerID = this.odabraniTrener.id;
    }



  }

  CloseZaTrenera() {
    this.prikaziAddZaTrenera = false;
  }

  CloseZaNutricionstu() {
    this.prikaziAddZaNutricionistu = false;
  }

  OdaberiNutricionistu(x: NutricionstGetAllResponseNutricionst) {
    if(this.myAuthService.nijelLogiran()) {
      alert("Morate biti prijavljeni da bi zakazali termine");
    }
    else if(this.myAuthService.isAdmin()) {
      alert("Samo korisnici mogu zakazivati termine");
    }
    else if(this.myAuthService.isKorisnik()){
      this.prikaziAddZaNutricionistu = true;
      this.odabraniNutricionist = x;
      this.noviKorisnikNutricionist.nutricionistID = this.odabraniNutricionist.id;

    }
  }

  SaveZaNutricionistu() {
    this.Korisnik_NutricionistAddEndpoint.Handle(this.noviKorisnikNutricionist).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAddZaNutricionistu = false;
      alert("Termin zakazan");
    })
  }

  private fetchNutricionsti() {
    this.NutricionstgetAllEndpoint.Handle().subscribe((x:NutricionstGetAllResponse )=>{
      this.nutricionsti = x.nutricionisti;
    })
  }

  private fetchTreneri() {
    this.TrenergetAllEndpoint.Handle().subscribe((x:TrenerGetAllResponse )=>{
      this.treneri = x.treneri;
    })
  }
}
