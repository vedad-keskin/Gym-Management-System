import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class SeminariGetAllEndpoint implements MyBaseEndpoint<void, SeminarGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<SeminarGetAllResponse> {
    let url = Config.adresa + 'Seminar-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<SeminarGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface SeminarGetAllResponse{
  seminari : SeminarGetAllResponseSeminari[];
}

export interface SeminarGetAllResponseSeminari {
  id: number
  predavac: string
  datum: string
  tema: string
}

