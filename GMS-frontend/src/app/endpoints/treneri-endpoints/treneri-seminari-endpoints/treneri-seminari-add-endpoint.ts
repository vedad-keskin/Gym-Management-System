import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";


@Injectable({providedIn: 'root'})
export class TrenerSeminarAddEndpoint implements  MyBaseEndpoint<TrenerSeminarAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: TrenerSeminarAddRequest): Observable<void> {
    let url=Config.adresa + `Trener_Seminar-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface TrenerSeminarAddRequest {
  trenerID: number
  seminarID: number

}

