import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SerialProductAddComponent } from './serial-product-add/serial-product-add.component';
import { SerialProductListComponent } from './serial-product-list/serial-product-list.component';
import { SerialProductSearchComponent } from './serial-product-search/serial-product-search.component';
import { SerialProductUpdateComponent } from './serial-product-update/serial-product-update.component';

import { RouterModule } from '@angular/router';
import{ MatInputModule } from '@angular/material/input';
import{ MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import{ MatSortModule } from '@angular/material/sort';
import{ MatTableModule } from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox'
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatButtonModule} from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';
import {MatGridListModule} from '@angular/material/grid-list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
@NgModule({
  declarations: [
    SerialProductAddComponent,
    SerialProductListComponent,
    SerialProductSearchComponent,
    SerialProductUpdateComponent
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
    MatIconModule,
    MatSelectModule,
    MatDialogModule,
    MatGridListModule,
    FormsModule, ReactiveFormsModule
  ],
  exports:[SerialProductSearchComponent]
})
export class SerialProductModule { }
