import {Component, OnInit} from '@angular/core';

import {
  TrenerGetallEndpoint,
  TrenerGetAllResponse,
  TrenerGetAllResponseTrener
} from "../endpoints/treneri-endpoints/treneri-getall-endpoint";
import {
  TrenerSeminarGetEndpoint, TrenerSeminarGetResponse, TrenerSeminarGetResponseSeminar
} from "../endpoints/treneri-endpoints/treneri-seminari-endpoints/treneri-seminari-get-endpoint";
import {
  TrenerSeminarAddEndpoint, TrenerSeminarAddRequest
} from "../endpoints/treneri-endpoints/treneri-seminari-endpoints/treneri-seminari-add-endpoint";
import {
  SeminarGetAllResponse,
  SeminarGetAllResponseSeminari,
  SeminariGetAllEndpoint
} from "../endpoints/seminari-endpoints/seminari-getall-endpoint";


@Component({
  selector: 'app-administrator-page-treneri',
  templateUrl: './administrator-page-treneri.component.html',
  styleUrls: ['./administrator-page-treneri.component.css']
})
export class AdministratorPageTreneriComponent implements OnInit{

  constructor(private TrenerGetallEndpoint:TrenerGetallEndpoint,
              private TrenerSeminarGetEndpoint:TrenerSeminarGetEndpoint,
              private TrenerSeminarAddEndpoint:TrenerSeminarAddEndpoint,
              private SeminariGetAllEndpoint:SeminariGetAllEndpoint) {
  }

  treneri: TrenerGetAllResponseTrener[] = [];
  seminari: SeminarGetAllResponseSeminari[] = [];
  PretragaNaziv: string = "";
  public odbraniSeminari : TrenerSeminarGetResponse | null = null;

  public prikaziAdd:boolean = false;
  public prikaziPregled:boolean = false;
  public prikaziAddSeminara:boolean = false;

  public noviTrenerSeminar:TrenerSeminarAddRequest = {
    trenerID: 0,
    seminarID: 1,
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
    this.odbraniSeminari = null
    this.prikaziPregled = false;
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
}
