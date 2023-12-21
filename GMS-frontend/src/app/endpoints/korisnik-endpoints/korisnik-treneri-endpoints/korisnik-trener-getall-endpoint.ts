import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
import {Config} from "../../../config";
@Injectable({providedIn: 'root'})
export class Korisnik_TrenerGetAllEndpoint implements MyBaseEndpoint<void, Korisnik_TrenerGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<Korisnik_TrenerGetAllResponse> {
    let url = Config.adresa + 'Korisnik_Trener-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<Korisnik_TrenerGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface Korisnik_TrenerGetAllResponse{
  korisnikTrener : Korisnik_TrenerGetAllResponseKorisnik_Trener[];

}

export interface Korisnik_TrenerGetAllResponseKorisnik_Trener {
  korisnikID: number
  trenerID: number
  zakazanoSati: number
  datumiVrijemeOdrzavanja: string
  nazivTrenera: string

}
