import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';

import { AuthService } from '../../services/auth/auth.service';
import { User } from '../../models';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  authenticateBtnDisabled = false;

  /**
   * @description Get password Form Control
   * @returns FormControl
   */
  get password(): FormControl {
    return this.loginForm.get('password') as FormControl;
  }

  /**
   * @description Get email Form Control
   * @returns FormControl
   */
  get email(): FormControl {
    return this.loginForm.get('email') as FormControl;
  }

  constructor(
    private authService: AuthService,
    private router: Router) {
  }


  ngOnInit() {
    this.initalizeForm();
  }

  /**
  * Intialize Form
  **/
  initalizeForm(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [
        Validators.email,
        Validators.required
      ]),
      password: new FormControl('', [
        Validators.required
      ]),
    });
  }

  /**
  * When login form will be submitted
  */
  whenSubmit(): Observable<any> | boolean {
    if (this.loginForm.invalid) {
      return false;
    }
    this.authenticateBtnDisabled = true;

    const user: User = {
      ...this.loginForm.value
    }

    this.authService.login(user).pipe(finalize(() => {
      this.authenticateBtnDisabled = false;
    })).subscribe(res => {
      this.router.navigate(['/']);
    });
  }

}
