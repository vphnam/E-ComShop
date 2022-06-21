import { HttpClient, HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { HttprequestService } from 'src/services/http-request.service';
import { IPurchaseOrderListViewModel, IPurchaseOrderSearchForm, IRole } from 'src/services/interface.service';
import { SharedService } from 'src/services/shared.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
})
export class ProductUpdateComponent implements OnInit, OnDestroy, AfterViewInit {

  @Input() id!: string;
  productAddForm: any;
  typeList: any;
  styleList:any;
  constructor(private http: HttprequestService, private httpClient: HttpClient, private shared: SharedService) {
    this.productAddForm = shared.getProductAddForm();
    this.getTypeList();
    this.getStyleList();
  }
  customErrorStateMatcher = new CustomErrorStateMatcher();
  closeDialog: boolean = false;
  ngOnInit(): void {
    if(this.id){
      this.http.get("/Product/GetByNo?no=" +this.id).subscribe((data:any) => {
        if(data.status == 200){
          this.productAddForm.patchValue(data.data);
        }
        else
          Swal.fire("Error",data.message,'error');
      });
    }
  }
  ngAfterViewInit(): void {
    }
  ngOnDestroy(): void {
  }
  saveSize(){
    Swal.fire({
      title: 'Warning!',
      text: "Do you want to update new product!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, update product!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.post('/Product/update', this.productAddForm.getRawValue()).subscribe(data => {
          if (data.status == 200) {
            this.shared.setData("");
            Swal.fire({
              icon: 'success',
              title: 'Completed',
              text: data.message,
            });
          }
          else
          {
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
  getTypeList(){
    this.http.get('/Type').subscribe(data => {this.typeList = data.data});
  }
  getStyleList(){
    this.http.get('/Style').subscribe(data => {this.styleList = data.data});
  }
}
