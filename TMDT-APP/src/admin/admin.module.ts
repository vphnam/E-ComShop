import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';

import { PurchaseOrderModule } from 'src/modules/purchase-order/purchase-order.module';
import { EmployeeModule } from 'src/modules/employee/employee.module';
import { CustomerModule } from 'src/modules/customer/customer.module';

import { HeaderComponent } from './layout/main/header/header.component';
import { BreadCrumbComponent } from './layout/main/breadcumb/breadcrumb.component';
import { BodyComponent } from './layout/main/body/body.component';
import { HomeComponent } from './layout/home/home.component';
import { FooterComponent } from './layout/main/footer/footer.component';

import { MainMenuComponent } from './layout/mainmenu/mainmenu.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { ErrorStateMatcher } from '@angular/material/core';
import { CustomErrorStateMatcher } from 'src/services/custom-error-matcher.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { LoginComponent } from './login/login.component';
import { SizeModule } from 'src/modules/size/size.module';
import { ColorModule } from 'src/modules/color/color.module';
import { StyleModule } from 'src/modules/style/style.module';
import { TypeModule } from 'src/modules/type/type.module';
import { ProductModule } from 'src/modules/product/product.module';
import { SerialProductModule } from 'src/modules/serial-product/serial-product.module';
@NgModule({
  declarations: [
    AdminComponent,

    HeaderComponent,
    BreadCrumbComponent,
    BodyComponent,
    HomeComponent,
    FooterComponent,
    MainMenuComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    PurchaseOrderModule,
    EmployeeModule,
    CustomerModule,
    SizeModule,
    ColorModule,
    StyleModule,
    TypeModule,
    ProductModule,
    SerialProductModule,

    
    ReactiveFormsModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatGridListModule
  ],
  providers:[{
    provide: ErrorStateMatcher, useClass: CustomErrorStateMatcher
  }],
  bootstrap: [AdminComponent],
})
export class AdminModule {}
