import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  configuration: MatSnackBarConfig<any> = {
    duration: 2000
  };
  defaultAction = 'close';

  constructor(private snackbar: MatSnackBar) { }

  /**
   * @description Notify with message
   * @param message
   * @param action
   * @param config
   */
  notify(message: string, action?: string, config?: MatSnackBarConfig<any>) {
    config = config ? config : this.configuration; // CHECKING IF CONFIGURATION IS NOT PASSED THEN APPLYING DEAFULT CONFIGURATION
    action = action ? action : this.defaultAction; // CHECKING IF CONFIGURATION IS NOT PASSED THEN APPLYING DEAFULT CONFIGURATION
    this.snackbar.open(message, action, config);
  }
}
