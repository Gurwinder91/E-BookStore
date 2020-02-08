
import { of } from 'rxjs';

import { OrderService } from './order.service';
import { Order } from '../../models';

describe('OrderService', () => {
  let httpClientSpy: { get: jasmine.Spy };
  httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);

  it('should be created', () => {
    const service: OrderService = new OrderService(<any>httpClientSpy);
    expect(service).toBeTruthy();
  });

  it('should return expected orders', () => {
    const order: Order[] = [{
      purchasedOn: new Date(),
      paymentMode: 'cash',
      bookName: 'Test',
      writtenIn: 'Hindi',
      bookAuthor: 'Test'
    }]
    httpClientSpy.get.and.returnValue(of(order));
    const service: OrderService = new OrderService(<any>httpClientSpy);

    service.fetchAll().subscribe(res => {
      expect(res).toEqual(order, 'Expected order received');
    })

  });
});
