import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";

@Injectable({providedIn: 'root'})
export class TrenerAddEndpoint implements  MyBaseEndpoint<TrenerAddRequest, void>{
  constructor(public httpClient:HttpClient) { }
  Handle(request: TrenerAddRequest): Observable<void> {
    let url=Config.adresa + `Trener-Add`;

    return this.httpClient.post<void>(url, request);
  }
}
export interface TrenerAddRequest {
  ime: string
  prezime: string
  brojTelefona: string
  slika: string | undefined
}

