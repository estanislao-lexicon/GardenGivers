import axios from 'axios';
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

export const searchUserProfile = async () => {
    
    const token = localStorage.getItem("token");
            
    try {        
        const response = await fetch('http://localhost:5033/api/account/user', {
            method: 'GET',
            headers: {
              'accept': '*/*',
              'Authorization': `Bearer ${token}`,
            },
          });
        console.log("response: ", response);  
        // Return the `data` field (the actual UserSearch object)
        return response.json();  
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
