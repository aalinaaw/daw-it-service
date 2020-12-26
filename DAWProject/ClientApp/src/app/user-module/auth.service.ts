import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "./model/User";
import {BehaviorSubject, Observable} from "rxjs";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  private currentEmployeeSubject: BehaviorSubject<User>;
  public currentEmployee: Observable<User>;

  constructor(private http: HttpClient,
              @Inject('BASE_URL') private readonly baseUrl: string) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
    this.currentEmployeeSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentEmployee')));
    this.currentEmployee = this.currentEmployeeSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  public get currentEmployeeValue(): User {
    return this.currentEmployeeSubject.value;
  }

  loginUser(username: string, password: string) {
    return this.http.post<User>(`${this.baseUrl}api/authentication/authenticateUser`, { username, password })
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

  loginEmployee(username: string, password: string) {
    return this.http.post<User>(`${this.baseUrl}api/authentication/authenticateEmployee`, { username, password })
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentEmployee', JSON.stringify(user));
        this.currentEmployeeSubject.next(user);
        return user;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }

  logoutEmployee() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentEmployee');
    this.currentEmployeeSubject.next(null);
  }
}
