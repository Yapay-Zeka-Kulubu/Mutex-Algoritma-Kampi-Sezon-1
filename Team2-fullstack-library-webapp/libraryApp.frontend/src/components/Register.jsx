import * as React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useState, useEffect } from "react";
import { toast } from 'react-toastify';

export default function Register() {

  const nav = useNavigate();
  
  const [formData, setFormData] = useState({
    isim: "",
    soyIsim: "",
    email: "",
    password: "",
    passwordConfirm: ""
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (formData.password !== formData.passwordConfirm) {
      alert("Passwords do not match!");
      return;
    }


   
    try {
      const yanit = await fetch("http://localhost:5075/api/Account/KayitOl", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({
          isim: formData.isim,
          soyIsim: formData.soyIsim,
          email: formData.email,
          password: formData.password
        })
      });

      if (!yanit.ok) 
        {
          toast.su("Error occurred.", {
            onClose: () => nav(0)
          });
        }
        else{
          toast.success("Register request has sent.", {
            onClose: () => nav("/login")
          });
        }
    } catch (error) {
      console.error("Error:", error);
    }
  };
  return (
    <div className="flex w-full h-screen">


      <div className="w-full lg:w-1/2 flex items-center justify-center">
        <div className='bg-white px-10 py-20 rounded-3xl border-2 border-gray-50 max-w-lg mx-auto'>
          <h1 className='mt-3 text-4xl font-bold text-center text-gray-800'>
            Create an Account
          </h1>

          <p className='font-medium text-lg text-gray-500 mt-4 text-center'>
            Please fill in your details to create a new account.
          </p>

          <div className='mt-8'>
            <div>
              <label className='text-base font-medium'>First Name</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your first name'
                name="isim"
                value={formData.isim}
                onChange={handleInputChange}
              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Last Name</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your last name'
                name="soyIsim"
                value={formData.soyIsim}
                onChange={handleInputChange}
              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Email</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your email'
                name="email"
                value={formData.email}
                onChange={handleInputChange}
              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Password</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your password'
                type="password"
                name="password"
                value={formData.password}
                onChange={handleInputChange}
              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Password Confirm</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Confirm your password'
                type='password'
                name="passwordConfirm"
                value={formData.passwordConfirm}
                onChange={handleInputChange}
              />
            </div>

            <div className='mt-8 flex flex-col gap-y-4'>
              <button onClick={handleSubmit} className='py-3 rounded-xl bg-violet-500 text-white text-lg font-bold'>
                Sign up
              </button>
            </div>

            <div className='mt-8 flex justify-center items-center'>
              <p className='font-medium text-base'>Already have an account?</p>

              <Link className='text-violet-500 text-base font-medium ml-2' to="/Login">
                Sign in
              </Link>

            </div>
          </div>
        </div>
      </div>


      <div className="hidden lg:flex w-1/2 items-center justify-center relative bg-gray-200">
        <div className="w-60 h-60 bg-gradient-to-tr from-violet-300 to-blue-950 rounded-full animate-pulse" />
        <div className="w-full h-1/2 absolute bottom-0 bg-white/10 backdrop-blur-lg" />
      </div>
    </div>
  );
}
