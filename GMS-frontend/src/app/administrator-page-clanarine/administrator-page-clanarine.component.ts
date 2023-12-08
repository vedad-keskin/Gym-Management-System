import {Component, OnInit} from '@angular/core';
import {
  ClanarinaGetAllResponse,
  ClanarinaGetAllResponseClanarina,
  ClanarineGetallEndpoint
} from "../endpoints/clanarine-endpoints/clanarine-getall-endpoint";
import {ClanarineEditRequest} from "../endpoints/clanarine-endpoints/clanarine-edit-request";
import {Config} from "../config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-administrator-page-clanarine',
  templateUrl: './administrator-page-clanarine.component.html',
  styleUrls: ['./administrator-page-clanarine.component.css']
})
export class AdministratorPageClanarineComponent implements OnInit{

  constructor(private ClanarinegetAllEndpoint:ClanarineGetallEndpoint,public httpclient : HttpClient) {

  }
  clanarine: ClanarinaGetAllResponseClanarina[] = [];
  PretragaNaziv: string = "";
  public odabranaClanarina: ClanarineEditRequest | null = null;
  ngOnInit():void {


    this.ClanarinegetAllEndpoint.Handle().subscribe((x:ClanarinaGetAllResponse )=>{
      this.clanarine = x.clanarine;
    })

  }


  GetFiltiraniSuplementi() {
    return this.clanarine.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Odaberi(x: ClanarinaGetAllResponseClanarina) {
    this.odabranaClanarina = {
      id: x.id,
      naziv: x.naziv,
      cijena: x.cijena,
      opis:x.opis
    } ;
  }

  Save() {
    let url=Config.adresa+`Clanarina-Edit`;
    this.httpclient.post(url, this.odabranaClanarina).subscribe((x)=>{
      this.ngOnInit();
      // this.odabraniStudent!.ime=""; ako hocemo da se isprazni textbox
      // this.odabraniStudent!.prezime="";
      this.odabranaClanarina = null;
    })
  }
}
