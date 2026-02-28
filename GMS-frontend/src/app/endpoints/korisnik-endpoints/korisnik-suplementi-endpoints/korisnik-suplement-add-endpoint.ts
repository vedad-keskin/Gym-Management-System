import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
import {Injectable} from "@angular/core";


@Injectable({providedIn: 'root'})
export class Korisnik_SuplementAddEndpoint implements  MyBaseEndpoint<Korisnik_SuplementAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: Korisnik_SuplementAddRequest): Observable<void> {
    let url=Config.adresa + `Korisnik_Suplement-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface Korisnik_SuplementAddRequest {
  korisnikID: number
  suplementID: number
  kolicina: number
  isporuceno: boolean
}

