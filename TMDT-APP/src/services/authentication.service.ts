import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttprequestService } from './http-request.service';
import { ICredential, IRole, IUSer } from './interface.service';
import { Router } from '@angular/router';
import { BreadCrumbService } from './breadcrumb.service';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<IUSer>;
    public currentUser!: Observable<IUSer>;

    public roleArr: IRole[] = [
        {
            "roleNo": "1",
            "roleName": "SuperUser"
        },
        {
            "roleNo": "2",
            "roleName": "Sales"
        },
        {
            "roleNo": "3",
            "roleName": "Finance"
        }
    ];
    public loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    public loggedOut: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);
    public currentUserRole: BehaviorSubject<string> = new BehaviorSubject<string>("");

    private errorCode!: BehaviorSubject<string>;
    public sharedErrorCode!: Observable<string>;

    constructor(private router: Router,
        private http: HttpClient,
        private shared: HttprequestService,
        private breadCrumbService: BreadCrumbService) {
        this.currentUserSubject = new BehaviorSubject<IUSer>(JSON.parse(localStorage.getItem('currentUser')!));
        this.currentUser = this.currentUserSubject.asObservable();
        this.errorCode = new BehaviorSubject<string>(JSON.parse(localStorage.getItem('errorStatus')!));
        this.sharedErrorCode = this.errorCode.asObservable()
        if (this.currentUserValue) {
            this.currentUserRole.next(this.currentUserValue.roleId);
            this.breadCrumbService.nextSession("Hi, " + this.currentUserValue.roleName + "/" + this.currentUserValue.userName + "!");
            this.loggedIn.next(true);
            this.loggedOut.next(false);
        }
        else {
            this.loggedOut.next(true);
            this.loggedIn.next(false);
        }
    }


    public nextErrorCode(val: string) {
        this.errorCode.next(val);
    }

    public get currentErrorCode(): string {
        return this.errorCode.value;
    }
    public get getListRole(): IRole[] {
        return this.roleArr;
    }
    /*nextErrorCode(val:number){
        this.errorCode.next(val);
    }*/
    public nextUserValue(val: IUSer) {
        this.currentUserSubject.next(val);
    }
    public get currentUserValue(): IUSer {
        return this.currentUserSubject.value;
    }

    login(cre: ICredential) {
        return this.shared.post("/Login/", cre)
            .pipe(map(data => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                if (data.status == 200) {
                    localStorage.setItem('currentUser', JSON.stringify(data.data));
                    this.currentUserSubject.next(data.data);
                    this.loggedIn.next(true);
                    this.loggedOut.next(false);
                    this.currentUserRole.next(data.data.roleId);
                    this.breadCrumbService.nextSession("Hi, " + this.currentUserValue.roleName + "/" + this.currentUserValue.userName + "!");
                    return data;
                }
                else {
                    return data;
                }
            }));
    }
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.loggedIn.next(false);
        this.loggedOut.next(true);
        this.currentUserSubject.next(null!);
        this.currentUserRole.next("");
        this.breadCrumbService.nextBreadCrumb("");
        this.breadCrumbService.nextSession("");
        this.router.navigate(['/admin/login'], { queryParams: { returnUrl: "" } });
    }
}