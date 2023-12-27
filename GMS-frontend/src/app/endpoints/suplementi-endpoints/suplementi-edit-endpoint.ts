
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class SuplementiEditEndpoint implements  MyBaseEndpoint<SuplementiEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: SuplementiEditRequest): Observable<number> {
    let url=Config.adresa + `Suplement-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface SuplementiEditRequest {
  id: number
  naziv: string
  cijena: number
  gramaza: number
  opis: string
  slika: string | undefined
  dobavljacID: number
  kategorijaID: number
}

