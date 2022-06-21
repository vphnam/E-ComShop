import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule, DATE_PIPE_DEFAULT_TIMEZONE } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment.dev';
import { MAT_DATE_FORMATS } from '@angular/material/core';
import { DatePipe } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import{ MatInputModule } from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
  ],
  providers: [{provide: DEFAULT_CURRENCY_CODE, useValue: 'GBP'},
  {provide: DATE_PIPE_DEFAULT_TIMEZONE, useValue: environment.useValue},
  {provide: LOCALE_ID, useValue: environment.locale_Id},
  {provide: MAT_DATE_FORMATS, useValue: "yyyy/MM/dd"},DatePipe],
  bootstrap: [AppComponent],
})
export class AppModule { }
