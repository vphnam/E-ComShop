import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BreadCrumbService } from 'src/services/breadcrumb.service';
import { CustomValidatorService } from 'src/services/custom-validator.service';
import { IEmployeeSearchForm } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import { EmployeeAddComponent } from '../employee-add/employee-add.component';
@Component({
  selector: 'app-employee-search',
  templateUrl: './employee-search.component.html',
})
export class EmployeeSearchComponent implements OnInit, OnDestroy {

  searchForm: IEmployeeSearchForm ={
    employeeNo: "",
    employeeName: "",
    dateOfBirth: "",
    phoneNumber: "",
    email: "",
  };
  constructor(private bcService: BreadCrumbService, private shared: SharedService, public dialog: MatDialog) 
  {
    this.bcService.nextBreadCrumb("Employee/Search-Add");
  }
  ngOnDestroy(): void {
    this.shared.setData(null);
  }
  
  ngOnInit(): void {

  }
  search(){
    this.shared.setData(this.searchForm);
  }
  refreshSearchForm(){
    this.searchForm.employeeNo = "";
    this.searchForm.employeeName = "";
    this.searchForm.dateOfBirth = "";
    this.searchForm.phoneNumber = "";
    this.searchForm.email = "";
  }
  openDialog() {
    const dialogRef = this.dialog.open(EmployeeAddComponent, {width:'1000px',height:'450px'});
  }

}
