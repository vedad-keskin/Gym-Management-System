import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../../config";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";


@Injectable({providedIn: 'root'})
export class NutricionistSeminarAddEndpoint implements  MyBaseEndpoint<NutricionistSeminarAddRequest, NutricionistSeminarAddResponse>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: NutricionistSeminarAddRequest): Observable<NutricionistSeminarAddResponse> {
    let url=Config.adresa + `Nutricionist_Seminar-Add`;

    return this.httpClient.post<NutricionistSeminarAddResponse>(url, request);
  }
}
export interface NutricionistSeminarAddRequest {
  nutricionistID: number
  seminarID: number

}
export interface NutricionistSeminarAddResponse {
  nutricionistID: number
}
