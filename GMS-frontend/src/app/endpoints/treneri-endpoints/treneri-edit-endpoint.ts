
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Config} from "../../config";
import {Observable} from "rxjs";
@Injectable({providedIn: 'root'})
export class TreneriEditEndpoint implements  MyBaseEndpoint<TreneriEditRequest, number>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: TreneriEditRequest): Observable<number> {
    let url=Config.adresa + `Trener-Edit`;

    return this.httpClient.post<number>(url, request);
  }

}
export interface TreneriEditRequest {
  id: number
  ime: string
  prezime: string
  brojTelefona: string
  slika: string | undefined
}

