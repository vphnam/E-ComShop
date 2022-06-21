import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { HttprequestService } from 'src/services/http-request.service';
import { IPurchaseOrderListViewModel, IPurchaseOrderSearchForm, IRole } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
})
export class EmployeeAddComponent implements OnInit, OnDestroy, AfterViewInit {

  employeeAddForm: any;
  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    this.employeeAddForm = shared.getEmployeeAddForm();
    this.getRoleList();
  }
  customErrorStateMatcher = new CustomErrorStateMatcher();
  roleList!: IRole[];
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    }
  ngOnDestroy(): void {
  }
  getRoleList(){
    this.http.get('/Employee/GetRoles').subscribe(data => {this.roleList = data.data});
  }
  saveEmployee(){
    Swal.fire({
      title: 'Warning!',
      text: "Do you want to add new employee!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, add new employee!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.post('/Employee', this.employeeAddForm.value).subscribe(data => {
          if (data.status == 200) {
            this.employeeAddForm.reset();
            Swal.fire({
              icon: 'success',
              title: 'Completed',
              text: data.message,
            });
          }
          else
          {
            Swal.fire({
              icon: 'error',
              title: 'Error',
              text: data.data,
            });
          }
        });
      }
    });
  }
}
