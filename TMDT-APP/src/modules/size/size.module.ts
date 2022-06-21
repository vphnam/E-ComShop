import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SizeAddComponent } from './size-add/size-add.component';
import { SizeListComponent } from './size-list/size-list.component';
import { SizeSearchComponent } from './size-search/size-search.component';

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
@NgModule({
  declarations: [
    SizeAddComponent,
    SizeListComponent,
    SizeSearchComponent
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
    MatSelectModule,
    MatDialogModule,
    MatGridListModule,
    FormsModule, ReactiveFormsModule
  ],
  exports:[SizeSearchComponent]
})
export class SizeModule { }
