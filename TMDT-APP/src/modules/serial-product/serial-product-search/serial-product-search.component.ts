import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BreadCrumbService } from 'src/services/breadcrumb.service';
import { CustomValidatorService } from 'src/services/custom-validator.service';
import { ICustomerSearchForm, IEmployeeSearchForm } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import { SerialProductAddComponent } from '../serial-product-add/serial-product-add.component';
@Component({
  selector: 'app-serial-product-search',
  templateUrl: './serial-product-search.component.html',
})
export class SerialProductSearchComponent implements OnInit, OnDestroy {

  constructor(private bcService: BreadCrumbService, private shared: SharedService, public dialog: MatDialog) 
  {
    this.bcService.nextBreadCrumb("Serial Product/Search-Add-Update");
  }
  ngOnDestroy(): void {
    this.shared.setData(null);
  }
  
  ngOnInit(): void {

  }

  openDialog() {
    const dialogRef = this.dialog.open(SerialProductAddComponent, {width:'1000px',height:'500px'});
  }

}
