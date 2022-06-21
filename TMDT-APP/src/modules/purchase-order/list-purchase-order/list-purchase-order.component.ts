import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { map, Observable, tap } from 'rxjs';
import { HttprequestService } from 'src/services/http-request.service';
import { IPurchaseOrderListViewModel, IPurchaseOrderSearchForm } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-list-purchase-order',
  templateUrl: './list-purchase-order.component.html'
})
export class ListPurchaseOrderComponent implements OnInit, OnDestroy, AfterViewInit {

  constructor(private datePipe: DatePipe,private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    
  }
  dataSource: any;
  length!: number;
  pageSize: number = 100;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  // MatPaginator Output
  pageEvent!: PageEvent;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  @Input() processStatusCode!: number;
  purchaseOrderList!: IPurchaseOrderListViewModel[];
  displayedColumns = ["orderNo",
    "customerName",
    "employeeName",
    "deliveryAddress",
    "orderDate",
    "voucherNo",
    "processStatus",
    "inTheProcessDay",
    "sentMail",
    "status"];
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    if(this.processStatusCode != undefined)
    {
      this.refreshPurchaseOrderList();
    } 
    else
    {
      this.shared.getData().subscribe(data=>{
        if(data != null)
        {
          console.log(data);
          this.refreshPurchaseOrderListBySearchForm(data);
        }
      });
        // Do whatever you want with your data
    }
  }
  ngOnDestroy(): void {
  }
  refreshPurchaseOrderList() {
    this.http.GetPurchaseOrderListByProcessStatusCode(this.processStatusCode).subscribe(data => {
      this.dataSource = new MatTableDataSource<IPurchaseOrderListViewModel>(data.data);
      this.dataSource.paginator = this.paginator;
      this.length = data.data.length;
      this.dataSource.sort = this.sort;
    });
  }
  refreshPurchaseOrderListBySearchForm(sForm: IPurchaseOrderSearchForm) {
    this.http.SearchPurchaseOrder(sForm).subscribe(data => {
      console.warn(data);
      this.dataSource = new MatTableDataSource<IPurchaseOrderListViewModel>(data.data);
      this.dataSource.paginator = this.paginator;
      this.length = data.data.length;
      this.dataSource.sort = this.sort;
    });
  }
  onRowClicked(row: any) {
    console.log('Row clicked: ', row);
  }
}
