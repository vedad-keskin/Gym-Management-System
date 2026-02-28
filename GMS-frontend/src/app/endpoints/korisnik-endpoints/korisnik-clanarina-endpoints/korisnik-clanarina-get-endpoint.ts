import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
import {Config} from "../../../config";

@Injectable({providedIn: 'root'})
export class KorisnikClanarinaGetEndpoint implements  MyBaseEndpoint<number, KorisnikClanarinaGetResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(korisnikid: number): Observable<KorisnikClanarinaGetResponse> {
    let url=Config.adresa+`Korisnik-Clanarina-Get/${korisnikid}`;
    return this.httpClient.get<KorisnikClanarinaGetResponse>(url);
  }
}

export interface KorisnikClanarinaGetResponse {
  korisnikid: number,
  ime: string,
  prezime: string,
  uplaceneClanarine:KorisnikClanarineGetResponseUplaceneClanarine[]
}

export interface KorisnikClanarineGetResponseUplaceneClanarine{
  korisnikID: number,
  clanarinaID: number,
  datumUplate: Date,
  datumIsteka: Date | null,
  nazivClanarine: string,
  cijena:number
}
