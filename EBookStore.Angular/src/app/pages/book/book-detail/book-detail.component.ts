import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { mergeMap } from 'rxjs/operators';

import { BookService } from '../../../services/book/book.service';
import { BookDetails } from '../../../models';
import { NotificationService } from '../../../services/notification/notification.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.scss']
})
export class BookDetailComponent implements OnInit {

  book: BookDetails;

  constructor(private bookService: BookService,
     private activatedRoute: ActivatedRoute,
     private notificationService: NotificationService) { }

  ngOnInit() {
    this.activatedRoute.params.pipe(
      mergeMap((params: Params) => this.bookService.fetchSpecificBook(Number(params.bookId))
      ))
    .subscribe(res => {
      this.book = res;
    })
  }

  buyBook(){
    this.bookService.purchaseBook(this.book.id).subscribe(res => {
      this.notificationService.notify("Thanks for buying book");
    })
  }

}
