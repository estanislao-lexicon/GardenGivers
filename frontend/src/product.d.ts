  export interface ProductSearch {
    productId: number;
    productName: string;
    productDescription: string;
    offers: Offer[];
  }

  export interface Offer {
    offerId: number;
    offerDescription: string;
    quantity: number;
    isFree: boolean;
    price: number;
    expirationDate: string;
  }

  export interface Request {
    requestId: number;
    offerId: number;
    quantity: number;
    dateCreated: string;
  }
