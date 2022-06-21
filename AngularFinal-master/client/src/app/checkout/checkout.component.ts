import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IPayPalConfig } from 'ngx-paypal';
import { stringify } from 'querystring';
import Swal from 'sweetalert2';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
import { CartService } from '../services/cart.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss'],
})
export class CheckoutComponent implements OnInit {
  currentUser: any;
  currentStep = 1;
  cardNumber: string;
  cartData: any;
  products: any;
  loading = false;
  successMessage = '';
  orderId;
  discount: number;
  total: number;
  salePercent: any;
  voucher: any;
  customerName: string;
  deliveryAddress:string;
  po: any = {
    deliveryAddress: '',
    note: '',
    voucherNo: '',
    customerNo: '',
    listPurchaseOrderLines: []
  };
  pol: any = {
    orderNo: '',
    serialNo: '',
    quantityOrdered: null,
    buyPrice: null,
  };
  billingAddressForm = new FormGroup({
    deliveryAddress: new FormControl("", [Validators.required]),
    note: new FormControl(""),
  });
  paymentForm = new FormGroup({
    voucherNo: new FormControl(""),
    selectedPaymentMethod: new FormControl(null, [Validators.required]),
  });
  changePayment() {
    if (this.paymentForm.get('selectedPaymentMethod').value != 'cash') {
      this.paymentForm.get('selectedPaymentMethod').setValue('cash');
      Swal.fire("Cảnh báo", "Phương thức thanh toán bạn chọn hiện tại đang gặp vấn đề, vui lòng chọn tiền mặt", 'warning');
    }
  }
  applyVoucher(cartTotal: number) {
    this._api.getTypeRequest("/PurchaseOrder/ApplyVoucher?customerNo=" + this.currentUser.customerNo + "&voucherNo=" + this.paymentForm.get('voucherNo').value).subscribe((data: any) => {
      if (data.status != 200) {
        this.paymentForm.get('voucherNo').setValue(null);
        this.discount = null;
        this.total = cartTotal;
        Swal.fire("Cảnh báo", "Mã voucher không hợp lệ", 'warning');
      }
      else {
        this.voucher = data.data;
        this.discount = cartTotal * this.voucher.salePercent;
        if (this.discount > this.voucher.maxPrice)
          this.discount = this.voucher.maxPrice;
        this.salePercent = this.voucher.salePercent * 100;
        this.total = cartTotal - this.discount;
      }
    });
  }
  generateAddress() {
    this._api.getTypeRequest("/Customer/GetAddress?no=" + this.currentUser.customerNo).subscribe((data: any) => {
      this.billingAddressForm.get('deliveryAddress').setValue(data.data);
    });
  }
  public payPalConfig?: IPayPalConfig;
  constructor(private _auth: AuthService, private _cart: CartService, private _api: ApiService, private _token: TokenStorageService) {
    this.currentUser = this._token.getUser();
    this._auth.user.subscribe((user) => {
      if (user) {
      }
    });
    this.generateAddress();
    this._cart.cartDataObs$.subscribe((cartData) => {
      console.warn(cartData);
      this.cartData = cartData;
    });
  }

  ngOnInit(): void {
    this.currentStep = 0;
    this.initConfig();
  }

  submitCheckout() {
    this.nextStep();
    /*
    this.loading = true;
    setTimeout(() => {
      this._cart
        .submitCheckout(this.currentUser.user_id, this.cartData)
        .subscribe(
          (res: any) => {
            console.log(res);
            this.loading = false;
            this.orderId = res.orderId;
            this.products = res.products;
            this.currentStep = 4;
            this._cart.clearCart();
          },
          (err) => {
            console.log(err);
            this.loading = false;
          }
        );
    }, 750);*/
  }

  getProgressPrecent() {
    return (this.currentStep / 4) * 100;
  }

  submitBilling(): void {
    this.nextStep();
  }

  submitPayment(cartData: any): void {
    if (this.paymentForm.get('selectedPaymentMethod').value == 'cash') {
      console.warn(cartData);
      this.po.deliveryAddress = this.billingAddressForm.get('deliveryAddress').value;
      this.po.note = this.billingAddressForm.get('note').value;
      if (this.paymentForm.get('voucherNo').value != "")
        this.po.voucherNo = this.paymentForm.get('voucherNo').value;
      else
        this.po.voucherNo = null;
      this.po.customerNo = this.currentUser.customerNo;

      for (let i = 0; i < cartData.length; i++) {
        this.po.listPurchaseOrderLines.push({
          orderNo: i,
          serialNo: cartData[i].serialNo,
          quantityOrdered: cartData[i].quantity,
          buyPrice: cartData[i].price,
        });
      }

      console.warn(this.po);
      this._api.postTypeRequest("/PurchaseOrder", this.po).subscribe((data: any) => {
        console.warn(data);
        this.po = null;
        if (data.status == 200) {
          this.orderId = data.data.orderNo;
          this.customerName = this.currentUser.customerName;
          this.deliveryAddress = data.data.deliveryAddress;
          this.products = cartData;
          this._cart.clearCart();
          this.nextStep();
        }
        else
          Swal.fire("Lỗi", "Đã có lỗi phát sinh trong quá trình đặt hàng, vui lòng liên hệ chăm sóc khách hàng để biết thêm chi tiết", 'error');
      });
      //this.nextStep();
    }
  }

  canPaymentSubmit(): boolean {
    return true;
  }

  nextStep(): void {
    this.currentStep += 1;
    localStorage.setItem('checkoutStep', this.currentStep.toString());
  }

  prevStep(): void {
    if (this.currentStep > 0) {
      this.currentStep -= 1;
      this.changeContent();
      localStorage.setItem('checkoutStep', this.currentStep.toString());
    }
  }



  //stepper

  index = 'First-content';

  /*pre(): void {
    this.current -= 1;
    this.changeContent();
  }

  next(): void {
    this.current += 1;
    this.changeContent();
  }*/

  done(): void {
    console.log('done');
  }

  changeContent(): void {
    switch (this.currentStep) {
      case 1: {
        this.index = 'First-content';
        break;
      }
      case 2: {
        this.index = 'Second-content';
        break;
      }
      case 3: {
        this.index = 'third-content';
        break;
      }
      default: {
        this.index = 'error';
      }
    }
  }
  private initConfig(): void {
    this.payPalConfig = {
      currency: 'EUR',
      clientId: 'sb',
      createOrderOnClient: (data) => <any>{
        intent: 'CAPTURE',
        purchase_units: [{
          amount: {
            currency_code: 'EUR',
            value: '9.99',
            breakdown: {
              item_total: {
                currency_code: 'EUR',
                value: '9.99'
              }
            }
          },
          items: [{
            name: 'Enterprise Subscription',
            quantity: '1',
            category: 'DIGITAL_GOODS',
            unit_amount: {
              currency_code: 'EUR',
              value: '9.99',
            },
          }]
        }]
      },
      advanced: {
        commit: 'true'
      },
      style: {
        label: 'paypal',
        layout: 'vertical'
      },
      onApprove: (data, actions) => {
        console.log('onApprove - transaction was approved, but not authorized', data, actions);
        actions.order.get().then(details => {
          console.log('onApprove - you can get full order details inside onApprove: ', details);
        });

      },
      onClientAuthorization: (data) => {
        console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
        Swal.fire("Success");
      },
      onCancel: (data, actions) => {
        console.log('OnCancel', data, actions);
        Swal.fire("Cancel");

      },
      onError: err => {
        console.log('OnError', err);
        Swal.fire("Error");
      },
      onClick: (data, actions) => {
        console.log('onClick', data, actions);
      }
    };
  }
}

