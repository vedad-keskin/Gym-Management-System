import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ClanarineGetallEndpoint implements MyBaseEndpoint<void, ClanarinaGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<ClanarinaGetAllResponse> {
    let url = Config.adresa + 'Clanarina-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<ClanarinaGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface ClanarinaGetAllResponse{
  clanarine : ClanarinaGetAllResponseClanarina[];

}

export interface ClanarinaGetAllResponseClanarina {
  id : number
  naziv: string
  cijena: number
  opis: string

}
