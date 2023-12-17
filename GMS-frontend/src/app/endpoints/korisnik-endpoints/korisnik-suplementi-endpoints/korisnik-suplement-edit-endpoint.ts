
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
import {Config} from "../../../config";
@Injectable({providedIn: 'root'})
export class Korisnik_SuplementEditEndpoint implements  MyBaseEndpoint<Korisnik_SuplementEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: Korisnik_SuplementEditRequest): Observable<number> {
    let url= Config.adresa + `Korisnik_Suplement-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface Korisnik_SuplementEditRequest {
  korisnikID: number
  suplementID: number
  datumVrijemeNarudzbe: string
  kolicina: number
  isporuceno: boolean
}

