import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class KategorijeGetAllEndpoint implements MyBaseEndpoint<void, KategorijaGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<KategorijaGetAllResponse> {
    let url = Config.adresa + 'Kategorija-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<KategorijaGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface KategorijaGetAllResponse{
  kategorije : KategorijaGetAllResponseKategorija[];

}

export interface KategorijaGetAllResponseKategorija {
  id: number
  naziv: string

}
