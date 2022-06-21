import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BreadCrumbService } from 'src/services/breadcrumb.service';
import { CustomValidatorService } from 'src/services/custom-validator.service';
import { ICustomerSearchForm, IEmployeeSearchForm } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import { CustomerAddComponent } from '../customer-add/customer-add.component';
@Component({
  selector: 'app-customer-search',
  templateUrl: './customer-search.component.html',
})
export class CustomerSearchComponent implements OnInit, OnDestroy {

  searchForm: ICustomerSearchForm ={
    customerNo: "",
    customerName: "",
    phoneNumber: "",
    email: "",
  };
  constructor(private bcService: BreadCrumbService, private shared: SharedService, public dialog: MatDialog) 
  {
    this.bcService.nextBreadCrumb("Customer/Search-Add");
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
    this.searchForm.customerNo = "";
    this.searchForm.customerName = "";
    this.searchForm.phoneNumber = "";
    this.searchForm.email = "";
  }
  openDialog() {
    const dialogRef = this.dialog.open(CustomerAddComponent, {width:'1000px',height:'450px'});
  }

}
