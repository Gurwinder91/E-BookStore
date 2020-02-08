import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BsProgressBarComponent } from './progress-bar/progress-bar.component';
import { BsSharedModule } from '../shared/bs-shared.module';


@NgModule({
    declarations: [
        BsProgressBarComponent 
    ],
    imports: [
        CommonModule,
        BsSharedModule
    ],
    entryComponents: [],
    exports: [
        CommonModule,
        BsSharedModule,
        BsProgressBarComponent
    ],
    providers: [ ]
})
export class BsCoreModule { }
