import {Component, OnInit} from '@angular/core';
import {
  TeretanaGetAllEndpoint, TeretanaGetAllResponse,
  TeretanaGetAllResponseTeretana
} from "../endpoints/teretane-endpoints/teretane-getall-endpoint";
import {
  GradGetAllResponse,
  GradGetAllResponseGrad,
  GradoviGetallEndpoint
} from "../endpoints/gradovi-endpoints/gradovi-getall-endpoint";
import {TeretaneEditEndpoint, TeretaneEditRequest} from "../endpoints/teretane-endpoints/teretane-edit-endpoint";
import {SeminariEditRequest} from "../endpoints/seminari-endpoints/seminari-edit-endpoint";
import {TeretanaAddEndpoint, TeretanaAddRequest} from "../endpoints/teretane-endpoints/teretane-add-endpoint";
import {SeminarAddRequest} from "../endpoints/seminari-endpoints/seminari-add-endpoint";


@Component({
  selector: 'app-administrator-page-teretane',
  templateUrl: './administrator-page-teretane.component.html',
  styleUrls: ['./administrator-page-teretane.component.css']
})
export class AdministratorPageTeretaneComponent implements OnInit{

  constructor(private TeretanaGetAllEndpoint:TeretanaGetAllEndpoint,
              private GradoviGetallEndpoint:GradoviGetallEndpoint,
              private TeretaneEditEndpoint:TeretaneEditEndpoint,
              private TeretanaAddEndpoint:TeretanaAddEndpoint) {
  }

  teretane: TeretanaGetAllResponseTeretana[] = [];
  gradovi: GradGetAllResponseGrad[] = [];
  PretragaNaziv: string = "";


  public prikaziAdd:boolean = false;
  public odabranaTeretana: TeretaneEditRequest | null = null;
  public novaTeretana:TeretanaAddRequest = {
    naziv: "",
    adresa: "",
    gradID: 1
  };

  ngOnInit() {

    this.fetchTeretane();
    this.fetchGradovi();
  }

  GetFiltiraneTeretane() {
    return this.teretane.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }
  Odaberi(x: TeretanaGetAllResponseTeretana) {
    this.odabranaTeretana = {
      id: x.id,
      naziv: x.naziv,
      gradID: x.gradID,
      adresa:x.adresa
    } ;
  }

  Close() {
    this.odabranaTeretana = null
    this.ngOnInit();
  }

  Save() {
    this.TeretaneEditEndpoint.Handle(this.odabranaTeretana!).subscribe((x)=>{
      this.fetchTeretane();
      this.fetchGradovi();
      this.odabranaTeretana = null
    })
  }

  SaveNew() {
    this.TeretanaAddEndpoint.Handle(this.novaTeretana).subscribe((x)=>{
      this.fetchTeretane();
      this.fetchGradovi();
      this.prikaziAdd = false;
      this.novaTeretana.naziv ="";
      this.novaTeretana.adresa ="";
      this.novaTeretana.gradID = 1;
    })
  }

  private fetchGradovi() {
    this.GradoviGetallEndpoint.Handle().subscribe((x:GradGetAllResponse )=>{
      this.gradovi = x.gradovi;
    });
  }

  private fetchTeretane() {
    this.TeretanaGetAllEndpoint.Handle().subscribe((x:TeretanaGetAllResponse )=>{
      this.teretane = x.teretane;
    });
  }
}
