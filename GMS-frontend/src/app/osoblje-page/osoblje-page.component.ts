import {Component, OnInit} from '@angular/core';
import {
  TrenerGetallEndpoint,
  TrenerGetAllResponse,
  TrenerGetAllResponseTrener
} from "../endpoints/treneri-endpoints/treneri-getall-endpoint";
import {
  NutricionstGetAllResponse,
  NutricionstGetAllResponseNutricionst,
  NutricionstiGetallEndpoint
} from "../endpoints/nutricionsti-endpoints/nutricionsti-getall-endpoint";

@Component({
  selector: 'app-osoblje-page',
  templateUrl: './osoblje-page.component.html',
  styleUrls: ['./osoblje-page.component.css']
})
export class OsobljePageComponent implements OnInit{

  constructor(private TrenergetAllEndpoint:TrenerGetallEndpoint, private NutricionstgetAllEndpoint:NutricionstiGetallEndpoint) {

  }
  treneri: TrenerGetAllResponseTrener[] = [];
  nutricionsti : NutricionstGetAllResponseNutricionst[] = [];

  ngOnInit():void {



    this.TrenergetAllEndpoint.Handle().subscribe((x:TrenerGetAllResponse )=>{
      this.treneri = x.treneri;
    })

    this.NutricionstgetAllEndpoint.Handle().subscribe((x:NutricionstGetAllResponse )=>{
      this.nutricionsti = x.nutricionisti;
    })






  }
}
