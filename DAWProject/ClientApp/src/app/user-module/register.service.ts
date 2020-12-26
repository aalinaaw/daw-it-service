import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "./model/User";
import {UserService} from "./user.service";

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private readonly baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  registerUser(user: User) {
    return this.http.post( `${this.baseUrl}api/users`, user);
  }
}
