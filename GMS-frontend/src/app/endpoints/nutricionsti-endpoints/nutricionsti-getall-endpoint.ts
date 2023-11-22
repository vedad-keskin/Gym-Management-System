

import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class NutricionstiGetallEndpoint implements MyBaseEndpoint<void, NutricionstGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<NutricionstGetAllResponse> {
    let url = Config.adresa + 'Nutricionist-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<NutricionstGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}
export interface NutricionstGetAllResponse{
  nutricionisti : NutricionstGetAllResponseNutricionst[];
}

export interface NutricionstGetAllResponseNutricionst {
  id: number
  ime: string
  prezime: string
  brojTelefona: string
  slika: string
}
