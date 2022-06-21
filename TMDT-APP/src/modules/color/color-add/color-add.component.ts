import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { HttprequestService } from 'src/services/http-request.service';
import { IPurchaseOrderListViewModel, IPurchaseOrderSearchForm, IRole } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-color-add',
  templateUrl: './color-add.component.html',
})
export class ColorAddComponent implements OnInit, OnDestroy, AfterViewInit {

  colorAddForm: any;
  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    this.colorAddForm = shared.getColorAddForm();
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
  saveColor(){
    Swal.fire({
      title: 'Warning!',
      text: "Do you want to add new color!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, add new color!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.post('/Color', this.colorAddForm.value).subscribe(data => {
          if (data.status == 200) {
            this.colorAddForm.reset();
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
