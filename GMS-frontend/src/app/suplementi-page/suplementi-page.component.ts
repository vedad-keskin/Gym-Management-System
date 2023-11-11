import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SuplementGetAllResponse, SuplementGetAllResponseSuplement} from "./SuplementGetAllResponse";
import {Config} from "../config";
import {FAQGetAllResponse} from "../faq-page/FAQGetAllResponse";

@Component({
  selector: 'app-suplementi-page',
  templateUrl: './suplementi-page.component.html',
  styleUrls: ['./suplementi-page.component.css']
})
export class SuplementiPageComponent implements OnInit{

  constructor(public httpclient : HttpClient) {

  }

  suplementi: SuplementGetAllResponseSuplement[] = [];
  PretragaNaziv: string = "";

  ngOnInit():void {
    let url = Config.adresa + 'Suplement-GetAll';

    this.httpclient.get<SuplementGetAllResponse>(url).subscribe((x:SuplementGetAllResponse )=>{
      this.suplementi = x.suplementi;
    })

  }
  GetFiltiraniSuplementi() {
    return this.suplementi.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }

}
