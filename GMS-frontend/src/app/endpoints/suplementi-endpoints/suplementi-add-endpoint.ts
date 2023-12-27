import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class SuplementAddEndpoint implements  MyBaseEndpoint<SuplementAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: SuplementAddRequest): Observable<void> {
    let url=Config.adresa + `Suplement-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface SuplementAddRequest {
  naziv: string
  cijena: number
  gramaza: number
  opis: string
  slika: string | undefined
  dobavljacID: number
  kategorijaID: number
}

