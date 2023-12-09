import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class GradAddEndpoint implements  MyBaseEndpoint<GradAddRequest, GradAddResponse>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: GradAddRequest): Observable<GradAddResponse> {
    let url=Config.adresa + `Grad-Add`;

    return this.httpClient.post<GradAddResponse>(url, request);
  }
}
export interface GradAddRequest {
  naziv: string
}
export interface GradAddResponse {
  id: number
  naziv: string
}
