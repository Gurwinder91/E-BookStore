import { TestBed, ComponentFixture, fakeAsync, tick } from '@angular/core/testing';
import { CUSTOM_ELEMENTS_SCHEMA, DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';

import { BsProgressBarComponent } from './progress-bar.component';
import { LoaderService } from '../../services/loader/loader.service';

describe('Progress Bar Component', () => {
    let fixture: ComponentFixture<BsProgressBarComponent>;
    let component: BsProgressBarComponent;
    let loaderService: LoaderService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            declarations: [BsProgressBarComponent],
            providers: [LoaderService],
            schemas: [CUSTOM_ELEMENTS_SCHEMA]
        });
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(BsProgressBarComponent);
        component = fixture.componentInstance;
        loaderService = TestBed.get(LoaderService);
        fixture.detectChanges();
    });

    it('should have instance', () => {
        expect(component).toBeTruthy();
    });

    it('should not have Progress Element in DOM if show property is false', fakeAsync(() => {
        const matProgressbar: DebugElement = fixture.debugElement.query(By.css('mat-progress-bar'));
        expect(component.show).toBeFalsy();
        expect(matProgressbar).toBeNull();
    }));


    it('should have Progress Element in DOM if show property is true', fakeAsync(() => {
        loaderService.show();
        tick(50);
        fixture.detectChanges();

        const matProgressbar: DebugElement = fixture.debugElement.query(By.css('mat-progress-bar'));
        expect(component.show).toBeTruthy();
        expect(matProgressbar.nativeElement).not.toBeNull();
    }));

    it('should not have Progress Element in DOM if show property is false', fakeAsync(() => {
        loaderService.hide();
        tick(50);
        fixture.detectChanges();

        const matProgressbar: DebugElement = fixture.debugElement.query(By.css('mat-progress-bar'));
        expect(component.show).toBeFalsy();
        expect(matProgressbar).toBeNull();
    }));

});
