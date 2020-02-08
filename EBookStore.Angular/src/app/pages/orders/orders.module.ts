import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BsSharedModule } from '../../shared/bs-shared.module';
import { OrdersComponent } from './orders.component';

const routes: Routes = [
  {
    path: '', component: OrdersComponent
  }
];

@NgModule({
  declarations: [
    OrdersComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    BsSharedModule
  ]
})
export class OrdersModule { }
