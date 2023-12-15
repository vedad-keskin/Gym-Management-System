import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class TeretanaAddEndpoint implements  MyBaseEndpoint<TeretanaAddRequest, TeretanaAddResponse>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: TeretanaAddRequest): Observable<TeretanaAddResponse> {
    let url=Config.adresa + `Teretana-Add`;

    return this.httpClient.post<TeretanaAddResponse>(url, request);
  }
}
export interface TeretanaAddRequest {
  naziv: string
  gradID: number
  adresa: string
}
export interface TeretanaAddResponse {
  id: number
  naziv: string
  gradID: number
  adresa: string
}
