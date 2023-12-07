import {Component, OnInit} from "@angular/core";
import {
  DobavljaciGetallEndpoint,
  DobavljaciGetAllResponse, DobavljaciGetAllResponseDobavljaci
} from "../endpoints/dobavljaci-endpoints/dobavljaci-endpoint";



@Component({
  selector: 'app-administrator-page-dobavljaci',
  templateUrl: './administrator-page-dobavljaci.component.html',
  styleUrls: ['./administrator-page-dobavljaci.component.css']
})
export class AdministratorPageDobavljaciComponent implements OnInit {

  constructor(private DobavljacigetAllEndpoint: DobavljaciGetallEndpoint) {

  }

  dobavljaci: DobavljaciGetAllResponseDobavljaci[] = [];

  ngOnInit(): void {


    this.DobavljacigetAllEndpoint.Handle().subscribe((x: DobavljaciGetAllResponse) => {
      this.dobavljaci = x.dobavljaci;
    })


  }
}
