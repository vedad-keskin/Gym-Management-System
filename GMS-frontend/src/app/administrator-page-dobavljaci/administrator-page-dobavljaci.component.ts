import {Component, OnInit} from '@angular/core';
import {
  DobavljacGetAllResponse,
  DobavljacGetAllResponseDobavljaci,
  DobavljaciGetAllEndpoint
} from "../endpoints/dobavljaci-endpoints/dobavljaci-getall-endpoint";
import {
  DobavljaciEditEndpoint,
  DobavljaciEditRequest
} from "../endpoints/dobavljaci-endpoints/dobavljaci-edit-endpoint";
import {DobavljacAddEndpoint, DobavljacAddRequest} from "../endpoints/dobavljaci-endpoints/dobavljaci-add-endpoint";

@Component({
  selector: 'app-administrator-page-dobavljaci',
  templateUrl: './administrator-page-dobavljaci.component.html',
  styleUrls: ['./administrator-page-dobavljaci.component.css']
})
export class AdministratorPageDobavljaciComponent implements OnInit{

  constructor(private DobavljaciGetAllEndpoint:DobavljaciGetAllEndpoint,
              private DobavljaciEditEndpoint:DobavljaciEditEndpoint,
              private DobavljacAddEndpoint:DobavljacAddEndpoint) {

  }

  dobavljaci: DobavljacGetAllResponseDobavljaci[] = [];
  PretragaNaziv: string = "";
  public odabraniDobavljac: DobavljaciEditRequest | null = null;

  public prikaziAdd:boolean = false;
  public noviDobavljac:DobavljacAddRequest = {
    naziv: ""
  };
  ngOnInit():void {

    this.DobavljaciGetAllEndpoint.Handle().subscribe((x:DobavljacGetAllResponse )=>{
      this.dobavljaci = x.dobavljaci;
    });

  }

  GetFiltiriraniDobavljaci() {
    return this.dobavljaci.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }

  Save() {
    this.DobavljaciEditEndpoint.Handle(this.odabraniDobavljac!).subscribe((x)=>{
      this.ngOnInit();
      this.odabraniDobavljac = null
    })
  }

  Close() {
    this.odabraniDobavljac = null
    this.ngOnInit();
  }

  Odaberi(x: DobavljacGetAllResponseDobavljaci) {
    this.odabraniDobavljac = {
      id: x.id,
      naziv: x.naziv,
    } ;
  }

  SaveNew() {
    this.DobavljacAddEndpoint.Handle(this.noviDobavljac).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;
      this.noviDobavljac.naziv ="";
    })
  }
}
