import {Component, OnInit} from '@angular/core';
import {
  ClanarinaGetAllResponse,
  ClanarinaGetAllResponseClanarina,
  ClanarineGetallEndpoint
} from "../endpoints/clanarine-endpoints/clanarine-getall-endpoint";

@Component({
  selector: 'app-administrator-page-clanarine',
  templateUrl: './administrator-page-clanarine.component.html',
  styleUrls: ['./administrator-page-clanarine.component.css']
})
export class AdministratorPageClanarineComponent implements OnInit{

  constructor(private ClanarinegetAllEndpoint:ClanarineGetallEndpoint) {

  }
  clanarine: ClanarinaGetAllResponseClanarina[] = [];
  PretragaNaziv: string = "";
  ngOnInit():void {


    this.ClanarinegetAllEndpoint.Handle().subscribe((x:ClanarinaGetAllResponse )=>{
      this.clanarine = x.clanarine;
    })

  }


  GetFiltiraniSuplementi() {
    return this.clanarine.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


}
