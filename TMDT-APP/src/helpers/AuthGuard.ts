import { Injectable, OnDestroy } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from 'src/services/authentication.service';
import { RaiseAlertService } from 'src/services/raise-alert.service';
import { SharedService } from 'src/services/shared.service';
@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate, OnDestroy {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private raiseAlertService: RaiseAlertService,
        private shared: SharedService
    ) { }
    ngOnDestroy(): void {
    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.currentUserValue;
        let url: any;
        if (currentUser != null) {
            // if logged, check if token expired and return false
            if (this.tokenExpired(this.authenticationService.currentUserValue.token)) {
                this.authenticationService.logout();
                this.router.navigate(['/admin/login'], { queryParams: { returnUrl: state.url } });
                this.raiseAlertService.raiseAlert("error","Oppss...","Your session is expired. Please login again");
                console.warn("token");
                return false;
            } 
            else
                return this.shared.checkAuthorization(this.authenticationService.currentUserValue.roleId, state.url);
              
        }
        else{
            // not logged in so redirect to login page with the return url
            console.warn("loggout");
            this.authenticationService.logout();
            this.router.navigate(['/admin/login'], { queryParams: { returnUrl: state.url } });
            return false;
        }
    }
    private tokenExpired(token: string) {
        const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
        return (Math.floor((new Date).getTime() / 1000)) >= expiry;
    }
}