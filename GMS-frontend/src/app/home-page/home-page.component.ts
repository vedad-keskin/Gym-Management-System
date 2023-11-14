import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {ClanarinaGetAllResponse, ClanarinaGetAllResponseClanarina} from "../ClanarinaGetAllResponse";
import {RecenzijaGetAllResponse, RecenzijaGetAllResponseRecenzija} from "../RecenzijaGetAllResponse";
import {Config} from "../config";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit{

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
