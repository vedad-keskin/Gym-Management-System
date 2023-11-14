import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ClanarinaGetAllResponse, ClanarinaGetAllResponseClanarina} from "../ClanarinaGetAllResponse";
import {Config} from "../config";
import {FAQGetAllResponse, FAQGetAllResponseFAQ} from "./FAQGetAllResponse";

@Component({
  selector: 'app-faq-page',
  templateUrl: './faq-page.component.html',
  styleUrls: ['./faq-page.component.css']
})
export class FaqPageComponent implements OnInit{
  constructor(public httpclient : HttpClient) {

  }

  faq: FAQGetAllResponseFAQ[] = [];

  ngOnInit():void {


    let url = Config.adresa + 'FAQ-GetAll';

    this.httpclient.get<FAQGetAllResponse>(url).subscribe((x:FAQGetAllResponse )=>{
      this.faq = x.faq;
    })



  }
}
