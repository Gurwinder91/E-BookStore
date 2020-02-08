import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuardService } from './guards/auth-guard.service';
import { PageNotfoundComponent } from './pages/page-notfound/page-notfound.component';

const routes: Routes = [
  {
    path: '', redirectTo: 'books', pathMatch: 'full'
  },
  {
    path: 'login',   loadChildren: () => import('./pages/login/login.module')
    .then(m => m.LoginModule),
  },
  {
    path: 'books',
    loadChildren: () => import('./pages/book/book.module')
    .then(m => m.BookModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'orders',
    loadChildren: () => import('./pages/orders/orders.module')
    .then(m => m.OrdersModule),
    canActivate: [AuthGuardService]
  },
  {
    path: '**',
    component: PageNotfoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
