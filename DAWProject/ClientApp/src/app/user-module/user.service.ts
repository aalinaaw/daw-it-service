import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {UserType} from "./model/User";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private readonly baseUrl: string) {}

  public getUserTypes() {
    return this.http.get<Array<UserType>>( `${this.baseUrl}api/users/types`);
  }
}
