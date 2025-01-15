import axios from "axios";
import { handleError } from "../Helpers/ErroHandler";
import { UserProfileToken } from "../Models/User";

const api = "http://localhost:5033/api/";


export const loginAPI = async (username: string, password: string) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/login", {
            username: username,
            password: password,
        });        
        return data;
    } catch (error) {
        handleError(error);
    }
};

export const registerAPI = async (
    username: string,
    email: string,
    password: string,
    firstName: string,
    lastName: string,
    city: string,
    address: string,
    postNumber: string
) => {
    try {
        const data = await axios.post<UserProfileToken>(api + "account/register", {
            username: username,
            email: email,
            password: password,
            firstName: firstName,
            lastName: lastName,
            city: city,
            address: address,
            postNumber: postNumber,
        });        
        return data;
    } catch (error) {
        handleError(error);
    }
};
