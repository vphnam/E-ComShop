import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardComponent } from './dashboard/dashboard.component';
import { ListPurchaseOrderComponent } from './list-purchase-order/list-purchase-order.component';
import { PurchaseOrderSearchComponent } from './purchase-order-search/purchase-order-search.component';
import { RouterModule } from '@angular/router';
import{ MatInputModule } from '@angular/material/input';
import{ MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import{ MatSortModule } from '@angular/material/sort';
import{ MatTableModule } from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox'
import { MatPaginatorModule } from '@angular/material/paginator';
import { FormsModule } from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatButtonModule} from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
@NgModule({
  declarations: [
    DashboardComponent,
    ListPurchaseOrderComponent,
    PurchaseOrderSearchComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatCheckboxModule,
    MatPaginatorModule,
    FormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule,
    MatSelectModule
  ],
  exports:[DashboardComponent,ListPurchaseOrderComponent,PurchaseOrderSearchComponent]
})
export class PurchaseOrderModule { }
