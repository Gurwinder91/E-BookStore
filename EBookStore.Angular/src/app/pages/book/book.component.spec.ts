
import { of } from 'rxjs';

import { BookComponent } from './book.component';
import { Book } from '../../models';

describe('BookComponent', () => {
  let bookServiceSpy: { fetchAll: jasmine.Spy };
  bookServiceSpy = jasmine.createSpyObj('BookService', ['fetchAll']);

  it('should create', () => {
    const component: BookComponent = new BookComponent(<any>bookServiceSpy);
    expect(component).toBeTruthy();
  });

  it('books should be received from service', () => {
    const component: BookComponent = new BookComponent(<any>bookServiceSpy);
    const books: Book[] = [{
      name: 'Test',
      authorName: 'Test',
      cost: 12,
      id: 1
    }]
    bookServiceSpy.fetchAll.and.returnValue(of(books));
    
    component.ngOnInit();
    expect(component.books).toBeDefined();
  });
});
