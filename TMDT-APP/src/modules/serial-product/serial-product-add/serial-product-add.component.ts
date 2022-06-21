import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { HttprequestService } from 'src/services/http-request.service';
import { IPurchaseOrderListViewModel, IPurchaseOrderSearchForm, IRole } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-serial-product-add',
  templateUrl: './serial-product-add.component.html',
})
export class SerialProductAddComponent implements OnInit, OnDestroy, AfterViewInit {

  serialProductAddForm: any;
  productList:any;
  sizeList: any;
  colorList:any;
  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    this.serialProductAddForm = shared.getSerialProductAddForm();
    this.getProductList();
    this.getTypeList();
    this.getStyleList();
  }
  customErrorStateMatcher = new CustomErrorStateMatcher();
  closeDialog: boolean = false;
  ngOnInit(): void {
  }
  ngAfterViewInit(): void {
    }
  ngOnDestroy(): void {
  }
  saveSize(){
    Swal.fire({
      title: 'Warning!',
      text: "Do you want to add new serial product!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, add new serial product!'
    }).then((result) => {
      if (result.isConfirmed) {
        console.warn(this.serialProductAddForm.value);
        this.http.post('/SerialProduct', this.serialProductAddForm.value).subscribe(data => {
          if (data.status == 200) {
            this.serialProductAddForm.reset();
            this.fileName = '';
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
  getProductList(){
    this.http.get('/Product').subscribe(data => {this.productList = data.data});
  }
  getTypeList(){
    this.http.get('/Size').subscribe(data => {this.sizeList = data.data});
  }
  getStyleList(){
    this.http.get('/Color').subscribe(data => {this.colorList = data.data});
  }

  fileName = '';
  onFileSelected(event:any) {

    const file: File = event.target.files[0];

    if (file) {

      this.fileName = file.name;
      this.serialProductAddForm.get('productDetailImage').setValue(file.name);

      const formData = new FormData();

      formData.append("thumbnail", file);

      const upload$ = this.http.post("/api/thumbnail-upload", formData);

      upload$.subscribe();
    }
  }
}
