import React from 'react'
import * as Yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useAuth } from '../../Context/useAuth';
import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';


type Props = {}

type RegisterFormInputs = {
    username: string;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    city: string;
    address: string;
    postNumber: string;
};

const validation = Yup.object().shape({
    username: Yup.string().required("Username is required"),
    email: Yup.string().required("Email is required"),
    password: Yup.string().required("Password is required"),

    firstName: Yup.string().required("First name is required"),
    lastName: Yup.string().required("Last Name is required"),
    city: Yup.string().required("City number is required"),
    address: Yup.string().required("Address is required"),
    postNumber: Yup.string().required("Post number is required"),
});

function RegisterPage({}: Props) {
    const { registerUser } = useAuth();
    const { 
        register, 
        handleSubmit, 
        formState: { errors },
    } = useForm<RegisterFormInputs>({ resolver: yupResolver(validation)})
    
    const handleLogin = (form: RegisterFormInputs) => {
        registerUser(
            form.username, 
            form.email, 
            form.password,
            form.firstName, 
            form.lastName, 
            form.city,
            form.address, 
            form.postNumber
        );
    };

    return (
        <section className="bg-gray-50 min-h-screen flex items-center justify-center">
          <div className="w-full bg-white rounded-lg shadow dark:border sm:max-w-2xl xl:p-0 dark:bg-gray-800 dark:border-gray-700">
            <div className="p-6 space-y-4 md:space-y-6 sm:p-8">
              <h1 className="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white text-center">
                Create an Account
              </h1>
              <form className="grid grid-cols-2 gap-4" onSubmit={handleSubmit(handleLogin)}>
                {/* Email */}
                <div>
                  <label
                    htmlFor="email"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Email
                  </label>
                  <input
                    type="text"
                    id="email"
                    className="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-50 dark:border-gray-600 dark:placeholder-gray-400 dark:text-gray-700"
                    placeholder="Email"
                    {...register("email")}
                  />
                  {errors.email && <p className="text-red-500 text-sm">{errors.email.message}</p>}
                </div>
    
                {/* Username */}
                <div>
                  <label
                    htmlFor="username"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Username
                  </label>
                  <input
                    type="text"
                    id="username"
                    className="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-50 dark:border-gray-600 dark:placeholder-gray-400 dark:text-gray-700"
                    placeholder="Username"
                    {...register("username")}
                  />
                  {errors.username && <p className="text-red-500 text-sm">{errors.username.message}</p>}
                </div>
    
                {/* Password */}
                <div>
                  <label
                    htmlFor="password"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Password
                  </label>
                  <input
                    type="password"
                    id="password"
                    placeholder="••••••••"
                    className="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-50 dark:border-gray-600 dark:placeholder-gray-400 dark:text-gray-700"
                    {...register("password")}
                  />
                  {errors.password && <p className="text-red-500 text-sm">{errors.password.message}</p>}
                </div>
    
                {/* First Name */}
                <div>
                  <label
                    htmlFor="firstName"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    First Name
                  </label>
                  <input
                    type="text"
                    id="firstName"
                    className="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-50 dark:border-gray-600 dark:placeholder-gray-400 dark:text-gray-700"
                    placeholder="First name"
                    {...register("firstName")}
                  />
                  {errors.firstName && <p className="text-red-500 text-sm">{errors.firstName.message}</p>}
                </div>
    
                {/* Last Name */}
                <div>
                  <label
                    htmlFor="lastName"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Last Name
                  </label>
                  <input
                    type="text"
                    id="lastName"
                    className="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-50 dark:border-gray-600 dark:placeholder-gray-400 dark:text-gray-700"
                    placeholder="Last name"
                    {...register("lastName")}
                  />
                  {errors.lastName && <p className="text-red-500 text-sm">{errors.lastName.message}</p>}
                </div>
    
                {/* City */}
                <div>
                  <label
                    htmlFor="city"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    City
                  </label>
                  <input
                    type="text"
                    id="city"
                    className="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-50 dark:border-gray-600 dark:placeholder-gray-400 dark:text-gray-700"
                    placeholder="City"
                    {...register("city")}
                  />
                  {errors.city && <p className="text-red-500 text-sm">{errors.city.message}</p>}
                </div>
    
                {/* Address */}
                <div>
                  <label
                    htmlFor="address"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Address
                  </label>
                  <input
                    type="text"
                    id="address"
                    className="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-50 dark:border-gray-600 dark:placeholder-gray-400 dark:text-gray-700"
                    placeholder="Address"
                    {...register("address")}
                  />
                  {errors.address && <p className="text-red-500 text-sm">{errors.address.message}</p>}
                </div>
    
                {/* Post Number */}
                <div>
                  <label
                    htmlFor="postNumber"
                    className="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >
                    Post Number
                  </label>
                  <input
                    type="text"
                    id="postNumber"
                    className="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-50 dark:border-gray-600 dark:placeholder-gray-400 dark:text-gray-700"
                    placeholder="Post number"
                    {...register("postNumber")}
                  />
                  {errors.postNumber && <p className="text-red-500 text-sm">{errors.postNumber.message}</p>}
                </div>
    
                {/* Submit Button */}
                <div className="col-span-2">
                  <button
                    type="submit"
                    className="w-full text-white bg-lightGreen hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800"
                  >
                    Register
                  </button>
                  <p className="text-sm font-light text-gray-500 dark:text-gray-400">
                      Already have an account?{" "}
                      <Link to="/login" className="font-medium text-primary-600 hover:underline dark:text-primary-500"
                      >
                      Login
                      </Link>
                  </p>       
                </div>                       
              </form>
            </div>
          </div>
        </section>
      );
    }

export default RegisterPage;
