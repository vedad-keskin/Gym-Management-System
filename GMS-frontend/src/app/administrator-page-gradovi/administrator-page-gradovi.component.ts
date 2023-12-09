import {Component, OnInit} from '@angular/core';
import {
  GradGetAllResponse,
  GradGetAllResponseGrad,
  GradoviGetallEndpoint
} from "../endpoints/gradovi-endpoints/gradovi-getall-endpoint";
import {GradAddEndpoint, GradAddRequest} from "../endpoints/gradovi-endpoints/gradovi-add-endpoint";
import {GradoviEditEndpoint, GradoviEditRequest} from "../endpoints/gradovi-endpoints/gradovi-edit-endpoint";

@Component({
  selector: 'app-administrator-page-gradovi',
  templateUrl: './administrator-page-gradovi.component.html',
  styleUrls: ['./administrator-page-gradovi.component.css']
})
export class AdministratorPageGradoviComponent implements OnInit{


  constructor(private GradovigetAllEndpoint:GradoviGetallEndpoint,
              private GradoviEditEndpoint:GradoviEditEndpoint,
              private GradAddEndpoint:GradAddEndpoint) {

  }
  gradovi: GradGetAllResponseGrad[] = [];
  PretragaNaziv: string = "";
  public odabraniGrad: GradoviEditRequest | null = null;

  public prikaziAdd:boolean = false;
  public noviGrad:GradAddRequest = {
    naziv: ""
  };
  ngOnInit():void {


    this.GradovigetAllEndpoint.Handle().subscribe((x:GradGetAllResponse )=>{
      this.gradovi = x.gradovi;
    });


  }

  GetFiltiraniGradovi() {
    return this.gradovi.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Save() {
    this.GradoviEditEndpoint.Handle(this.odabraniGrad!).subscribe((x)=>{
      this.ngOnInit();
      this.odabraniGrad = null
    })
  }

  Close() {
    this.odabraniGrad = null
    this.ngOnInit();
  }

  Odaberi(x: GradGetAllResponseGrad) {
    this.odabraniGrad = {
      id: x.id,
      naziv: x.naziv,
    } ;
  }

  SaveNew() {
    this.GradAddEndpoint.Handle(this.noviGrad).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;
      this.noviGrad.naziv ="";
    })
  }
}
