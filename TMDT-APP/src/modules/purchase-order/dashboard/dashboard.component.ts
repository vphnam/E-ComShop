import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BreadCrumbService } from 'src/services/breadcrumb.service';
import { HttprequestService } from 'src/services/http-request.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {

  constructor(private http: HttprequestService, private modalService: NgbModal, private bcService: BreadCrumbService) 
  {
    this.bcService.nextBreadCrumb("PurchaseOrder/Dashboard");
  }
  dashBoardTable: any;
  processStatusCodePassToModal!: number;
  ngOnInit(): void {
    this.RefreshDashBoard(); 
  }
  OpenDialog(content: any, id: any) {
    this.processStatusCodePassToModal = id;
    this.modalService.open(content, {size: 'xl'}).result.then((result) => {
    }, (reason) => {
    });
  }
  RefreshDashBoard(){
    this.http.GetDashBoardTable().subscribe(data =>{
      this.dashBoardTable = data.data;
    });
  }

}
