import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { HttprequestService } from 'src/services/http-request.service';
import { IPurchaseOrderListViewModel, IPurchaseOrderSearchForm, IRole } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-size-add',
  templateUrl: './size-add.component.html',
})
export class SizeAddComponent implements OnInit, OnDestroy, AfterViewInit {

  sizeAddForm: any;
  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    this.sizeAddForm = shared.getSizeAddForm();
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
  saveSize(){
    Swal.fire({
      title: 'Warning!',
      text: "Do you want to add new size!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, add new size!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.post('/Size', this.sizeAddForm.value).subscribe(data => {
          if (data.status == 200) {
            this.sizeAddForm.reset();
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
