import {Component, OnInit} from '@angular/core';
import {
  RecenzijaGetAllResponse, RecenzijaGetAllResponseRecenzija,
  RecenzijeGetallEndpoint
} from "../endpoints/recenzije-endpoints/recenzije-getall-endpoint";


@Component({
  selector: 'app-administrator-page-recenzije',
  templateUrl: './administrator-page-recenzije.component.html',
  styleUrls: ['./administrator-page-recenzije.component.css']
})
export class AdministratorPageRecenzijeComponent implements OnInit{


  constructor(private RecenzijeGetallEndpoint:RecenzijeGetallEndpoint) {}

  recenzije: RecenzijaGetAllResponseRecenzija[] = [];
  PretragaNaziv: string = "";

  public prikaziAdd:boolean = false;

  ngOnInit() {
    this.RecenzijeGetallEndpoint.Handle().subscribe((x:RecenzijaGetAllResponse )=>{
      this.recenzije = x.recenzije;
    })
  }


  Odaberi(x: RecenzijaGetAllResponseRecenzija) {

  }


  GetFiltiraneRecenzije() {
    return this.recenzije.filter(x=> x.ime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.prezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) );
  }
}
