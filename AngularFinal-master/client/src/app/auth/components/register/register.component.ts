import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { ApiService } from '../../../services/api.service';
import { IUser } from '../../../shared/models/product.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  customerName = '';
  customerAddress = '';
  phoneNumber = '';
  email = '';
  passWord = '';
  confirmPassword = '';
  errorMessage = '';
  loading = false;
  user:IUser = {
    customerNo : "",
    customerName : "",
    customerAddress: "",
    phoneNumber : "",
    email: "",
    passWord: "",
  }

  constructor(
    private _api: ApiService,
    private _auth: AuthService,
    private _router: Router
  ) {}
  ngOnInit(): void {
    //this.user: IUser;
  }

  onSubmit(): void {
    this.errorMessage = '';
    if (this.customerName && this.customerAddress && this.phoneNumber && this.email && this.passWord && this.confirmPassword) {
      if (this.passWord !== this.confirmPassword) {
        this.errorMessage = 'Mật khẩu phải giống nhau';
      } else {
        this.user.customerNo = " ";
        this.user.customerName = this.customerName,
        this.user.customerAddress = this.customerAddress,
        this.user.phoneNumber = this.phoneNumber
        this.user.email =this.email
        this.user.passWord = this.passWord,
        this.loading = true;
        this._api.postTypeRequest("/Customer",this.user)
          .subscribe(
            (res) => {
              console.log(res);
              this.loading = false;
              this._api.riseAlert("Đăng ký thành công!","Vui lòng đăng nhập bằng tài khoản vừa đăng ký");
              this._router.navigate(['/login']);
            },
            (err) => {
              this.errorMessage = "Có lỗi phát sinh, vui lòng thử lại sau";
              this.loading = false;
            }
          );
      }
    } else {
      this.errorMessage = 'Vui lòng điền tất cả các mục ;)';
    }
  }

  canSubmit(): boolean {
    return this.customerName && this.customerAddress && this.phoneNumber && this.email && this.passWord && this.confirmPassword
      ? true
      : false;
  }
}
