import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { IPurchaseOrderSearchForm } from './interface.service';
@Injectable({
    providedIn: 'root'
})
export class SharedService {
    private _dataSearch: BehaviorSubject<any> = new BehaviorSubject<any>(null);

    constructor() {
    }
    public setData(data: any) {
        this._dataSearch.next(data);
    }

    public getData(): Observable<any> {
        return this._dataSearch.asObservable();
    }
    employeeAddForm = new FormGroup({
        employeeNo: new FormControl({ value: "", disabled: true }),
        employeeName: new FormControl(null, [Validators.required]),
        dateOfBirth: new FormControl(null, [Validators.required]),
        phoneNumber: new FormControl(null, [Validators.required, Validators.pattern('^((\\+91-?)|0)?[0-9]{10}$')]),
        roleNo: new FormControl(null, [Validators.required]),
        email: new FormControl(null, [Validators.required, Validators.email]),
        passWord: new FormControl(null, [Validators.required]),
        confirmPassWord: new FormControl(null, [Validators.required]),
    });
    customerAddForm = new FormGroup({
        customerNo: new FormControl({ value: "", disabled: true }),
        customerName: new FormControl(null, [Validators.required]),
        customerAddress: new FormControl(null, [Validators.required]),
        phoneNumber: new FormControl(null, [Validators.required, Validators.pattern('^((\\+91-?)|0)?[0-9]{10}$')]),
        email: new FormControl(null, [Validators.required, Validators.email]),
        passWord: new FormControl(null, [Validators.required]),
        confirmPassWord: new FormControl(null, [Validators.required]),
    });
    sizeAddForm = new FormGroup({
        sizeNo: new FormControl({ value: "", disabled: true }),
        sizeName: new FormControl(null, [Validators.required]),
    });
    colorAddForm = new FormGroup({
        colorNo: new FormControl({ value: "", disabled: true }),
        colorName: new FormControl(null, [Validators.required]),
    });
    styleAddForm = new FormGroup({
        styleNo: new FormControl({ value: "", disabled: true }),
        styleName: new FormControl(null, [Validators.required]),
    });
    typeAddForm = new FormGroup({
        typeNo: new FormControl({ value: "", disabled: true }),
        typeName: new FormControl(null, [Validators.required]),
    });
    public getEmployeeAddForm() {
        return this.employeeAddForm;
    }
    public getCustomerAddForm() {
        return this.customerAddForm;
    }
    public getSizeAddForm(){
        return this.sizeAddForm;
    }
    public getColorAddForm(){
        return this.colorAddForm;
    }
    public getStyleAddForm(){
        return this.styleAddForm;
    }
    public getTypeAddForm(){
        return this.typeAddForm;
    }
    urlAdmin: string[] = [
        "/admin/home",
        "/admin/purchase-order",
        "/admin/purchase-order/dashboard",
        "/admin/employee",
        "/admin/customer",
        "/admin/size",
        "/admin/color",
        "/admin/style",
        "/admin/type",
    ];
    urlSales: string[] = [
        "/admin/home",
        "/admin/purchase-order",
        "/admin/purchase-order/dashboard",
    ];
    urlFinance: string[] = [
        "/admin/home",
        "/admin/purchase-order",
        "/admin/purchase-order/dashboard",
    ];
    public checkAuthorization(role: string, url: string): boolean {
        console.log(url);
        switch (role) {
            case "1":
                if (this.urlAdmin.includes(url)) {
                    return true;
                }
                else
                    return false;
                break;
            case "2":
                if (this.urlSales.includes(url)) {
                    return true;
                }
                else
                    return false;
                break;
            case "3":
                if (this.urlFinance.includes(url)) {
                    return true;
                }
                else
                    return false;
                break;
            default:
                return false;
                break;
        }
    }
}
