import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class TeretanaGetAllEndpoint implements MyBaseEndpoint<void, TeretanaGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<TeretanaGetAllResponse> {
    let url = Config.adresa + 'Teretana-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<TeretanaGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface TeretanaGetAllResponse{
  teretane : TeretanaGetAllResponseTeretana[];

}

export interface TeretanaGetAllResponseTeretana {
  id: number
  naziv: string
  adresa: string
  nazivGrada: string
  gradID:number
}
