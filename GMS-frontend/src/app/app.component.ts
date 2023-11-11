import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Config} from "./config";
import {ClanarinaGetAllResponse, ClanarinaGetAllResponseClanarina} from "./ClanarinaGetAllResponse";
import {RecenzijaGetAllResponse, RecenzijaGetAllResponseRecenzija} from "./RecenzijaGetAllResponse";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  isVidljivoHome: boolean = true;
  isVidljivoFAQ: boolean = false;
  isVidljivoOsoblje: boolean = false;
  isVidljivoSuplememti: boolean = false;
  constructor(public httpclient : HttpClient) {

  }

  clanarine: ClanarinaGetAllResponseClanarina[] = [];
  recenzije: RecenzijaGetAllResponseRecenzija[] = [];

  ngOnInit():void {


    let url1 = Config.adresa + 'Clanarina-GetAll';
    let url2 = Config.adresa + 'Recenzija-GetAll';

    this.httpclient.get<ClanarinaGetAllResponse>(url1).subscribe((x:ClanarinaGetAllResponse )=>{
      this.clanarine = x.clanarine;
    })
    this.httpclient.get<RecenzijaGetAllResponse>(url2).subscribe((x:RecenzijaGetAllResponse )=>{
      this.recenzije = x.recenzije;
    })



  }



}
