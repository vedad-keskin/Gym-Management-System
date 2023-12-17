import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";


@Injectable({providedIn: 'root'})
export class Korisnik_TrenerAddEndpoint implements  MyBaseEndpoint<Korisnik_TrenerAddRequest, Korisnik_TrenerAddResponse>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: Korisnik_TrenerAddRequest): Observable<Korisnik_TrenerAddResponse> {
    let url=Config.adresa + `Korisnik_Trener-Add`;

    return this.httpClient.post<Korisnik_TrenerAddResponse>(url, request);
  }
}
export interface Korisnik_TrenerAddRequest {
  korisnikID: number
  trenerID: number
  datumTermina: string
  zakazanoSati: number
}
export interface Korisnik_TrenerAddResponse {
  korisnikID: number
  trenerID: number
  datumTermina: string
  zakazanoSati: number
}
