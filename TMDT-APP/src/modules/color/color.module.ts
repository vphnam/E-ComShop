import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ColorAddComponent } from './color-add/color-add.component';
import { ColorListComponent } from './color-list/color-list.component';
import { ColorSearchComponent } from './color-search/color-search.component';

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
    ColorAddComponent,
    ColorListComponent,
    ColorSearchComponent
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
  exports:[ColorSearchComponent]
})
export class ColorModule { }
