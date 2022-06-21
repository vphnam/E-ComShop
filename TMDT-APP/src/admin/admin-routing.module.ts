import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/helpers/AuthGuard';
import { ColorSearchComponent } from 'src/modules/color/color-search/color-search.component';
import { CustomerSearchComponent } from 'src/modules/customer/customer-search/customer-search.component';
import { EmployeeSearchComponent } from 'src/modules/employee/employee-search/employee-search.component';
import { ProductSearchComponent } from 'src/modules/product/product-search/product-search.component';
import { DashboardComponent } from 'src/modules/purchase-order/dashboard/dashboard.component';
import { PurchaseOrderSearchComponent } from 'src/modules/purchase-order/purchase-order-search/purchase-order-search.component';
import { SizeSearchComponent } from 'src/modules/size/size-search/size-search.component';
import { StyleSearchComponent } from 'src/modules/style/style-search/style-search.component';
import { TypeSearchComponent } from 'src/modules/type/type-search/type-search.component';
import { AdminComponent } from './admin.component';
import { HomeComponent } from './layout/home/home.component';
import { LoginComponent } from './login/login.component';
const routes: Routes = [
  {
    path: '',   // This is /admin
    component: AdminComponent,
    children: [
      {
        path: 'home',  // This is /admin/home
        component: HomeComponent, canActivate: [AuthGuard]
      },
      {
        path: 'purchase-order',
        component: PurchaseOrderSearchComponent,canActivate: [AuthGuard]
      },
      {
        path:'purchase-order/dashboard',
        component:DashboardComponent, canActivate: [AuthGuard]
      },
      {
        path:'employee',
        component:EmployeeSearchComponent, canActivate: [AuthGuard]
      },
      {
        path:'customer',
        component:CustomerSearchComponent, canActivate: [AuthGuard]
      },
      {
        path:'product',
        component:ProductSearchComponent, canActivate: [AuthGuard]
      },
      {
        path:'size',
        component:SizeSearchComponent, canActivate: [AuthGuard]
      },
      {
        path:'color',
        component:ColorSearchComponent, canActivate: [AuthGuard]
      },
      {
        path:'style',
        component: StyleSearchComponent, canActivate: [AuthGuard]
      },
      {
        path:'type',
        component: TypeSearchComponent, canActivate: [AuthGuard]
      },
      {
        path: 'login',component: LoginComponent
      },
      {
        path: '',
        redirectTo: 'home',
        pathMatch: "full"
      }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
