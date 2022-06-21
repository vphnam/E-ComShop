import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { map, Observable, tap } from 'rxjs';
import { HttprequestService } from 'src/services/http-request.service';
import { ISize } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import { ProductUpdateComponent } from '../product-update/product-update.component';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit, OnDestroy, AfterViewInit {

  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService, public dialog: MatDialog) {
    
  }
  dataSource: any;
  length!: number;
  pageSize: number = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  // MatPaginator Output
  pageEvent!: PageEvent;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  displayedColumns = ["productNo",
    "productName",
    "type",
    "style",
    "price",
    "productDescription"];
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    this.shared.getData().subscribe(data=>{
      if(data != null)
      {
        this.refreshProductListBySearchForm();
      }
      else
      {
        this.refreshProductListBySearchForm();
      }
    });
    
  }
  ngOnDestroy(): void {
  }
  refreshProductListBySearchForm() {
    this.http.get("/Product").subscribe(data => {
      console.warn(data);
      this.dataSource = new MatTableDataSource<ISize>(data.data);
      this.dataSource.paginator = this.paginator;
      this.length = data.data.length;
      this.dataSource.sort = this.sort;
    });
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  onRowClicked(row: any) {
    const dialogRef = this.dialog.open(ProductUpdateComponent, {width:'1000px',height:'500px'});
    dialogRef.componentInstance.id = row.productNo;
  }
}
