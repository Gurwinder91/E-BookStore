import { TestBed, fakeAsync } from '@angular/core/testing';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';

import { NotificationService } from './notification.service';

class MockedSnackbar {
    message: string;
    action: string;
    config: MatSnackBarConfig;

    open(message: string, action?: string, config?: MatSnackBarConfig) {
        this.message = message;
        this.action = action;
        this.config = config;
    }
}
describe('Notification Service', () => {
    let service: NotificationService;
    let matSnackBar: any;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [NotificationService, { provide: MatSnackBar, useClass: MockedSnackbar }]
        }).compileComponents();
    });

    beforeEach(() => {
        service = TestBed.get(NotificationService);
        matSnackBar = TestBed.get(MatSnackBar);
    });


    it('should have instance', () => {
        expect(service).toBeTruthy();
    });

    it('should have defualt properties defined', () => {
        expect(service.configuration).toEqual({
            duration: 2000
        });
        expect(service.defaultAction).toBe('close');
    });

    it('should have notify method', () => {
        expect(service.notify).toBeTruthy();
    });

    it('expeced paramter should passs to mat snackbar.open', fakeAsync(() => {
        service.notify('test');
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('close');
        expect(matSnackBar.config).toEqual({ duration: 2000 });

        service.notify('test', 'finish');
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('finish');
        expect(matSnackBar.config).toEqual({ duration: 2000 });

        service.notify('test', 'finish', { duration: 3000 });
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('finish');
        expect(matSnackBar.config).toEqual({ duration: 3000 });

        service.notify('test', '', { duration: 3000 });
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('close');
        expect(matSnackBar.config).toEqual({ duration: 3000 });

        service.notify('test', null, { duration: 3000 });
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('close');
        expect(matSnackBar.config).toEqual({ duration: 3000 });

        service.notify('test', undefined, { duration: 3000 });
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('close');
        expect(matSnackBar.config).toEqual({ duration: 3000 });

        service.notify('test', 'finish', null);
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('finish');
        expect(matSnackBar.config).toEqual({ duration: 2000 });

        service.notify('test', 'finish', undefined);
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('finish');
        expect(matSnackBar.config).toEqual({ duration: 2000 });

        service.notify('test', 'finish');
        expect(matSnackBar.message).toBe('test');
        expect(matSnackBar.action).toBe('finish');
        expect(matSnackBar.config).toEqual({ duration: 2000 });

        service.notify(undefined);
        expect(matSnackBar.message).toBeUndefined();
        expect(matSnackBar.action).toBe('close');
        expect(matSnackBar.config).toEqual({ duration: 2000 });

        service.notify(null);
        expect(matSnackBar.message).toBeNull();
        expect(matSnackBar.action).toBe('close');
        expect(matSnackBar.config).toEqual({ duration: 2000 });

        service.notify('');
        expect(matSnackBar.message).toBe('');
        expect(matSnackBar.action).toBe('close');
        expect(matSnackBar.config).toEqual({ duration: 2000 });
    }));
});



