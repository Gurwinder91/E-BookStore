import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

export interface LoaderState {
  show: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class LoaderService {

  private loaderSubject = new Subject<LoaderState>();
  loaderState: Observable<LoaderState>;

  constructor() {
    this.loaderState = this.loaderSubject.asObservable();
  }

  /**
   * @description pass Loader flag to loader component
   * @returns void
   */
  show(): void {
    this.loaderSubject.next(<LoaderState>{ show: true });
  }

  /**
   * @description pass loader flag to loader component
   * @returns void
   */
  hide(): void {
    this.loaderSubject.next(<LoaderState>{ show: false });
  }

}
