import {Component, OnInit} from '@angular/core';
import {
  KategorijaGetAllResponse, KategorijaGetAllResponseKategorija,
  KategorijeGetAllEndpoint
} from "../endpoints/kategorije-endpoints/kategorije-getall-endpoint";
import {
  KategorijeEditEndpoint,
  KategorijeEditRequest
} from "../endpoints/kategorije-endpoints/kategorije-edit-endpoint";
import {DobavljacAddRequest} from "../endpoints/dobavljaci-endpoints/dobavljaci-add-endpoint";
import {KategorijaAddEndpoint, KategorijaAddRequest} from "../endpoints/kategorije-endpoints/kategorije-add-endpoint";

@Component({
  selector: 'app-administrator-page-kategorije',
  templateUrl: './administrator-page-kategorije.component.html',
  styleUrls: ['./administrator-page-kategorije.component.css']
})
export class AdministratorPageKategorijeComponent implements OnInit{

  constructor(private KategorijeGetAllEndpoint:KategorijeGetAllEndpoint,
              private KategorijeEditEndpoint:KategorijeEditEndpoint,
              private KategorijaAddEndpoint:KategorijaAddEndpoint ) {

  }

  kategorije: KategorijaGetAllResponseKategorija[] = [];
  PretragaNaziv: string = "";
  public odabranaKategorija: KategorijeEditRequest | null = null;


  public prikaziAdd:boolean = false;
  public novaKategorija:KategorijaAddRequest = {
    naziv: ""
  };
  ngOnInit():void {

    this.KategorijeGetAllEndpoint.Handle().subscribe((x:KategorijaGetAllResponse )=>{
      this.kategorije = x.kategorije;
    });

  }
  GetFiltiriranuKategoriju() {
    return this.kategorije.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Close() {
    this.odabranaKategorija = null
    this.ngOnInit();
  }

  Save() {
    this.KategorijeEditEndpoint.Handle(this.odabranaKategorija!).subscribe((x)=>{
      this.ngOnInit();
      this.odabranaKategorija = null
    })
  }

  Odaberi(x: KategorijaGetAllResponseKategorija) {
    this.odabranaKategorija = {
      id: x.id,
      naziv: x.naziv
    } ;
  }

  SaveNew() {
    this.KategorijaAddEndpoint.Handle(this.novaKategorija).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;
      this.novaKategorija.naziv ="";
    })
  }
}
