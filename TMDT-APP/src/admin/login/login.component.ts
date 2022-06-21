import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/services/authentication.service';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { RaiseAlertService } from 'src/services/raise-alert.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  constructor(private authenService: AuthenticationService, private router: Router, 
    private actRouter: ActivatedRoute,private raiseAlertService: RaiseAlertService ) { 
    this.loginForm = new FormGroup({
      email: new FormControl("", [Validators.required]),
      passWord: new FormControl("", [Validators.required]),
      type: new FormControl(true),
    });
  }
  customErrorStateMatcher = new CustomErrorStateMatcher();
  loginForm: any;
  returnUrl!: string;
  ngOnInit(): void {
    this.returnUrl = this.actRouter.snapshot.queryParams['returnUrl'] || '/admin';
  }
  login(){
    this.authenService.login(this.loginForm.value)
            .pipe()
            .subscribe(
                data => {
                  console.warn(data);
                  if(data.status == 200)
                  {
                      this.router.navigate([this.returnUrl]);
                  }
                  else if(data.status == 500)
                  {
                    this.raiseAlertService.raiseAlert("error", "Error",data.data);
                  }
                },
                error => {
                  this.raiseAlertService.raiseAlert("error","Error","Error request!");
                });
  }
}
