import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Config} from "../../config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class SmsSendEndpoint implements MyBaseEndpoint<void, void>{
  constructor(public httpClient:HttpClient) { }

  Handle(request: void): Observable<void> {
    let url = Config.adresa + 'TwilioMess';

    let token = window.localStorage.getItem("my-auth-token")??"";

    return this.httpClient.get<void>(url , {
      headers:{
        "my-auth-token": token
      }
    });
  }
}



