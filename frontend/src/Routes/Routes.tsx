import { createBrowserRouter } from "react-router";
import HomePage from "../Pages/HomePage/HomePage";
import SearchPage from "../Pages/SearchPage/SearchPage";
import ProductsPage from "../Pages/ProductsPage/ProductsPage";
import RequestsPage from "../Pages/RequestsPage/RequestsPage";
import OffersPage from "../Pages/OffersPage/OffersPage";
import App from "../App";
import LoginPage from "../Pages/LoginPage/LoginPage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import ProtectedRoute from "./ProtectedRoute";
import ProfilePage from "../Pages/ProfilePage/ProfilePage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {  path: "", element: <HomePage /> },
            {  path: "login", element: <LoginPage /> },
            {  path: "register", element: <RegisterPage /> },
            {  path: "search", element: <SearchPage /> },
            {  path: "offers", element: <ProtectedRoute><OffersPage /></ProtectedRoute> },
            {  path: "requests", element: <ProtectedRoute><RequestsPage /></ProtectedRoute> },
            {  path: "product", element: <ProtectedRoute><ProductsPage /></ProtectedRoute>},
            {  path: "profile", element: <ProtectedRoute><ProfilePage /></ProtectedRoute>},
        ],            
    },    
]);

