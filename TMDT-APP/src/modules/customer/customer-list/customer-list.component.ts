import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { map, Observable, tap } from 'rxjs';
import { HttprequestService } from 'src/services/http-request.service';
import { ICustomer, ICustomerSearchForm, IPurchaseOrderListViewModel, IPurchaseOrderSearchForm } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html'
})
export class CustomerListComponent implements OnInit, OnDestroy, AfterViewInit {

  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    
  }
  dataSource: any;
  length!: number;
  pageSize: number = 100;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  // MatPaginator Output
  pageEvent!: PageEvent;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  displayedColumns = ["customerNo",
    "customerName",
    "customerAddress",
    "phoneNumber",
    "email",];
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    this.shared.getData().subscribe(data=>{
      if(data != null)
      {
        console.warn(data);
        this.refreshCustomerListBySearchForm(data);
      }
    });
  }
  ngOnDestroy(): void {
  }
  refreshCustomerListBySearchForm(sForm: ICustomerSearchForm) {
    this.http.post('/Customer/SearchCustomer',sForm).subscribe(data => {
      console.warn(data.data);
      this.dataSource = new MatTableDataSource<ICustomer>(data.data);
      this.dataSource.paginator = this.paginator;
      this.length = data.data.length;
      this.dataSource.sort = this.sort;
    });
  }
  onRowClicked(row: any) {
    console.log('Row clicked: ', row);
  }
}
