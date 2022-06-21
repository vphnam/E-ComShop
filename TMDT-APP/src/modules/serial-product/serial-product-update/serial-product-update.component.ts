import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { HttprequestService } from 'src/services/http-request.service';
import { IPurchaseOrderListViewModel, IPurchaseOrderSearchForm, IRole } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-serial-product-update',
  templateUrl: './serial-product-update.component.html',
})
export class SerialProductUpdateComponent implements OnInit, OnDestroy, AfterViewInit {

  @Input() id!: string;
  serialProductUpdateForm: any;

  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    this.serialProductUpdateForm = shared.getSerialProductUpdateForm();
  }


  customErrorStateMatcher = new CustomErrorStateMatcher();
  closeDialog: boolean = false;

  fileName = '';
  onFileSelected(event:any) {

    const file: File = event.target.files[0];

    if (file) {

      this.fileName = file.name;
      this.productDetailImage = file.name;

      const formData = new FormData();

      formData.append("thumbnail", file);

      const upload$ = this.http.post("/api/thumbnail-upload", formData);

      upload$.subscribe();
    }
  }

  productDetailImage!:string;
  ngOnInit(): void {
    if (this.id) {
      this.http.get("/SerialProduct/GetByNo?no=" + this.id).subscribe((data: any) => {
        console.warn(data);
        if (data.status == 200) {
          this.serialProductUpdateForm.patchValue(data.data);
          this.productDetailImage = data.data.image;
        }
        else
          Swal.fire("Error", data.message, 'error');
      });
    }
  }
  ngAfterViewInit(): void {
  }
  ngOnDestroy(): void {
  }
  saveSize() {
    Swal.fire({
      title: 'Warning!',
      text: "Do you want to update serial product!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, update serial product!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.serialProductUpdateForm.get('productDetailImage').setValue(this.productDetailImage);
        this.http.post('/SerialProduct/update', this.serialProductUpdateForm.getRawValue()).subscribe(data => {
          if (data.status == 200) {
            this.shared.setData("");
            Swal.fire({
              icon: 'success',
              title: 'Completed',
              text: data.message,
            });
          }
          else {
            console.warn(data);
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
