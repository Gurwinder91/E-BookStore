import { Component, OnInit } from '@angular/core';

import { BookService } from '../../services/book/book.service';
import { Book } from '../../models';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {

  books: Book[];

  constructor(private bookService: BookService) { }

  ngOnInit() {
    this.bookService.fetchAll().subscribe(res => {
      this.books = res;
    })
  }

}
