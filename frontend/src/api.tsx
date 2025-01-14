import axios from 'axios';

export interface Offer {
    offerId: number;
    offerDescription: string;
    price: number;
}

export interface ProductSearch {
    productId: number;
    productName: string;
    productDescription: string;
    offers: Offer[];
}

export const searchProductById = async (query: string): Promise<ProductSearch | string> => {
    try {
        const response = await axios.get<ProductSearch >(
            `http://localhost:5033/api/product/${query}`
        );
        console.log("response: ", response.data);  
        // Return the `data` field (the actual ProductSearch object)
        return response.data;  
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An unexpected error occurred";
        }
    }
};
