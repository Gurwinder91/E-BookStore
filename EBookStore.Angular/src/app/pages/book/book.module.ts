import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BsSharedModule } from '../../shared/bs-shared.module';
import { BookComponent } from './book.component';
import { BookDetailComponent } from './book-detail/book-detail.component';

const routes: Routes = [
  {
    path: '', component: BookComponent

  }, {
    path: ':bookId', component: BookDetailComponent
  }
];

@NgModule({
  declarations: [
    BookComponent,
    BookDetailComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    BsSharedModule
  ]
})
export class BookModule { }
