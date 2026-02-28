import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";


@Injectable({providedIn: 'root'})
export class Korisnik_TrenerAddEndpoint implements  MyBaseEndpoint<Korisnik_TrenerAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: Korisnik_TrenerAddRequest): Observable<void> {
    let url=Config.adresa + `Korisnik_Trener-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface Korisnik_TrenerAddRequest {
  korisnikID: number
  trenerID: number
  datumTermina: string
  zakazanoSati: number
}

