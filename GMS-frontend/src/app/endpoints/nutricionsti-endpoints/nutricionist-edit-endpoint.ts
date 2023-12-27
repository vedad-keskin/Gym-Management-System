
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class NutricionistiEditEndpoint implements  MyBaseEndpoint<NutricionistiEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: NutricionistiEditRequest): Observable<number> {
    let url=Config.adresa + `Nutricionist-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface NutricionistiEditRequest {
  id: number
  ime: string
  prezime: string
  brojTelefona: string
  slika: string | undefined
}

