import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
import {Config} from "../../../config";
@Injectable({providedIn: 'root'})
export class Korisnik_NutricionistGetAllEndpoint implements MyBaseEndpoint<void, Korisnik_NutricionistGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<Korisnik_NutricionistGetAllResponse> {
    let url = Config.adresa + 'Korisnik_Nutricionist-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<Korisnik_NutricionistGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface Korisnik_NutricionistGetAllResponse{
  korisnikNutricionist : Korisnik_NutricionistGetAllResponseKorisnik_Nutricionist[];

}

export interface Korisnik_NutricionistGetAllResponseKorisnik_Nutricionist {
  korisnikID: number
  nutricionistID: number
  zakazanoSati: number
  datumTermina: string
  nazivNutricioniste: string

}
