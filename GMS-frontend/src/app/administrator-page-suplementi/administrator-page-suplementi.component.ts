import {Component, OnInit} from '@angular/core';
import {
  SuplementGetAllResponse,
  SuplementGetAllResponseSuplement,
  SuplementiGetallEndpoint
} from "../endpoints/suplementi-endpoints/suplementi-getall-endpoint";
import {
  KategorijaGetAllResponse,
  KategorijaGetAllResponseKategorija,
  KategorijeGetAllEndpoint
} from "../endpoints/kategorije-endpoints/kategorije-getall-endpoint";
import {
  DobavljacGetAllResponse,
  DobavljacGetAllResponseDobavljaci,
  DobavljaciGetAllEndpoint
} from "../endpoints/dobavljaci-endpoints/dobavljaci-getall-endpoint";
import {
  SuplementiEditEndpoint,
  SuplementiEditRequest
} from "../endpoints/suplementi-endpoints/suplementi-edit-endpoint";
import {SuplementAddEndpoint, SuplementAddRequest} from "../endpoints/suplementi-endpoints/suplementi-add-endpoint";
import {KorisnikAddRequest} from "../endpoints/korisnik-endpoints/korisnik-add-endpoint";
import {KorisniciEditRequest} from "../endpoints/korisnik-endpoints/korisnik-edit-endpoint";

@Component({
  selector: 'app-administrator-page-suplementi',
  templateUrl: './administrator-page-suplementi.component.html',
  styleUrls: ['./administrator-page-suplementi.component.css']
})
export class AdministratorPageSuplementiComponent implements OnInit{

  constructor(private SuplementiGetallEndpoint:SuplementiGetallEndpoint,
              private KategorijeGetAllEndpoint:KategorijeGetAllEndpoint,
              private DobavljaciGetAllEndpoint:DobavljaciGetAllEndpoint,
              private SuplementiEditEndpoint:SuplementiEditEndpoint,
              private SuplementAddEndpoint:SuplementAddEndpoint) {
  }

  suplementi: SuplementGetAllResponseSuplement[] = [];
  dobavljaci: DobavljacGetAllResponseDobavljaci[] = [];
  kategorije: KategorijaGetAllResponseKategorija[] = [];
  PretragaNaziv: string = "";

  public prikaziAdd:boolean = false;
  public odabraniSuplement: SuplementiEditRequest | null = null;
  public noviSuplement:SuplementAddRequest = {
    naziv: "",
    gramaza: 100,
    cijena: 0,
    slika: "",
    opis: "",
    dobavljacID: 1,
    kategorijaID: 1
  };

  ngOnInit() {

    this.fetchSuplementi();
    this.fetchKateogorije();
    this.fetchDobavljaci();
  }

  Odaberi(x: SuplementGetAllResponseSuplement) {
    this.odabraniSuplement = {
      id: x.id,
      naziv: x.naziv,
      gramaza: x.gramaza,
      opis: x.opis,
      cijena: x.cijena,
      slika: x.slika,
      dobavljacID: x.dobavljacID,
      kategorijaID: x.kategorijaID
    } ;
  }


  GetFiltiraniSuplementi() {
    return this.suplementi.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.nazivKategorija.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) || x.nazivDobavljaca.toLowerCase().includes(this.PretragaNaziv.toLowerCase()) );
  }

  private fetchSuplementi() {
    this.SuplementiGetallEndpoint.Handle().subscribe((x:SuplementGetAllResponse )=>{
      this.suplementi = x.suplementi;
    });
  }

  private fetchKateogorije() {
    this.KategorijeGetAllEndpoint.Handle().subscribe((x:KategorijaGetAllResponse )=>{
      this.kategorije = x.kategorije;
    });
  }

  private fetchDobavljaci() {
    this.DobavljaciGetAllEndpoint.Handle().subscribe((x:DobavljacGetAllResponse )=>{
      this.dobavljaci = x.dobavljaci;
    });
  }

  Preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.noviSuplement!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  SaveNew() {
    this.SuplementAddEndpoint.Handle(this.noviSuplement).subscribe((x)=>{
      this.ngOnInit();
      this.prikaziAdd = false;
      this.noviSuplement.naziv ="";
      this.noviSuplement.cijena = 0;
      this.noviSuplement.gramaza =100;
      this.noviSuplement.opis ="";
      this.noviSuplement.slika ="";
      this.noviSuplement.dobavljacID =1;
      this.noviSuplement.kategorijaID =1;
    });

  }

  PreviewEdit() {
    // @ts-ignore
    var file = document.getElementById("slika-input-edit").files[0];
    if(file){
      var reader:FileReader = new FileReader();

      reader.onload = () =>{
        this.odabraniSuplement!.slika = reader.result?.toString();

      }
      reader.readAsDataURL(file);
    }
  }

  Save() {
    this.SuplementiEditEndpoint.Handle(this.odabraniSuplement!).subscribe((x)=>{
      this.fetchSuplementi();
      this.Close();
    });
  }

  Close() {
    this.odabraniSuplement = null
    this.prikaziAdd = false;
    this.ngOnInit();
  }
}
