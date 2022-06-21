import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { map, Observable, tap } from 'rxjs';
import { HttprequestService } from 'src/services/http-request.service';
import { IStyle} from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
@Component({
  selector: 'app-style-list',
  templateUrl: './style-list.component.html'
})
export class StyleListComponent implements OnInit, OnDestroy, AfterViewInit {

  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    
  }
  dataSource: any;
  length!: number;
  pageSize: number = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  // MatPaginator Output
  pageEvent!: PageEvent;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  displayedColumns = ["styleNo",
    "styleName",];
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    this.shared.getData().subscribe(data=>{
      if(data != null)
      {
        this.refreshStyleListBySearchForm();
      }
      else
      {
        this.refreshStyleListBySearchForm();
      }
    });
    
  }
  ngOnDestroy(): void {
  }
  refreshStyleListBySearchForm() {
    this.http.get("/Style").subscribe(data => {
      console.warn(data);
      this.dataSource = new MatTableDataSource<IStyle>(data.data);
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
    console.log('Row clicked: ', row);
  }
}
