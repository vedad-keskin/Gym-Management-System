
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class KategorijeEditEndpoint implements  MyBaseEndpoint<KategorijeEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: KategorijeEditRequest): Observable<number> {
    let url=Config.adresa + `Kategorija-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface KategorijeEditRequest {
  id: number
  naziv: string
}

