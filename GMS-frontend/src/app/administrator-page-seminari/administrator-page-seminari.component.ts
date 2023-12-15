import {Component, OnInit} from '@angular/core';
import {
  SeminarGetAllResponse,
  SeminarGetAllResponseSeminari,
  SeminariGetAllEndpoint
} from "../endpoints/seminari-endpoints/seminari-getall-endpoint";
import {ClanarinaGetAllResponse} from "../endpoints/clanarine-endpoints/clanarine-getall-endpoint";
import {ClanarinaAddRequest} from "../endpoints/clanarine-endpoints/clanarina-add-endpoint";
import {SeminarAddEndpoint, SeminarAddRequest} from "../endpoints/seminari-endpoints/seminari-add-endpoint";

@Component({
  selector: 'app-administrator-page-seminari',
  templateUrl: './administrator-page-seminari.component.html',
  styleUrls: ['./administrator-page-seminari.component.css']
})
export class AdministratorPageSeminariComponent implements OnInit{

  constructor(private SeminariGetAllEndpoint:SeminariGetAllEndpoint,
              private SeminarAddEndpoint:SeminarAddEndpoint) {

  }

  seminari: SeminarGetAllResponseSeminari[] = [];
  PretragaNaziv: string = "";


  public prikaziAdd:boolean = false;
  public noviSeminar:SeminarAddRequest = {
    tema: "",
    predavac: "",
    datum: "2024-01-01T17:16:40"
  };

  GetFiltiraniSeminari() {
    return this.seminari.filter(x=> x.tema.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }
  ngOnInit():void {

    this.SeminariGetAllEndpoint.Handle().subscribe((x:SeminarGetAllResponse )=>{
      this.seminari = x.seminari;
    })

  }

  Odaberi(x: any) {

  }

  SaveNew() {
    this.SeminarAddEndpoint.Handle(this.noviSeminar).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;
      this.noviSeminar.tema ="";
      this.noviSeminar.predavac ="";
    })
  }
}
