import { TestBed, async } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HTTP_INTERCEPTORS, HttpClient, HttpHeaders } from '@angular/common/http';

import { AuthService } from '../services/auth/auth.service';
import { TokenAppenderInterceptor } from './token-appender.interceptor';

class MockedAuthService {
    get tokenWithBearer(): string {
        return 'Bearer 122352sfgsfsd43432';
    }
}

const URL = '/api/unit_test';

describe('Token Appender Interceptor', () => {
    let authService: AuthService;
    let httpMock: HttpTestingController;
    let httpClient: HttpClient;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [
                { provide: AuthService, useClass: MockedAuthService },
                { provide: HTTP_INTERCEPTORS, useClass: TokenAppenderInterceptor, multi: true },
            ]
        });
    });

    beforeEach(() => {
        authService = TestBed.get(AuthService);
        httpMock = TestBed.get(HttpTestingController);
        httpClient = TestBed.get(HttpClient);
    });

    afterEach(() => {
        httpMock.verify();
    });

    it('Every request should have Authorization header', async(() => {
        httpClient.get(URL).subscribe(response => {
            expect(response).toBeTruthy();
        });

        const REQ = httpMock.expectOne(URL);
        expect(REQ.request.headers.has('Authorization')).toBeTruthy();

        REQ.flush([{ status: 'Success' }]);
    }));

    it('should append token with each and every request', async(() => {
        httpClient.get(URL).subscribe(response => {
            expect(response).toBeTruthy();
        });

        const REQ = httpMock.expectOne(URL);
        const TOKEN = authService.tokenWithBearer;
        expect(REQ.request.headers.get('Authorization')).toMatch(TOKEN);

        REQ.flush([{ status: 'Success' }]);
    }));

    it('should not append token if (NO_AUTH) header is present', async(() => {
        const HTTP_HEADERS = { headers: new HttpHeaders({ 'NO_AUTH': 'TRUE' }) };
        httpClient.get(URL, HTTP_HEADERS).subscribe(response => {
            expect(response).toBeTruthy();
        });

        const REQ = httpMock.expectOne(URL);

        expect(REQ.request.headers.has('NO_AUTH')).toBeFalsy();
        expect(REQ.request.headers.has('Authorization')).toBeFalsy();

        REQ.flush([{ status: 'Success' }]);
    }));
});
