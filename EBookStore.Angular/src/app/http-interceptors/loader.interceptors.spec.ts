import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HTTP_INTERCEPTORS, HttpClient, HttpHeaders } from '@angular/common/http';

import { LoaderService } from '../services/loader/loader.service';
import { LoaderInterceptor } from './loader.interceptor';

const URL = '/api/unit_test';

class MockedLoaderService {
    visible = false;

    show() {
        this.visible = true;
    }

    hide() {
        this.visible = false;
    }
}

describe('Loader Interceptor', () => {
    let loaderService: any;
    let httpMock: HttpTestingController;
    let httpClient: HttpClient;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [
                { provide: LoaderService, useClass: MockedLoaderService },
                { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
            ]
        });
    });

    beforeEach(() => {
        loaderService = TestBed.get(LoaderService);
        httpMock = TestBed.get(HttpTestingController);
        httpClient = TestBed.get(HttpClient);
    });

    afterEach(() => {
        httpMock.verify();
    });

    it('Every request should call loader toggle show and hide method when intiate', () => {

        httpClient.get(URL).subscribe(response => {
            expect(response).toBeTruthy();
        });

        const REQ = httpMock.expectOne(URL);
        expect(loaderService.visible).toBeTruthy();

        REQ.flush([{ status: 'Success' }]);
        expect(loaderService.visible).toBeFalsy();
    });

    it('Every request should call loader show method if header have childSpinner key', () => {

        spyOn(loaderService, 'show').and.callThrough();

        const HTTP_HEADERS = { headers: new HttpHeaders({ 'childSpinner': 'TRUE' }) };
        httpClient.get(URL, HTTP_HEADERS).subscribe(response => {
            expect(response).toBeTruthy();
        });

        const REQ = httpMock.expectOne(URL);
        expect(REQ.request.headers.has('childSpinner')).toBeFalsy();

        REQ.flush([{ status: 'Success' }]);

        expect(loaderService.show).not.toHaveBeenCalled();
    });

});
