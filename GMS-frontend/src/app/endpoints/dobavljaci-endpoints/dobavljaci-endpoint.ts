import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {HttpClient} from "@angular/common/http";

@Injectable({providedIn: 'root'})

export class DobavljaciGetallEndpoint implements MyBaseEndpoint<void, DobavljaciGetAllResponse> {


  constructor(public httpClient:HttpClient) { }
  Handle(request: void): Observable<DobavljaciGetAllResponse> {

    let url = Config.adresa + 'Dobavljac-GetAll';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<DobavljaciGetAllResponse>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }


}

export interface DobavljaciGetAllResponse{
  dobavljaci : DobavljaciGetAllResponseDobavljaci[];
}

export interface DobavljaciGetAllResponseDobavljaci{
  id : number
  naziv: string
}
