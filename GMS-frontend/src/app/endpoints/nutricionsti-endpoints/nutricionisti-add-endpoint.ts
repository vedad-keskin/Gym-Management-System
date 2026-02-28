import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class NutricionistAddEndpoint implements  MyBaseEndpoint<NutricionistAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: NutricionistAddRequest): Observable<void> {
    let url=Config.adresa + `Nutricionist-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface NutricionistAddRequest {
  ime: string
  prezime: string
  brojTelefona: string
  slika: string | undefined
}

