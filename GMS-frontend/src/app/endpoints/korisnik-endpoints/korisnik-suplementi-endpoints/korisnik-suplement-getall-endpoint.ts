
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
@Injectable({providedIn: 'root'})
export class Korisnik_SuplementGetAllEndpoint implements MyBaseEndpoint<void, Korisnik_SuplementGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<Korisnik_SuplementGetAllResponse> {
    let url = Config.adresa + 'Korisnik_Suplement-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<Korisnik_SuplementGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface Korisnik_SuplementGetAllResponse{
  korisnikSuplement : Korisnik_SuplementGetAllResponseKorisnik_Suplement[];

}

export interface Korisnik_SuplementGetAllResponseKorisnik_Suplement {
  korisnikID: number
  imePrezime: string
  suplementID: number
  nazivSuplementa: string
  datumVrijemeNarudzbe: string
  kolicina: number
  cijena: number
  ukupno: number
  isporuceno: boolean
}
