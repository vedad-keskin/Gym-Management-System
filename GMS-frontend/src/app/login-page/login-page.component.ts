import { Component } from '@angular/core';
import {AuthenticationLoginRequest} from "./AuthenticationLoginRequest";
import {config} from "rxjs";
import {Config} from "../config";
import {HttpClient} from "@angular/common/http";
import {AuthLoginResponse} from "./AuthLoginResponse";
import {Router} from "@angular/router";
import {MyAuthService} from "../services/MyAuthService";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {

  constructor(public httpclient : HttpClient,
              private router : Router,
              private myAuthService: MyAuthService
              ) {

  }


  public LoginRequest : AuthenticationLoginRequest = {
    password :"",
    username:""
  };
  SignIn() {
    let url = Config.adresa + 'Autentifikacija/Login';
    this.httpclient.post<AuthLoginResponse>(url, this.LoginRequest).subscribe((x)=>{
      if (!x.isLogiran){
        alert("Unijeli ste pogrešno korisničko ime ili lozinku");
      }
      else{


        this.myAuthService.setLogiraniKorisnik(x.autentifikacijaToken);
        if(this.myAuthService.isKorisnik()){
          this.router.navigate(['KorisnikPage']);
        }
        else{
          this.router.navigate(['AdministratorPage']);
        }


      }
    })
  }
}
