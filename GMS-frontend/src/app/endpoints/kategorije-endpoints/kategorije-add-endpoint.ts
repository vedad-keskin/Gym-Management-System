import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class KategorijaAddEndpoint implements  MyBaseEndpoint<KategorijaAddRequest, KategorijaAddResponse>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: KategorijaAddRequest): Observable<KategorijaAddResponse> {
    let url=Config.adresa + `Kategorija-Add`;

    return this.httpClient.post<KategorijaAddResponse>(url, request);
  }
}
export interface KategorijaAddRequest {
  naziv: string
}
export interface KategorijaAddResponse {
  id: number
  naziv: string
}
