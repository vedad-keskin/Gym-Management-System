

import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class TrenerGetallEndpoint implements MyBaseEndpoint<void, TrenerGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<TrenerGetAllResponse> {
    let url = Config.adresa + 'Trener-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<TrenerGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}
export interface TrenerGetAllResponse{
  treneri : TrenerGetAllResponseTrener[];
}

export interface TrenerGetAllResponseTrener {
  id: number
  ime: string
  prezime: string
  brojTelefona: string
  slika: string
}
