import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {AutentifikacijaToken} from "../login-page/AuthLoginResponse";

@Injectable({providedIn: 'root'})
export class MyAuthService{
  constructor(private httpClient: HttpClient) {
  }
  jelLogiran():boolean{
    let token = window.localStorage.getItem("my-auth-token");

    return token != "";
  }
  nijelLogiran():boolean{
    let token = window.localStorage.getItem("my-auth-token");

    return token == "";
  }


  getAuthorizationToken():AutentifikacijaToken | null {
    let tokenString = window.localStorage.getItem("my-auth-token")??"";
    try {
      return JSON.parse(tokenString);
    }
    catch (e){
      return null;
    }
  }
}
