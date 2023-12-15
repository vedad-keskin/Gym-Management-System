import {Component, OnInit} from '@angular/core';
import {
  TeretanaGetAllEndpoint, TeretanaGetAllResponse,
  TeretanaGetAllResponseTeretana
} from "../endpoints/teretane-endpoints/teretane-getall-endpoint";


@Component({
  selector: 'app-administrator-page-teretane',
  templateUrl: './administrator-page-teretane.component.html',
  styleUrls: ['./administrator-page-teretane.component.css']
})
export class AdministratorPageTeretaneComponent implements OnInit{

  constructor(private TeretanaGetAllEndpoint:TeretanaGetAllEndpoint) {
  }

  teretane: TeretanaGetAllResponseTeretana[] = [];
  PretragaNaziv: string = "";


  public prikaziAdd:boolean = false;


  ngOnInit() {
    this.TeretanaGetAllEndpoint.Handle().subscribe((x:TeretanaGetAllResponse )=>{
      this.teretane = x.teretane;
    })
  }

  GetFiltiraneTeretane() {
    return this.teretane.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }
  Odaberi(x: TeretanaGetAllResponseTeretana) {

  }
}
