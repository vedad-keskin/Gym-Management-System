import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class SuplementiGetallEndpoint implements MyBaseEndpoint<void, SuplementGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<SuplementGetAllResponse> {
    let url = Config.adresa + 'Suplement-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<SuplementGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface SuplementGetAllResponse{
  suplementi : SuplementGetAllResponseSuplement[];
}
export interface SuplementGetAllResponseSuplement {
  id: number
  naziv: string
  cijena: number
  gramaza: number
  opis: string
  slika: string
  nazivDobavljaca: string
  nazivKategorija: string
}




