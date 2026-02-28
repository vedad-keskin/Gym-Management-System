
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class DobavljaciEditEndpoint implements  MyBaseEndpoint<DobavljaciEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: DobavljaciEditRequest): Observable<number> {
    let url=Config.adresa + `Dobavljac-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface DobavljaciEditRequest {
  id: number
  naziv: string
}

