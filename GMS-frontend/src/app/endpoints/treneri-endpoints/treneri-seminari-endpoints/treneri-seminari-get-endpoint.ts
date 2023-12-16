
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
import {Config} from "../../../config";
import {HttpClient} from "@angular/common/http";

@Injectable({providedIn: 'root'})
export class TrenerSeminarGetEndpoint implements  MyBaseEndpoint<number, TrenerSeminarGetResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(korisnikid: number): Observable<TrenerSeminarGetResponse> {
    let url=Config.adresa+`Trener-Seminar-Get/${korisnikid}`;
    return this.httpClient.get<TrenerSeminarGetResponse>(url);
  }
}

export interface TrenerSeminarGetResponse {
  trenerID: number,
  ime: string,
  prezime: string,
  odrzanSeminar:TrenerSeminarGetResponseSeminar[]
}

export interface TrenerSeminarGetResponseSeminar{
  trenerID: number,
  seminarID: number,
  tema: string,
  predavac: string,
  datum: Date
}
