import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { HttprequestService } from 'src/services/http-request.service';
import { IPurchaseOrderListViewModel, IPurchaseOrderSearchForm, IRole } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-style-add',
  templateUrl: './style-add.component.html',
})
export class StyleAddComponent implements OnInit, OnDestroy, AfterViewInit {

  styleAddForm: any;
  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    this.styleAddForm = shared.getStyleAddForm();
  }
  customErrorStateMatcher = new CustomErrorStateMatcher();
  closeDialog: boolean = false;
  roleList!: IRole[];
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    }
  ngOnDestroy(): void {
  }
  saveStyle(){
    Swal.fire({
      title: 'Warning!',
      text: "Do you want to add new style!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, add new style!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.post('/Style', this.styleAddForm.value).subscribe(data => {
          if (data.status == 200) {
            this.styleAddForm.reset();
            this.shared.setData("");
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
              text: data.message,
            });
          }
        });
      }
    });
  }
}
