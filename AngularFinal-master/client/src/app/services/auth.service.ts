import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { ApiService } from './api.service';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private userSubject: BehaviorSubject<any>;
  public user: Observable<any>;

  constructor(private _api: ApiService, private _token: TokenStorageService) {
    this.userSubject = new BehaviorSubject<any>(this._token.getUser());
    this.user = this.userSubject.asObservable();
  }

  getUser() {
    console.log(this.userSubject);
    console.log(this.userSubject.value);
    return this.userSubject.value;
  }

  login(credentials: any): Observable<any> {
    return this._api
      .postTypeRequest('/Login', {
        email: credentials.email,
        password: credentials.password,
        type: false
      })
      .pipe(
        map((res: any) => {   
          if(res.status === 200)
          {
            let user = {
              id: res.data.id,
              userName: res.data.userName,
              typeUser: res.data.typeUser,
              roleId: res.data.roleId,
              roleName: res.data.roleName,
              token: res.data.token,
            };
            this._token.setToken(res.data.token);
            this._token.setUser(res.data);
            console.log(res);
            this.userSubject.next(user);
            return user;
          }      
          else{
            return null;
          }
        })
      );
  }

  register(user: any): Observable<any> {
    return this._api.postTypeRequest('auth/register', {
      fullName: user.fullName,
      email: user.email,
      password: user.password,
    });
  }

  logout() {
    this._token.clearStorage();
    this.userSubject.next(null);
  }
}
