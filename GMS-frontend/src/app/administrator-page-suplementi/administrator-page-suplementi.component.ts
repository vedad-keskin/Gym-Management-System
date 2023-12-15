import {Component, OnInit} from '@angular/core';
import {
  SuplementGetAllResponse,
  SuplementGetAllResponseSuplement,
  SuplementiGetallEndpoint
} from "../endpoints/suplementi-endpoints/suplementi-getall-endpoint";
import {FAQGetAllResponse, FAQGetAllResponseFAQ} from "../endpoints/faq-endpoints/faq-getall-endpoint";

@Component({
  selector: 'app-administrator-page-suplementi',
  templateUrl: './administrator-page-suplementi.component.html',
  styleUrls: ['./administrator-page-suplementi.component.css']
})
export class AdministratorPageSuplementiComponent implements OnInit{

  constructor(private SuplementiGetallEndpoint:SuplementiGetallEndpoint) {
  }

  suplementi: SuplementGetAllResponseSuplement[] = [];
  PretragaNaziv: string = "";



  public prikaziAdd:boolean = false;


  ngOnInit() {
    this.SuplementiGetallEndpoint.Handle().subscribe((x:SuplementGetAllResponse )=>{
      this.suplementi = x.suplementi;
    })
  }

  Odaberi(x: SuplementGetAllResponseSuplement) {

  }


  GetFiltiraniSuplementi() {
    return this.suplementi.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.nazivKategorija.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.nazivDobavljaca.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) );
  }
}
