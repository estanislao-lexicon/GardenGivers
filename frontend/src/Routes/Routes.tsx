import { createBrowserRouter } from "react-router";
import HomePage from "../Pages/HomePage/HomePage";
import SearchPage from "../Pages/SearchPage/SearchPage";
import ProductPage from "../Pages/ProductPage/ProductPage";
import App from "../App";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {  path: "", element: <HomePage /> },
            { path: "search", element: <SearchPage /> },
            {  path: "product", element: <ProductPage />},
        ],            
    },    
]);

