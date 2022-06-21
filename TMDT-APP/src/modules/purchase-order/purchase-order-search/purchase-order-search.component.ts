import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { IPurchaseOrderSearchForm } from 'src/services/interface.service';
import { BreadCrumbService } from 'src/services/breadcrumb.service';
import { SharedService } from 'src/services/shared.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-purchase-order-search',
  templateUrl: './purchase-order-search.component.html',
})
export class PurchaseOrderSearchComponent implements OnInit, AfterViewInit,OnDestroy {

  constructor(private bcService: BreadCrumbService, private shared: SharedService, private modalService: NgbModal) 
  {
    this.bcService.nextBreadCrumb("PurchaseOrder/Search");
  }
  searchForm: IPurchaseOrderSearchForm ={
    orderNo: "",
    customerInfo: "",
    employeeInfo: "",
    orderDate: "",
    voucherNo: "",
    status: "",
  };
  ngAfterViewInit(): void {
  }
  ngOnDestroy(): void {
    this.shared.setData(null);
  }

  ngOnInit(): void {
    this.refreshSearchForm();
  }
  search(){
    this.shared.setData(this.searchForm);
  }
  refreshSearchForm(){
    this.searchForm.orderNo = "";
    this.searchForm.customerInfo = "";
    this.searchForm.employeeInfo = "";
    this.searchForm.orderDate = "";
    this.searchForm.voucherNo = "";
  }
  OpenDialog(content: any) {
    this.modalService.open(content, {size: 'xl'}).result.then((result) => {
    }, (reason) => {
    });
  }
}
