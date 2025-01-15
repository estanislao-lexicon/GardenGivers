import React from "react";
import "./Navbar.css";
import { Link } from "react-router-dom";



interface Props {}

const Navbar = (props: Props) => {
  return (
    <nav className="relative container mx-auto p-6">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">          
          <div className="hidden font-bold lg:flex">
            <Link to="/search" className="text-gray-600 hover:text-lighGreen">
              Search
            </Link>
          </div>
        </div>
        <div className="hidden lg:flex items-center space-x-6 text-back">
          <div className="hover:text-lighGreen text-gray-600">Login</div>
          <a
            href=""
            className="px-8 py-3 font-bold rounded text-white hover:opacity-70 bg-lightGreen"
            
          >
            Signup
          </a>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
