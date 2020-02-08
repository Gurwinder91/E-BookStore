import { of } from 'rxjs';

import { AuthService } from './auth.service';
import { IterableDiffers } from '@angular/core';


describe('AuthService', () => {
  let httpClientSpy: { post: jasmine.Spy };
  httpClientSpy = jasmine.createSpyObj('HttpClient', ['post']);

  it('should be created', () => {
    const service: AuthService = new AuthService(<any>httpClientSpy);
    expect(service).toBeTruthy();
  });

  it('user can login and get login', () => {
    const expectedResult = {
      email: 'abc@gmail.com',
      token: 'dfdsfdsfdsfdsf'
    };
    
    httpClientSpy.post.and.returnValue(of(expectedResult));
    const service: AuthService = new AuthService(<any>httpClientSpy);
    service.login({email: 'abc@gmail.com', password: '123456'}).subscribe(res => {
      expect(res).toEqual(expectedResult, 'expected User login response')
    })
  });

  it('user should be login if session Storage having (userToken) key', () => {
    sessionStorage.setItem('userToken', 'dfdfdfdsf');
    const service: AuthService = new AuthService(<any>httpClientSpy);
    expect(service.isLoggedIn).toBeTruthy();

    sessionStorage.removeItem('userToken')
  })

  it('token() method should return if session Storage having (userToken) key', () => {
    const token = 'fdsfdsfdsf';
    sessionStorage.setItem('userToken', token);
    const service: AuthService = new AuthService(<any>httpClientSpy);
    expect(service.token).toBe(token);
    sessionStorage.removeItem('userToken')
  })

  it('tokenWithBearer() method should return bearer token', () => {
    const token = 'fdsfdsfdsf';
    sessionStorage.setItem('userToken', token);
    const service: AuthService = new AuthService(<any>httpClientSpy);
    expect(service.tokenWithBearer).toBe(`Bearer ${token}`);
    sessionStorage.removeItem('userToken')
  })

});
