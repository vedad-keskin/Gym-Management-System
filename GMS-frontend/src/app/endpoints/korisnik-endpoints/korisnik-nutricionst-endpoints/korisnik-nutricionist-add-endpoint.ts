import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";


@Injectable({providedIn: 'root'})
export class Korisnik_NutricionistAddEndpoint implements  MyBaseEndpoint<Korisnik_NutricionistAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: Korisnik_NutricionistAddRequest): Observable<void> {
    let url=Config.adresa + `Korisnik_Nutricionist-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface Korisnik_NutricionistAddRequest {
  korisnikID: number
  nutricionistID: number
  datumTermina: string
  zakazanoSati: number
}

