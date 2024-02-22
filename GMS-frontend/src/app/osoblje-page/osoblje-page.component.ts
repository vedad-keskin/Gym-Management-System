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
  Korisnik_TrenerAddEndpoint,
  Korisnik_TrenerAddRequest
} from "../endpoints/korisnik-endpoints/korisnik-treneri-endpoints/korisnik-trener-add-endpoint";
import {MyAuthService} from "../services/MyAuthService";
import {
  Korisnik_NutricionistAddEndpoint,
  Korisnik_NutricionistAddRequest
} from "../endpoints/korisnik-endpoints/korisnik-nutricionst-endpoints/korisnik-nutricionist-add-endpoint";
import {Route, Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Config} from "../config";
import {SmsSendEndpoint} from "../endpoints/sms-endpoints/sms-send-endpoint";

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
              private Korisnik_NutricionistAddEndpoint:Korisnik_NutricionistAddEndpoint,
              private SmsSendEndpoint:SmsSendEndpoint) {

  }
  treneri: TrenerGetAllResponseTrener[] = [];
  nutricionsti : NutricionstGetAllResponseNutricionst[] = [];


  public prikaziAddZaTrenera:boolean = false;
  public prikaziAddZaNutricionistu:boolean = false;

  public SuccessPopUp:boolean = false;
  public ErrorPopUp:boolean = false;
  public ErrorPopUp2:boolean = false;


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
      this.SuccessPopUp = true;

      this.SmsSendEndpoint.Handle().subscribe((x)=> {
      });

    })
  }


  OdaberiTrenera(x: TrenerGetAllResponseTrener) {

    if(this.myAuthService.nijelLogiran()) {
      this.ErrorPopUp = true;
    }
    else if(this.myAuthService.isAdmin()) {
      this.ErrorPopUp2 = true;
    }
    else if(this.myAuthService.isKorisnik()){
      this.prikaziAddZaTrenera = true;
      this.odabraniTrener = x;
      this.noviKorisnikTrener.trenerID = this.odabraniTrener.id;
      this.SuccessPopUp = true;
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
      this.ErrorPopUp = true;
    }
    else if(this.myAuthService.isAdmin()) {
      this.ErrorPopUp2 = true;
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
      this.SuccessPopUp = true;

      this.SmsSendEndpoint.Handle().subscribe((x)=> {
      });

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

  ZatvoriPopUp() {
    this.SuccessPopUp = false;
    this.ErrorPopUp = false;
    this.ErrorPopUp2 = false;
    this.ngOnInit();
  }

}
