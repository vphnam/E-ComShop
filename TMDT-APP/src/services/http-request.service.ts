import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http'
import { environment } from 'src/environments/environment.dev';
import { Observable } from 'rxjs';
import { IResultViewModel } from './interface.service';
@Injectable({
  providedIn: 'root'
})
export class HttprequestService {

  readonly APIUrl = environment.apiUrl;
  constructor(private http:HttpClient) {
  }
  get(domainName: string): Observable<IResultViewModel>{
    return this.http.get<IResultViewModel>(this.APIUrl + domainName);
  } 
  post(domainName: string,viewModel: any){
    return this.http.post<IResultViewModel>(this.APIUrl + domainName,viewModel);
  }
  GetDashBoardTable(): Observable<IResultViewModel>{
    return this.http.get<IResultViewModel>(this.APIUrl + '/PurchaseOrder/GetDashBoardTable');
  }
  GetPurchaseOrderListByProcessStatusCode(code:number):  Observable<IResultViewModel>{
    return this.http.get<IResultViewModel>(this.APIUrl + '/PurchaseOrder/GetByProcessStatus/?code=' + code);
  }
  GetPurchaseOrderDetailByOrderNo(no:number): Observable<IResultViewModel>{
    return this.http.get<IResultViewModel>(this.APIUrl + '/PurchaseOrder/GetByNo/?no=' + no);
  }
  GetProcessStatusCodeList(): Observable<IResultViewModel>{
    return this.http.get<IResultViewModel>(this.APIUrl + '/PurchaseOrder/GetProcessList');
  }
  GetPurchaseOrderLineListByOrderNo(no:number): Observable<IResultViewModel>{
    return this.http.get<IResultViewModel>(this.APIUrl + '/PurchaseOrderLine/GetByOrderNo/?no=' + no);
  }
  UpdatePurchaseOrder(po: any){
    return this.http.post<IResultViewModel>(this.APIUrl + '/PurchaseOrder/update',po);
  }
  CancelPurchaseOrder(po: any){
    return this.http.post<IResultViewModel>(this.APIUrl + '/PurchaseOrder/cancel',po);
  }
  SearchPurchaseOrder(poSearch:any): Observable<IResultViewModel>{
    return this.http.post<IResultViewModel>(this.APIUrl + '/PurchaseOrder/SearchPurchaseOrder', poSearch);
  }
}
