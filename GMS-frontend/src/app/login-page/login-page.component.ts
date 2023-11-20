import { Component } from '@angular/core';
import {AuthenticationLoginRequest} from "./AuthenticationLoginRequest";
import {config} from "rxjs";
import {Config} from "../config";
import {HttpClient} from "@angular/common/http";
import {AuthLoginResponse} from "./AuthLoginResponse";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {

  constructor(public httpclient : HttpClient, private router : Router) {

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
        let token = x.autentifikacijaToken.vrijednost;
        window.localStorage.setItem("my-auth-token",token)
        this.router.navigate(['/HomePage']);
        alert("Uspješno ste se prijavili");
      }
    })
  }
}
