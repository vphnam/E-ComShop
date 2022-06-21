import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { TokenStorageService } from '../services/token-storage.service';
import Swal from 'sweetalert2';
import { timer } from 'rxjs';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  profile = new FormGroup({
    customerNo: new FormControl({value:null, disabled:true}),
    customerName: new FormControl(null, [Validators.required]),
    customerAddress: new FormControl(null, [Validators.required]),
    email: new FormControl({value:null,disabled:true}),
    phoneNumber: new FormControl(null, [Validators.required]),
    oldPassWord: new FormControl(null, [Validators.required]),
    passWord: new FormControl(null, [Validators.required]),
    confirmPassWord: new FormControl(null, [Validators.required]),
  });
  userId = null;
  alertMessage = '';
  alertType = '';
  alertVisible = false;
  loading = false;

  constructor(
    private _api: ApiService,
    private _token: TokenStorageService,
    private _router: Router
  ) {
    this.refreshProfile();
  }
  refreshProfile(){
    this.profile.reset();
    const currentUser = this._token.getUser();
    this._api.getTypeRequest("/Customer/GetByNo?no=" + currentUser.customerNo).subscribe((data:any) =>{
      this.profile.patchValue(data.data);
    });
  }
  // Update user fields with current details
  ngOnInit(): void {
  }
  update(){
    Swal.fire({
      title: 'Do you want to update your profiles?',
      showDenyButton: true,
      confirmButtonText: 'Yes, update my profiles',
      denyButtonText: "No",
    }).then((result) => {
      /* Read more about isConfirmed, isDenied below */
      if (result.isConfirmed) {
        if(this.profile.get('passWord').value == this.profile.get('confirmPassWord').value){
          console.warn(this.profile.value);
            this._api.postTypeRequest("/Customer/update",this.profile.getRawValue()).subscribe(data => {
              if(data.status == 200)
              {
                this.alertVisible = false;
                this.refreshProfile();
                Swal.fire("Success","Update profile successfully",'success');
              }
              else
              {
                this.alertMessage = data.data;
                this.alertType = 'error';
                this.alertVisible = true;
              }
            })
        }
        else
          {
            this.alertMessage = "Password and confirm password is not the same";
      this.alertType = 'error';
      this.alertVisible = true;
          }
      } else if (result.isDenied) {

      }
    })
  }
  checkValidOnType(){
    if(this.profile.get('passWord').value != this.profile.get('confirmPassWord').value){
      this.alertMessage = "Password and confirm password is not the same";
      this.alertType = 'error';
      this.alertVisible = true;
    }
    else
    {
      this.alertMessage = "";
      this.alertType = '';
      this.alertVisible = false;
    }
  }
}
