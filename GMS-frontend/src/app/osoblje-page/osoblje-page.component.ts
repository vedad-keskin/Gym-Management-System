import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TrenerGetAllResponse, TrenerGetAllResponseTrener} from "./TrenerGetAllResponse";
import {NutricionstGetAllResponse, NutricionstGetAllResponseNutricionst} from "./NutricionstGetAllResponse";
import {Config} from "../config";

@Component({
  selector: 'app-osoblje-page',
  templateUrl: './osoblje-page.component.html',
  styleUrls: ['./osoblje-page.component.css']
})
export class OsobljePageComponent implements OnInit{

  constructor(public httpclient : HttpClient) {

  }
  treneri: TrenerGetAllResponseTrener[] = [];
  nutricionsti : NutricionstGetAllResponseNutricionst[] = [];

  ngOnInit():void {


    let url1 = Config.adresa + 'Trener-GetAll';
    let url2 = Config.adresa + 'Nutricionist-GetAll';



    this.httpclient.get<TrenerGetAllResponse>(url1).subscribe((x:TrenerGetAllResponse )=>{
      this.treneri = x.treneri;
    })

    this.httpclient.get<NutricionstGetAllResponse>(url2).subscribe((x:NutricionstGetAllResponse )=>{
      this.nutricionsti = x.nutricionisti;
    })






  }
}
