import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";


@Injectable({providedIn: 'root'})
export class Korisnik_ClanarinaAddEndpoint implements  MyBaseEndpoint<Korisnik_ClanarinaAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: Korisnik_ClanarinaAddRequest): Observable<void> {
    let url=Config.adresa + `Korisnik_Clanarina-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface Korisnik_ClanarinaAddRequest {
  korisnikID: number
  clanarinaID: number
  datumUplate: string
  datumIsteka: string
}

