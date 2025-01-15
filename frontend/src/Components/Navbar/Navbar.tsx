import { Link, useLocation } from "react-router-dom";
import { useAuth } from "../../Context/useAuth";
import logo from "./logo92.png";



interface Props {}

const Navbar = (props: Props) => {
  const { isLoggedIn, user, logout } = useAuth();
  const location = useLocation(); // Get current route

  return (
    <nav className="relative container mx-auto p-6">
      <div className="flex items-center justify-between">
        { isLoggedIn() ? (
          <div className="flex items-center space-x-20">
            {/* Conditionally render the logo */}
            {location.pathname !== "/" && (
              <Link to="/">
                <img src={logo} alt="Logo" className="w-15 h-15 rounded-full" />
              </Link>
            )}
            <div className="hidden font-bold lg:flex space-x-6">
              <Link to="/search" className="text-gray-600 hover:text-lighGreen">
                Search
              </Link>                      
              <Link to="/offers" className="text-gray-600 hover:text-lighGreen">
                Offers
              </Link>
              <Link to="/requests" className="text-gray-600 hover:text-lighGreen">
                Request
              </Link>            
            </div>            
          </div>
        ) : (          
          <div className="flex items-center space-x-20">
            {/* Conditionally render the logo */}
            {location.pathname !== "/" && (
              <Link to="/">
                <img src={logo} alt="Logo" className="w-15 h-15 rounded-full" />
              </Link>
            )}
            <div className="hidden font-bold lg:flex space-x-6">
              <Link to="/search" className="text-gray-600 hover:text-lighGreen">
                Search
              </Link>   
            </div>
          </div>          
        )}
        { isLoggedIn() ? (         
          <div className="hidden lg:flex items-center space-x-6 text-back">
            <Link to="/profile" className="hover:text-lighGreen text-gray-600">
              Welcome, {user?.username}
            </Link>
            <a
              onClick={logout}
              className="px-8 py-3 font-bold rounded text-white hover:opacity-70 bg-lightGreen"              
            >
              Logout
            </a>
          </div>
        ) : (
          <div className="hidden lg:flex items-center space-x-6 text-back">
            <Link to="/login" className="hover:text-lighGreen text-gray-600">Login</Link>
            <Link to="/register" className="px-8 py-3 font-bold rounded text-white hover:opacity-70 bg-lightGreen"              
            >
              Sign up
            </Link>
          </div>  
        )}
      </div>
    </nav>
  );
};

export default Navbar;
