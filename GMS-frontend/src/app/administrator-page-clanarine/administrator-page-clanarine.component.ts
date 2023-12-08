import {Component, OnInit} from "@angular/core";
import {
  ClanarinaGetAllResponse,
  ClanarinaGetAllResponseClanarina,
  ClanarineGetallEndpoint
} from "../endpoints/clanarine-endpoints/clanarine-getall-endpoint";
import {HttpClient} from "@angular/common/http";
import {ClanarineEditEndpoint, ClanarineEditRequest} from "../endpoints/clanarine-endpoints/clanarine-edit-endpoint";

@Component({
  selector: 'app-administrator-page-clanarine',
  templateUrl: './administrator-page-clanarine.component.html',
  styleUrls: ['./administrator-page-clanarine.component.css']
})
export class AdministratorPageClanarineComponent implements OnInit{

  constructor(private ClanarinegetAllEndpoint:ClanarineGetallEndpoint,private ClanarineEditEndpoint:ClanarineEditEndpoint,public httpclient : HttpClient) {

  }
  clanarine: ClanarinaGetAllResponseClanarina[] = [];
  PretragaNaziv: string = "";
  public odabranaClanarina: ClanarineEditRequest | null = null;
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
}
