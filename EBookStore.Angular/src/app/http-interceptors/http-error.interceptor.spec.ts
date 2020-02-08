import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HTTP_INTERCEPTORS, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import { HttpErrorInterceptor } from './http-error.interceptor';
import { NotificationService } from '../services/notification/notification.service';

const URL = '/api/unit_test';

class MockedNotificationService {
    loggedMessage: string;
    notify(message: string) {
        this.loggedMessage = message;
    }
}

class MockedRouter {
    navigatedUrl = false;
    navigate(commands: any[]) {
        this.navigatedUrl = commands[0];
    }
}

describe('Http Error Interceptor', () => {
    let httpMock: HttpTestingController;
    let httpClient: HttpClient;
    let notificationService: any;
    let router: any;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [
                { provide: NotificationService, useClass: MockedNotificationService },
                { provide: Router, useClass: MockedRouter },
                { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
            ]
        });
    });

    beforeEach(() => {
        notificationService = TestBed.get(NotificationService);
        router = TestBed.get(Router);
        httpMock = TestBed.get(HttpTestingController);
        httpClient = TestBed.get(HttpClient);
    });

    afterEach(() => {
        httpMock.verify();
    });

    it('should catch http 400 error ', () => {

        httpClient.get(URL).subscribe(response => {
            fail('request fail with bad request');
        }, (error: HttpErrorResponse) => {
            expect(error.status).toBe(400);
            expect(error.error['Error']).toBe('code should be unique');
        });

        const REQ = httpMock.expectOne(URL);

        REQ.flush({ Error: 'code should be unique' }, { status: 400, statusText: 'Bad Request' });

        expect(notificationService.loggedMessage).toBe('code should be unique');
    });


    it('should redirect to signin page if http error has 401 error code ', () => {

        httpClient.get(URL).subscribe(response => {
            fail('request fail with bad request');
        }, (error: HttpErrorResponse) => {
            expect(error.status).toBe(401);
        });

        const REQ = httpMock.expectOne(URL);

        REQ.flush(null, { status: 401, statusText: 'UnAuthorized' });

        expect(router.navigatedUrl).toBe('/account/signin');
    });

    it('should catch http error other then 400 0r 401 with expected message ', () => {

        httpClient.get(URL).subscribe(response => {
            fail('request fail with bad request');
        }, (error: HttpErrorResponse) => {
            expect(error.status).toBe(500);
        });

        const REQ = httpMock.expectOne(URL);

        REQ.flush({ error: { Error: 'code should be unique' } }, { status: 500, statusText: 'Internal Server Error' });

        expect(notificationService.loggedMessage).toBe('Something went wrong');
    });
});
