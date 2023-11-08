import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Config} from "./config";
import {ClanarinaGetAllResponse, ClanarinaGetAllResponseClanarina} from "./ClanarinaGetAllResponse";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(public httpclient : HttpClient) {

  }

  clanarine: ClanarinaGetAllResponseClanarina[] = [];

  ngOnInit():void {


    let url = Config.adresa + 'Clanarina-GetAll';

    this.httpclient.get<ClanarinaGetAllResponse>(url).subscribe((x:ClanarinaGetAllResponse )=>{
      this.clanarine = x.clanarine;
    })



  }

}
