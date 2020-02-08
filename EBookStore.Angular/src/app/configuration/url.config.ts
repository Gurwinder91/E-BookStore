
import { environment } from '../../environments/environment';

export const URLS = {
    books: `${environment.apiBaseUrl}book`,
    specificBook: `${environment.apiBaseUrl}book/`,
    token: `${environment.apiBaseUrl}user/token`,
    orders: `${environment.apiBaseUrl}user/orders`,
    purchaseBook: `${environment.apiBaseUrl}purchasebook`
};
