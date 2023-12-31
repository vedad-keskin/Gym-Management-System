import {Component, OnInit} from '@angular/core';

import {
  TrenerGetallEndpoint,
  TrenerGetAllResponse,
  TrenerGetAllResponseTrener
} from "../endpoints/treneri-endpoints/treneri-getall-endpoint";
import {
  TrenerSeminarGetEndpoint, TrenerSeminarGetResponse
} from "../endpoints/treneri-endpoints/treneri-seminari-endpoints/treneri-seminari-get-endpoint";
import {
  TrenerSeminarAddEndpoint, TrenerSeminarAddRequest
} from "../endpoints/treneri-endpoints/treneri-seminari-endpoints/treneri-seminari-add-endpoint";
import {
  SeminarGetAllResponse,
  SeminarGetAllResponseSeminari,
  SeminariGetAllEndpoint
} from "../endpoints/seminari-endpoints/seminari-getall-endpoint";
import {TrenerAddEndpoint, TrenerAddRequest} from "../endpoints/treneri-endpoints/treneri-add-endpoint";
import {TreneriEditEndpoint, TreneriEditRequest} from "../endpoints/treneri-endpoints/treneri-edit-endpoint";


@Component({
  selector: 'app-administrator-page-treneri',
  templateUrl: './administrator-page-treneri.component.html',
  styleUrls: ['./administrator-page-treneri.component.css']
})
export class AdministratorPageTreneriComponent implements OnInit{


  constructor(private TrenerGetallEndpoint:TrenerGetallEndpoint,
              private TrenerSeminarGetEndpoint:TrenerSeminarGetEndpoint,
              private TrenerSeminarAddEndpoint:TrenerSeminarAddEndpoint,
              private SeminariGetAllEndpoint:SeminariGetAllEndpoint,
              private TrenerAddEndpoint:TrenerAddEndpoint,
              private TreneriEditEndpoint:TreneriEditEndpoint) {
  }

  treneri: TrenerGetAllResponseTrener[] = [];
  seminari: SeminarGetAllResponseSeminari[] = [];
  PretragaNaziv: string = "";
  public odbraniSeminari : TrenerSeminarGetResponse | null = null;
  public odabraniTrener: TreneriEditRequest | null = null;


  public prikaziAdd:boolean = false;
  public prikaziPregled:boolean = false;
  public prikaziAddSeminara:boolean = false;

  public noviTrenerSeminar:TrenerSeminarAddRequest = {
    trenerID: 0,
    seminarID: 1,
  };


  public noviTrener:TrenerAddRequest = {
    ime: "",
    prezime: "",
    brojTelefona: "",
    slika: "",
  };


  ngOnInit() {

    this.fetchTreneri();
    this.fetchSeminari();
  }


  OdaberiZaPregled(id: number) {
    this.TrenerSeminarGetEndpoint.Handle(id).subscribe({
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
    this.noviTrenerSeminar.trenerID = id;
    this.prikaziPregled = false;
  }


  GetFiltiraniTreneri() {
    return this.treneri.filter(x=> x.ime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.prezime.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) );
  }

  Close() {
    this.odbraniSeminari = null;
    this.odabraniTrener = null;
    this.prikaziAddSeminara = false;
    this.prikaziPregled = false;
    this.prikaziAdd = false;
    this.ngOnInit();
  }

  SaveNewSeminar() {
    this.TrenerSeminarAddEndpoint.Handle(this.noviTrenerSeminar).subscribe((x)=>{
      this.fetchTreneri();
      this.fetchSeminari();
      this.prikaziAddSeminara = false;

    })
  }

  OdaberiZaModifikaciju(x: TrenerGetAllResponseTrener) {
    this.odabraniTrener = {
      id: x.id,
      ime: x.ime,
      prezime: x.prezime,
      brojTelefona:x.brojTelefona,
      slika: x.slika
    } ;
    this.prikaziAdd = false;
  }

  private fetchSeminari() {
    this.SeminariGetAllEndpoint.Handle().subscribe((x:SeminarGetAllResponse )=>{
      this.seminari = x.seminari;
    })
  }

  private fetchTreneri() {
    this.TrenerGetallEndpoint.Handle().subscribe((x:TrenerGetAllResponse )=>{
      this.treneri = x.treneri;
    })
  }

  SaveNew() {
    this.TrenerAddEndpoint.Handle(this.noviTrener).subscribe((x)=>{
      this.fetchTreneri();
      this.fetchSeminari();
      this.prikaziAdd = false;
      this.noviTrener.ime ="";
      this.noviTrener.prezime ="";
      this.noviTrener.slika ="";
      this.noviTrener.brojTelefona ="";

    })
  }

  Preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.noviTrener!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }

  }

  PreviewEdit() {
    // @ts-ignore
    var file = document.getElementById("slika-input-edit").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.odabraniTrener!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  Save() {
    this.TreneriEditEndpoint.Handle(this.odabraniTrener!).subscribe((x)=>{
      this.fetchTreneri();
      this.fetchSeminari();
      this.odabraniTrener = null
    });
  }
}
