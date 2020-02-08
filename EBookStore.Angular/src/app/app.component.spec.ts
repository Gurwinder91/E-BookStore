import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';

import { BsSharedTestModule } from './shared/bs-shared-test.module';
import { AuthService } from './services/auth/auth.service';

let authServiceSpy: jasmine.SpyObj<AuthService>;

describe('AppComponent', () => {
  const spy = jasmine.createSpyObj('AuthService', ['isLoggedIn']);

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        BsSharedTestModule
      ],
      providers: [{
        provide: AuthService,
        useValue: spy
      }
      ],
      declarations: [
        AppComponent
      ],
    }).compileComponents();

    authServiceSpy = TestBed.get(AuthService);
    
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'e-bookstore'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Ebookstore');
  });

  it('should Have App Name if user has login', () => {
    const fixture = TestBed.createComponent(AppComponent);
    authServiceSpy.isLoggedIn.and.returnValue(true);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelectorAll('.mat-toolbar span')[0].textContent).toContain('Ebookstore');
  });

  it('toolbar should not show if user has no login', () => {
    const fixture = TestBed.createComponent(AppComponent);
    authServiceSpy.isLoggedIn.and.returnValue(false);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('.mat-toolbar')).toBeNull();
  });
});
