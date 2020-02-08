
import { of } from 'rxjs';

import { OrdersComponent } from './orders.component';
import { Order } from '../../models';

describe('OrdersComponent', () => {

  let orderServiceSpy: { fetchAll: jasmine.Spy };
  orderServiceSpy = jasmine.createSpyObj('OrderService', ['fetchAll']);

  it('should create', () => {
    const component: OrdersComponent = new OrdersComponent(<any>orderServiceSpy);
    expect(component).toBeTruthy();
  });

  it('receive all orders from service', () => {
    const component: OrdersComponent = new OrdersComponent(<any>orderServiceSpy);
    const order: Order[] = [{
      purchasedOn: new Date(),
      paymentMode: 'cash',
      bookName: 'Test',
      writtenIn: 'Hindi',
      bookAuthor: 'Test'
    }]
    orderServiceSpy.fetchAll.and.returnValue(of(order));
    component.ngOnInit();
    expect(component.dataSource).toBeDefined();
  });
});
