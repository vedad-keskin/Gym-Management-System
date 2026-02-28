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
import {
  NutricionistiEditEndpoint,
  NutricionistiEditRequest
} from "../endpoints/nutricionsti-endpoints/nutricionist-edit-endpoint";
import {
  NutricionistAddEndpoint,
  NutricionistAddRequest
} from "../endpoints/nutricionsti-endpoints/nutricionisti-add-endpoint";


@Component({
  selector: 'app-administrator-page-nutricionsti',
  templateUrl: './administrator-page-nutricionsti.component.html',
  styleUrls: ['./administrator-page-nutricionsti.component.css']
})
export class AdministratorPageNutricionstiComponent implements OnInit{
  constructor(private NutricionstiGetallEndpoint:NutricionstiGetallEndpoint,
              private NutricionistSeminarGetEndpoint:NutricionistSeminarGetEndpoint,
              private NutricionistSeminarAddEndpoint:NutricionistSeminarAddEndpoint,
              private SeminariGetAllEndpoint:SeminariGetAllEndpoint,
              private NutricionistiEditEndpoint:NutricionistiEditEndpoint,
              private NutricionistAddEndpoint:NutricionistAddEndpoint) {
  }

  nutricionsti: NutricionstGetAllResponseNutricionst[] = [];
  seminari: SeminarGetAllResponseSeminari[] = [];
  PretragaNaziv: string = "";
  public odbraniSeminari : NutricionistSeminarGetResponse | null = null;
  public odabraniNutricionist: NutricionistiEditRequest | null = null;

  public prikaziAdd:boolean = false;
  public prikaziPregled:boolean = false;
  public prikaziAddSeminara:boolean = false;

  public noviNutricionstSeminar:NutricionistSeminarAddRequest = {
    nutricionistID: 0,
    seminarID: 1,
  };

  public noviNutricionist:NutricionistAddRequest = {
    ime: "",
    prezime: "",
    brojTelefona: "",
    slika: "",
  };


  ngOnInit() {

    this.fetchNutricionisti();
    this.fetchSeminari();
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
    this.odbraniSeminari = null;
    this.odabraniNutricionist = null;
    this.prikaziAddSeminara = false;
    this.prikaziPregled = false;
    this.prikaziAdd = false;
    this.ngOnInit();
  }

  SaveNewSeminar() {
    this.NutricionistSeminarAddEndpoint.Handle(this.noviNutricionstSeminar).subscribe((x)=>{
      this.fetchNutricionisti();
      this.fetchSeminari();
      this.Close();

    })
  }


  OdaberiZaModifikaciju(x: NutricionstGetAllResponseNutricionst) {
    this.odabraniNutricionist = {
      id: x.id,
      ime: x.ime,
      prezime: x.prezime,
      brojTelefona:x.brojTelefona,
      slika: x.slika
    };
    this.prikaziAdd = false;
  }

  private fetchSeminari() {
    this.SeminariGetAllEndpoint.Handle().subscribe((x:SeminarGetAllResponse )=>{
      this.seminari = x.seminari;
    })
  }

  private fetchNutricionisti() {
    this.NutricionstiGetallEndpoint.Handle().subscribe((x:NutricionstGetAllResponse )=>{
      this.nutricionsti = x.nutricionisti;
    })
  }

  Save() {
    this.NutricionistiEditEndpoint.Handle(this.odabraniNutricionist!).subscribe((x)=>{
      this.fetchNutricionisti();
      this.fetchSeminari();
      this.Close();
    });
  }

  PreviewEdit() {
    // @ts-ignore
    var file = document.getElementById("slika-input-edit").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.odabraniNutricionist!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  SaveNew() {
    this.NutricionistAddEndpoint.Handle(this.noviNutricionist).subscribe((x)=>{
      this.fetchNutricionisti();
      this.fetchSeminari();
      this.prikaziAdd = false;
      this.noviNutricionist.ime ="";
      this.noviNutricionist.prezime ="";
      this.noviNutricionist.slika ="";
      this.noviNutricionist.brojTelefona ="";

    });
  }

  Preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.noviNutricionist!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }
}
