import "./Hero.css";
import { Link } from "react-router-dom";
import logo from "./logo512.png";

interface Props {}

const Hero = (props: Props) => {
  return (
    <section id="hero">
      <div className="container flex flex-col-reverse mx-auto p-8 lg:flex-row lg:items-center">
        <div className="flex flex-col space-y-10 mb-44 m-10 lg:m-10 xl:m-20 lg:mt-16 lg:w-1/2 xl:mb-52">
          <h1 className="text-5xl font-bold text-center text-gray-600 lg:text-6xl lg:max-w-md lg:text-left">
            Connect, share, and reduce food waste!
          </h1>
          <p className="text-2xl text-center text-gray-400 lg:max-w-md lg:text-left">
            Join the sharing economy within local communities. Share or sell homegrown fruit & vegetables, hunting meats, wild fruits, and mushrooms picked from the forest.
          </p>
          <div className="mx-auto lg:mx-0">
            <Link
              to="/search"
              className="py-5 px-10 text-2xl font-bold text-white rounded lg:py-4 hover:opacity-70 bg-lightGreen"
            >
              Get Started
            </Link>
          </div>
        </div>

        {/* Logo aligned to the right and on the same line as the h1 */}
        <div className="lg:ml-0 flex items-end">
          <img src={logo} alt="Logo" className="h-30 md:h-38 lg:h-46 xl:h-50" />
        </div>
      </div>
    </section>
  );
};

export default Hero;
