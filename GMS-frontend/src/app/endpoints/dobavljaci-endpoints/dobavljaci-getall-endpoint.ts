import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class DobavljaciGetAllEndpoint implements MyBaseEndpoint<void, DobavljacGetAllResponse>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<DobavljacGetAllResponse> {
    let url = Config.adresa + 'Dobavljac-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<DobavljacGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}

export interface DobavljacGetAllResponse{
  dobavljaci : DobavljacGetAllResponseDobavljaci[];

}

export interface DobavljacGetAllResponseDobavljaci {
  id: number
  naziv: string

}
