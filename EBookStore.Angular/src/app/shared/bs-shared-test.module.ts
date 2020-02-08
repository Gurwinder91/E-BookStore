import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { BsCoreModule } from '../core/bs-core.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    BsCoreModule
  ],
  exports:[
    HttpClientModule,
    BsCoreModule
  ]
})
export class BsSharedTestModule { }
