import {Component, OnInit} from '@angular/core';
import {
  GradoviGetallEndpoint,
  GradGetAllResponse,
  GradGetAllResponseGrad
} from "../endpoints/gradovi-endpoints/gradovi-getall-endpoint";

@Component({
  selector: 'app-administrator-page-gradovi',
  templateUrl: './administrator-page-gradovi.component.html',
  styleUrls: ['./administrator-page-gradovi.component.css']
})
export class AdministratorPageGradoviComponent implements OnInit{

  constructor(private GradgetAllEndpoint:GradoviGetallEndpoint) {

  }
  gradovi: GradGetAllResponseGrad[] = [];
  ngOnInit():void {

    this.GradgetAllEndpoint.Handle().subscribe((x:GradGetAllResponse )=>{
      this.gradovi = x.gradovi;
    })

  }

}
