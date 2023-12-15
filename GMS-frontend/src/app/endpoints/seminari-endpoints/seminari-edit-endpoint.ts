
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class SeminariEditEndpoint implements  MyBaseEndpoint<SeminariEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: SeminariEditRequest): Observable<number> {
    let url=Config.adresa + `Seminar-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface SeminariEditRequest {
  id: number
  tema: string
  predavac: string
  datum: string
}

