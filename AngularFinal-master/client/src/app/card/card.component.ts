import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { TokenStorageService } from '../services/token-storage.service';
import Swal from 'sweetalert2';
import { timer } from 'rxjs';
@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})
export class CardComponent implements OnInit {
  card:any;
  userId = null;
  alertMessage = '';
  alertType = '';
  alertVisible = false;
  loading = false;
  cardId:string;
  customerName:string;
  point: string;
  rank:string;
  constructor(
    private _api: ApiService,
    private _token: TokenStorageService,
    private _router: Router
  ) {
    this.refreshCard();
  }
  refreshCard(){
    const currentUser = this._token.getUser();
    this._api.getTypeRequest("/MembershipCard/ByCustomerNo?no=" + currentUser.customerNo).subscribe((data:any) =>{
      if(data.status == 200)
      {
        console.warn(data.data);
        this.card =data.data;
        this.cardId = this.card.cardNo;
        this.customerName = this.card.customerNoNavigation.customerName;
        this.point = this.card.point;
        this.rank = this.card.rankNoNavigation.rankName;
      }
    });
  }
  // Update user fields with current details
  ngOnInit(): void {
  }
}
