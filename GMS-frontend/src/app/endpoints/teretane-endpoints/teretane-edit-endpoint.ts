
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class TeretaneEditEndpoint implements  MyBaseEndpoint<TeretaneEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: TeretaneEditRequest): Observable<number> {
    let url=Config.adresa + `Teretana-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface TeretaneEditRequest {
  id: number
  naziv: string
  gradID: number
  adresa: string
}

