import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatSort, MatPaginator } from '@angular/material';

import { OrderService } from '../../services/order/order.service';
import { Order } from '../../models';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  dataSource: MatTableDataSource<Order>;
  displayedColumns: string[] = ['bookName', 'writtenIn', 'bookAuthor', 'paymentMode', 'purchasedOn'];

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  
  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.orderService.fetchAll().subscribe(res => {
      this.initGrid(res);
    });
  }

  initGrid(orders: Order[]){
    this.dataSource = new MatTableDataSource(orders);   
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

}
