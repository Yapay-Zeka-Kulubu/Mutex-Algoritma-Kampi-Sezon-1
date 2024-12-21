import React, { useState, useEffect } from 'react';
import { Navigate, useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';

export default function Login() {
  // http://localhost:5075/api/Account/girisYap
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const nav = useNavigate();

  const handleSigninClick = async (e) => {
    e.preventDefault();
    
    const data = {
      email: email,
      password: password,
    };

    const yanit = await fetch("http://localhost:5075/api/Account/girisYap",{
      method:"POST",
      headers: { "Content-Type": "application/json"},
      body: JSON.stringify(data)
    });


    if (yanit.ok) {
      const data = await yanit.json();
      console.log(data);
      localStorage.setItem("userData", JSON.stringify(data.userdto));
      nav("/HomePage");
    } else {
      toast.error("Your account could not found");
    }
    
  };
  return (
    <div className="flex w-full h-screen">


      <div className="w-full lg:w-1/2 flex items-center justify-center">
        <div className='bg-white px-10 py-20 rounded-3xl border-2 border-gray-50 max-w-lg mx-auto'>
          <h1 className='mt-3 text-4xl font-bold text-center text-gray-800'>
            Welcome Back
          </h1>

          <div className='mt-8'>
            <div>
              <label className='text-base font-medium'>Email</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your email'
                onChange={e => setEmail(e.target.value)}

              />
            </div>

            <div className='mt-4'>
              <label className='text-base font-medium'>Password</label>
              <input
                className='w-full h-12 border border-gray-300 rounded-xl p-4 mt-1 bg-transparent'
                placeholder='Enter your password'
                type='password'
                onChange={e => setPassword(e.target.value)}

              />
            </div>


            <div className='mt-8 flex flex-col gap-y-4'>
              <button onClick={handleSigninClick} className='py-3 rounded-xl bg-violet-500 text-white text-lg font-bold'>
                Sign in
              </button>
            </div>

            <div className='mt-8 flex justify-center items-center'>
              <p className='font-medium text-base'>Don't have an account</p>

              <Link className='text-violet-500 text-base font-medium ml-2' to="/Register">
                Sign up
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