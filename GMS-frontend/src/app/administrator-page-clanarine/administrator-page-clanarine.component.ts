import {Component, OnInit} from "@angular/core";
import {
  ClanarinaGetAllResponse,
  ClanarinaGetAllResponseClanarina,
  ClanarineGetallEndpoint
} from "../endpoints/clanarine-endpoints/clanarine-getall-endpoint";
import {ClanarineEditEndpoint, ClanarineEditRequest} from "../endpoints/clanarine-endpoints/clanarine-edit-endpoint";
import {
  ClanarinaAddEndpoint,
  ClanarinaAddRequest,
  ClanarinaAddResponse
} from "../endpoints/clanarine-endpoints/clanarina-add-endpoint";

@Component({
  selector: 'app-administrator-page-clanarine',
  templateUrl: './administrator-page-clanarine.component.html',
  styleUrls: ['./administrator-page-clanarine.component.css']
})
export class AdministratorPageClanarineComponent implements OnInit{

  constructor(private ClanarinegetAllEndpoint:ClanarineGetallEndpoint,
              private ClanarineEditEndpoint:ClanarineEditEndpoint,
              private ClanarinaAddEndpoint:ClanarinaAddEndpoint) {

  }
  clanarine: ClanarinaGetAllResponseClanarina[] = [];
  PretragaNaziv: string = "";
  public odabranaClanarina: ClanarineEditRequest | null = null;

  public prikaziAdd:boolean = false;
  public novaClanarina:ClanarinaAddRequest = {
    naziv: "",
    cijena: 50,
    opis: ""
  };

  ngOnInit():void {


    this.ClanarinegetAllEndpoint.Handle().subscribe((x:ClanarinaGetAllResponse )=>{
      this.clanarine = x.clanarine;
    })

  }


  GetFiltiraniSuplementi() {
    return this.clanarine.filter(x=> x.naziv.toLowerCase().includes(this.PretragaNaziv.toLowerCase()));
  }


  Odaberi(x: ClanarinaGetAllResponseClanarina) {
    this.odabranaClanarina = {
      id: x.id,
      naziv: x.naziv,
      cijena: x.cijena,
      opis:x.opis
    } ;
  }

  Save() {
    this.ClanarineEditEndpoint.Handle(this.odabranaClanarina!).subscribe((x)=>{
      this.ngOnInit();
      this.odabranaClanarina = null
    })
  }

  Close() {
    this.odabranaClanarina = null
    this.ngOnInit();
  }

  SaveNew() {
     this.ClanarinaAddEndpoint.Handle(this.novaClanarina).subscribe((x)=>{
       this.ngOnInit();
       this.prikaziAdd = false;
       this.novaClanarina.naziv ="";
       this.novaClanarina.opis ="";
       this.novaClanarina.cijena =50;
    })
  }
}
