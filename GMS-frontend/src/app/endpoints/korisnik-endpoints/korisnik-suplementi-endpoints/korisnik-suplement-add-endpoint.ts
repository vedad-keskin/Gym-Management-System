import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
import {Injectable} from "@angular/core";


@Injectable({providedIn: 'root'})
export class Korisnik_SuplementAddEndpoint implements  MyBaseEndpoint<Korisnik_SuplementAddRequest, Korisnik_SuplementAddResponse>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: Korisnik_SuplementAddRequest): Observable<Korisnik_SuplementAddResponse> {
    let url=Config.adresa + `Korisnik_Suplement-Add`;

    return this.httpClient.post<Korisnik_SuplementAddResponse>(url, request);
  }
}
export interface Korisnik_SuplementAddRequest {
  korisnikID: number
  suplementID: number
  datumVrijemeNarudzbe: Date
  kolicina: number
  isporuceno: boolean
}
export interface Korisnik_SuplementAddResponse {
  korisnikID: number
  suplementID: number
  datumVrijemeNarudzbe: Date
  kolicina: number
  isporuceno: boolean
}
