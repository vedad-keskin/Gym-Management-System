
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../../MyBaseEndpoint";
import {Config} from "../../../config";
import {HttpClient} from "@angular/common/http";

@Injectable({providedIn: 'root'})
export class NutricionistSeminarGetEndpoint implements  MyBaseEndpoint<number, NutricionistSeminarGetResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(korisnikid: number): Observable<NutricionistSeminarGetResponse> {
    let url=Config.adresa+`Nutricionist-Seminar-Get/${korisnikid}`;
    return this.httpClient.get<NutricionistSeminarGetResponse>(url);
  }
}

export interface NutricionistSeminarGetResponse {
  nutricionstID: number,
  ime: string,
  prezime: string,
  prisustvoSeminaru:NutricionistSeminarGetResponseNutricionst[]
}

export interface NutricionistSeminarGetResponseNutricionst{
  nutricionstID: number,
  seminarID: number,
  tema: string,
  predavac: string,
  datum: Date
}
