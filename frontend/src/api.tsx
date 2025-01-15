import axios from 'axios';
import { UserSearch } from './user';
import { ProductSearch } from './product';


export const searchProductByName = async (query: string): Promise<ProductSearch | string> => {
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

export const searchUserByUserName = async (query: string) => {
    try {
        const response = await axios.get<UserSearch>(
            "http://localhost:5033/api/account/user",
        );
        console.log("response: ", response.data);  
        // Return the `data` field (the actual UserSearch object)
        return response.data;  
    } catch (error : any) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
            return error.message;
        } else {
            console.log("unexpected error: ", error);
            return "An unexpected error occurred";
        }
    }
};
