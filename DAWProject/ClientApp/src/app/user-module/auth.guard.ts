import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {AuthService} from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.authService.currentUserValue;
    let userNotLogged = false;
    let employeeIsNotLogged = false;
    if (currentUser) {
      // logged in so return true
      return true;
    } else {
      userNotLogged = true;
    }

    const currentEmployee = this.authService.currentEmployeeValue;
    if (currentEmployee) {
      // logged in so return true
      return true;
    } else {
      employeeIsNotLogged = true
    }

    if (employeeIsNotLogged) {
      this.router.navigate(['/login']);
    }

    if (userNotLogged) {
      this.router.navigate(['/login-employee']);
    }

    // not logged in so redirect to login page with the return url

    return false;
  }

}
