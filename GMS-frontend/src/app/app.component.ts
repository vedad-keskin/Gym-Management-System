import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Config} from "./config";
import { Router} from "@angular/router";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  constructor(public router:Router) {

  }

  ngOnInit():void {
    this.router.navigate(['/HomePage']);
  }

}
