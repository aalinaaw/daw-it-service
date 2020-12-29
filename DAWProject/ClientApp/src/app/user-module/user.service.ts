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

  createUserType(userType: UserType) {
    return this.http.post( `${this.baseUrl}api/users/types`, userType);
  }

  updateUserType(userType: UserType) {
    return this.http.put( `${this.baseUrl}api/users/types`, userType);
  }

  deleteUserType(id: string) {
    return this.http.delete( `${this.baseUrl}api/users/types/${id}`);
  }
}
