
import { of } from 'rxjs';

import { BookDetailComponent } from './book-detail.component';
import { BookDetails } from '../../../models';

describe('BookDetailComponent', () => {
  let bookServiceSpy: { fetchSpecificBook: jasmine.Spy };
  bookServiceSpy = jasmine.createSpyObj('BookService', ['fetchSpecificBook']);

  let notificationServiceSpy: { notify: jasmine.Spy };
  notificationServiceSpy = jasmine.createSpyObj('NotificationService', ['notify']);

  let activatedSpy: { params: jasmine.Spy };
  bookServiceSpy = jasmine.createSpyObj('BookService', ['params']);

  it('should create', () => {
    const component: BookDetailComponent = new BookDetailComponent(<any>bookServiceSpy, <any>activatedSpy, <any>notificationServiceSpy);
    expect(component).toBeTruthy();
  });

  it('books should be received from service', () => {
    const component: BookDetailComponent = new BookDetailComponent(<any>bookServiceSpy, <any>activatedSpy, <any>notificationServiceSpy);
    const book: BookDetails = {
      name: 'Test',
      authorName: 'Test',
      cost: 12,
      id: 1,
      WrittenIn: 'Hindi',
      description: 'fdfd'
    };
    bookServiceSpy.fetchSpecificBook.and.returnValue(of(book));
    
    component.ngOnInit();
    expect(component.book).toBeDefined();
  });
});
