import { createContext, useEffect, useState } from "react";
import { UserProfileLogin } from "../Models/User";
import { useNavigate } from "react-router-dom";
import { loginAPI, registerAPI } from "../Services/AuthService";
import { toast } from "react-toastify";
import React from "react";
import axios from "axios";


type UserContextType = {
    user: UserProfileLogin | null;    
    token: string | null;
    registerUser: (
        email: string,
        username: string, 
        password: string, 
        firstName: string, 
        lastName: string, 
        address: string, 
        postNumber: string, 
        city: string
    ) => void;
    loginUser: (username: string, password: string) => void;
    logout: () => void;
    isLoggedIn: () => boolean;    
};

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
    const navigate = useNavigate();
    const [token, setToke] = useState<string | null>(null);
    const [user, setUser] = useState<UserProfileLogin | null>(null);    
    const [isReady, setIsReady] = useState(false);

    useEffect(() => {            
        const user = localStorage.getItem("user");
        const token = localStorage.getItem("token");
        if(user && token) {
            setUser(JSON.parse(user));
            setToke(token);            
            axios.defaults.headers.common["Authorization"] = "Bearer" + token;
        }
        setIsReady(true);
    }, []);

    const registerUser = async (
        username: string,
        email: string,
        password: string,
        firstName: string,
        lastName: string,
        city: string,
        addres: string,
        postNumber: string
    ) => {
        await registerAPI(username, email, password, firstName, lastName, city, addres, postNumber)
            .then((res) => {
            if(res) {
                localStorage.setItem("token", res?.data.token);
                const userObj = {
                    username: res?.data.username,
                    email: res?.data.email                    
                }
                localStorage.setItem("user", JSON.stringify(userObj));
                setToke(res?.data.token!);
                setUser(userObj!);
                toast.success("Register Success!")
                navigate("/search");
            }
        }).catch((e) => toast.warning("Server error occured"));
    };

    const loginUser = async (username: string, password: string,) => {
        await loginAPI(username, password)
            .then((res) => {
            if(res) {                
                localStorage.setItem("token", res?.data.token);                
                const userObj = {
                    username: res?.data.username,
                    email: res?.data.email,                    
                }
                localStorage.setItem("user", JSON.stringify(userObj));
                setToke(res?.data.token!);
                setUser(userObj!);                
                toast.success("Login Success!")
                navigate("/search");
            }
        }).catch((e) => toast.warning("Server error occured"));
    };

    const isLoggedIn = () => !!user;
    

    const logout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");        
        setUser(null);
        setToke("");
        navigate("/");
    }

    return(
        <UserContext.Provider value={{ loginUser, user, token, logout, isLoggedIn, registerUser, }}
        >
            {isReady ? children : null}
        </UserContext.Provider>
    )
};

export const useAuth = () => React.useContext(UserContext);
