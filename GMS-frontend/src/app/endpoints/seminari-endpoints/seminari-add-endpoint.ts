import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class SeminarAddEndpoint implements  MyBaseEndpoint<SeminarAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: SeminarAddRequest): Observable<void> {
    let url=Config.adresa + `Seminar-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface SeminarAddRequest {
  predavac: string
  datum: string
  tema: string
}

