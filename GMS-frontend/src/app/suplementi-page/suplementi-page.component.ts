import {Component, OnInit} from '@angular/core';
import {
  SuplementGetAllResponse,
  SuplementGetAllResponseSuplement,
  SuplementiGetallEndpoint
} from "../endpoints/suplementi-endpoints/suplementi-getall-endpoint";

@Component({
  selector: 'app-suplementi-page',
  templateUrl: './suplementi-page.component.html',
  styleUrls: ['./suplementi-page.component.css']
})
export class SuplementiPageComponent implements OnInit{

  constructor(private SuplementigetAllEndpoint:SuplementiGetallEndpoint) {

  }

  suplementi: SuplementGetAllResponseSuplement[] = [];
  PretragaNaziv: string = "";

  ngOnInit():void {

    this.SuplementigetAllEndpoint.Handle().subscribe((x:SuplementGetAllResponse )=>{
      this.suplementi = x.suplementi;
    })

  }
  GetFiltiraniSuplementi() {
    return this.suplementi.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }

}
