import { of } from 'rxjs';

import { BookService } from './book.service';
import { Book, BookDetails } from '../../models';
import { BookDetailComponent } from 'src/app/pages/book/book-detail/book-detail.component';

describe('BookService', () => {
  let httpClientSpy: { get: jasmine.Spy, post: jasmine.Spy };
  httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post']);

  it('should be created', () => {
    const service: BookService = new BookService(<any>httpClientSpy);
    expect(service).toBeTruthy();
  });

  it('should return all books', () => {
    const book: Book[] = [{
      name: 'Test',
      authorName: 'Test',
      cost: 12,
      id: 1
    }]
    httpClientSpy.get.and.returnValue(of(book));
    const service: BookService = new BookService(<any>httpClientSpy);

    service.fetchAll().subscribe(res => {
      expect(res).toEqual(book, 'Expected books received');
    })
  });

  it('should return expected book', () => {
    const book: BookDetails = {
      name: 'Test',
      authorName: 'Test',
      cost: 12,
      id: 1,
      WrittenIn: 'Hindi',
      description: 'fdfd'
    };
    httpClientSpy.get.and.returnValue(of(book));
    const service: BookService = new BookService(<any>httpClientSpy);
    service.fetchSpecificBook(1).subscribe(res => {
      expect(res).toEqual(book, 'Expected book received');
    })
  });

  it('book should be purchased', () => {
    httpClientSpy.post.and.returnValue(of());
    const service: BookService = new BookService(<any>httpClientSpy);
    service.purchaseBook(1).subscribe(res => {
      expect(res).toEqual({}, 'book purchased');
    })
  });

});
