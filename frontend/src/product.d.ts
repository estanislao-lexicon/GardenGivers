export interface ProductSearch {
    productId: number;
    productName: string;
    productDescription: string;
    offers: Offer[];
  }

  export interface Offer {
    offerId: number;
    offerDescription: string;
    price: number;
}