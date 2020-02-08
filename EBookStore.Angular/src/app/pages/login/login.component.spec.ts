
import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let authServiceSpy: { login: jasmine.Spy };
  authServiceSpy = jasmine.createSpyObj('AuthService', ['login']);

  let routerSpy: { navigate: jasmine.Spy };
  routerSpy = jasmine.createSpyObj('Router', ['navigate']);

  it('should create', () => {
    const component: LoginComponent = new LoginComponent(<any>authServiceSpy, <any>routerSpy);
    expect(component).toBeTruthy();
  });

  it('should have login form', () => {
    const component: LoginComponent = new LoginComponent(<any>authServiceSpy, <any>routerSpy);
    component.ngOnInit();
    expect(component.loginForm).toBeDefined();
  });

  it('form should be valid with correct data', () => {
    const component: LoginComponent = new LoginComponent(<any>authServiceSpy, <any>routerSpy);
    component.ngOnInit();
    component.email.setValue('abc@gmail.com');
    component.password.setValue('12345');
    expect(component.loginForm.valid).toBeTruthy();
  });

  it('form should be invalid with incorrect data', () => {
    const component: LoginComponent = new LoginComponent(<any>authServiceSpy, <any>routerSpy);
    component.ngOnInit();
    component.email.setValue('abcom');
    component.password.setValue('145');
    expect(component.loginForm.invalid).toBeTruthy();

    component.email.setValue('');
    component.password.setValue('');
    expect(component.loginForm.invalid).toBeTruthy();
  });

});
