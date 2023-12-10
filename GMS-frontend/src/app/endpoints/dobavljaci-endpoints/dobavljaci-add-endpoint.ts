import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class DobavljacAddEndpoint implements  MyBaseEndpoint<DobavljacAddRequest, DobavljacAddResponse>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: DobavljacAddRequest): Observable<DobavljacAddResponse> {
    let url=Config.adresa + `Dobavljac-Add`;

    return this.httpClient.post<DobavljacAddResponse>(url, request);
  }
}
export interface DobavljacAddRequest {
  naziv: string
}
export interface DobavljacAddResponse {
  id: number
  naziv: string
}
