import {Component, OnInit} from '@angular/core';
import {
  ClanarinaGetAllResponse,
  ClanarinaGetAllResponseClanarina,
  ClanarineGetallEndpoint
} from "../endpoints/clanarine-endpoints/clanarine-getall-endpoint";
import {
  RecenzijaGetAllResponse,
  RecenzijaGetAllResponseRecenzija,
  RecenzijeGetallEndpoint
} from "../endpoints/recenzije-endpoints/recenzije-getall-endpoint";

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit{

  constructor(private ClanarinegetAllEndpoint:ClanarineGetallEndpoint, private RecenzijegetAllEndpoint:RecenzijeGetallEndpoint) {

  }
  clanarine: ClanarinaGetAllResponseClanarina[] = [];
  recenzije: RecenzijaGetAllResponseRecenzija[] = [];
  ngOnInit():void {


    this.ClanarinegetAllEndpoint.Handle().subscribe((x:ClanarinaGetAllResponse )=>{
      this.clanarine = x.clanarine;
    })
    this.RecenzijegetAllEndpoint.Handle().subscribe((x:RecenzijaGetAllResponse )=>{
      this.recenzije = x.recenzije;
    })


  }



}
