
import { of, Observable } from 'rxjs';
import { Params } from '@angular/router';


import { BookDetailComponent } from './book-detail.component';
import { BookDetails } from '../../../models';

describe('BookDetailComponent', () => {
  let bookServiceSpy: { fetchSpecificBook: jasmine.Spy };
  bookServiceSpy = jasmine.createSpyObj('BookService', ['fetchSpecificBook']);

  let notificationServiceSpy: { notify: jasmine.Spy };
  notificationServiceSpy = jasmine.createSpyObj('NotificationService', ['notify']);

  const mockActivatedRoute = {
    params: (): Observable<Params> => of(<Params>{bookId: 12})
  }

  it('should create', () => {
    const component: BookDetailComponent = new BookDetailComponent(<any>bookServiceSpy, <any>mockActivatedRoute, <any>notificationServiceSpy);
    expect(component).toBeTruthy();
  });

});
