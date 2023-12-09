import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class ClanarinaAddEndpoint implements  MyBaseEndpoint<ClanarinaAddRequest, ClanarinaAddResponse>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: ClanarinaAddRequest): Observable<ClanarinaAddResponse> {
    let url=Config.adresa + `Clanarina-Add`;

    return this.httpClient.post<ClanarinaAddResponse>(url, request);
  }
}
export interface ClanarinaAddRequest {
  naziv: string
  cijena: number
  opis: string
}
export interface ClanarinaAddResponse {
  id: number
  naziv: string
  cijena: number
  opis: string
}
