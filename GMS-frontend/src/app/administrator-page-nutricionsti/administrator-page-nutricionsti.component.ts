import {Component, OnInit} from '@angular/core';
import {
  SeminarGetAllResponse,
  SeminarGetAllResponseSeminari, SeminariGetAllEndpoint
} from "../endpoints/seminari-endpoints/seminari-getall-endpoint";

import {
  NutricionstGetAllResponse,
  NutricionstGetAllResponseNutricionst,
  NutricionstiGetallEndpoint
} from "../endpoints/nutricionsti-endpoints/nutricionsti-getall-endpoint";
import {
  NutricionistSeminarGetEndpoint, NutricionistSeminarGetResponse
} from "../endpoints/nutricionsti-endpoints/nutricionsti-seminar-endpoints/nutricionsti-seminari-get-endpoint";
import {
  NutricionistSeminarAddEndpoint, NutricionistSeminarAddRequest
} from "../endpoints/nutricionsti-endpoints/nutricionsti-seminar-endpoints/nutricionsti-seminari-add-endpoint";

@Component({
  selector: 'app-administrator-page-nutricionsti',
  templateUrl: './administrator-page-nutricionsti.component.html',
  styleUrls: ['./administrator-page-nutricionsti.component.css']
})
export class AdministratorPageNutricionstiComponent implements OnInit{
  constructor(private NutricionstiGetallEndpoint:NutricionstiGetallEndpoint,
              private NutricionistSeminarGetEndpoint:NutricionistSeminarGetEndpoint,
              private NutricionistSeminarAddEndpoint:NutricionistSeminarAddEndpoint,
              private SeminariGetAllEndpoint:SeminariGetAllEndpoint) {
  }

  nutricionsti: NutricionstGetAllResponseNutricionst[] = [];
  seminari: SeminarGetAllResponseSeminari[] = [];
  PretragaNaziv: string = "";
  public odbraniSeminari : NutricionistSeminarGetResponse | null = null;


  public prikaziAdd:boolean = false;
  public prikaziPregled:boolean = false;
  public prikaziAddSeminara:boolean = false;

  public noviNutricionstSeminar:NutricionistSeminarAddRequest = {
    nutricionistID: 0,
    seminarID: 1,
  };


  ngOnInit() {
    this.NutricionstiGetallEndpoint.Handle().subscribe((x:NutricionstGetAllResponse )=>{
      this.nutricionsti = x.nutricionisti;
    })

    this.SeminariGetAllEndpoint.Handle().subscribe((x:SeminarGetAllResponse )=>{
      this.seminari = x.seminari;
    })
  }


  OdaberiZaPregled(id: number) {
    this.NutricionistSeminarGetEndpoint.Handle(id).subscribe({
        next: x => {
          this.odbraniSeminari = x;
        }
      }
    )
    this.prikaziPregled = !this.prikaziPregled;
    this.prikaziAddSeminara = false;
  }

  OdaberiZaAdd(id: number) {
    this.prikaziAddSeminara = !this.prikaziAddSeminara;
    this.noviNutricionstSeminar.nutricionistID = id;
    this.prikaziPregled = false;
  }


  GetFiltriraniNutricionsti() {
    return this.nutricionsti.filter(x=> x.ime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.prezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) );
  }

  Close() {
    this.odbraniSeminari = null
    this.prikaziPregled = false;
    this.ngOnInit();
  }

  SaveNewSeminar() {
    this.NutricionistSeminarAddEndpoint.Handle(this.noviNutricionstSeminar).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAddSeminara = false;

    })
  }


  OdaberiZaModifikaciju(x: NutricionstGetAllResponseNutricionst) {

  }
}
