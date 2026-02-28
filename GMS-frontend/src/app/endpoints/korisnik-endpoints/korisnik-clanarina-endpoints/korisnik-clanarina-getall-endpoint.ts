
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
@Injectable({providedIn: 'root'})
export class Korisnik_ClanarinaGetAllEndpoint implements MyBaseEndpoint<void, Korisnik_ClanarinaGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<Korisnik_ClanarinaGetAllResponse> {
    let url = Config.adresa + 'Korisnik_Clanarina-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<Korisnik_ClanarinaGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface Korisnik_ClanarinaGetAllResponse{
  korisnik_Clanarina : Korisnik_ClanarinaGetAllResponseKorisnikClanarina[];

}

export interface Korisnik_ClanarinaGetAllResponseKorisnikClanarina {
  korisnikID: number,
  clanarinaID: number,
  datumUplate: Date,
  datumIsteka: Date | null,
  nazivClanarine: string
}
