
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class ClanarineEditEndpoint implements  MyBaseEndpoint<ClanarineEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: ClanarineEditRequest): Observable<number> {
    let url=Config.adresa + `Clanarina-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface ClanarineEditRequest {
  id: number
  naziv: string
  cijena: number
  opis: string
}

