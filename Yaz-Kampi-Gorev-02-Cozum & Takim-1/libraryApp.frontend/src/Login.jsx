import React, { useState } from 'react'
import { MdOutlineLocalLibrary } from "react-icons/md";
import {Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';


const Login = () => {

    const [username, setusername] = useState("");
    const [password, setpassword] = useState("");

    const nav = useNavigate();

    const uyesor = async (e) => {
      e.preventDefault();
        const user = {
          username: username,
          password: password,
        }
    
        const yanit = await fetch(`http://localhost:5249/api/Account/Login`, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(user),
        });

        if(yanit.ok){
          const user = await yanit.json();
          console.log(user);
          localStorage.setItem("userData", JSON.stringify(user.userDTO));
          nav("/");
        }
          else {
            const data =await yanit.json();
            toast.error(data.message);
            return;
        }
      }

  return (
    <div className='place-self-center bg-white h-[550px] w-[450px] p-20 rounded-xl flex flex-col gap-4 '>
      {/* title */}
      <div className='flex flex-col justify-center items-center gap-5'>
         <MdOutlineLocalLibrary className='text-5xl text-black font-bold '/> {/* adding icon */}
         <h1 className='text-3xl text-center text-black font-bold tracking-wider'>SIGN IN</h1>
      </div>
      <form className='bg-white h-[300px] rounded-md text-black text-base 
       tracking-wide p-8 flex flex-col gap-5 border border-black cursor-pointer mt-2'>
        <div>
            <label>USERNAME</label>
            <input onChange={e => setusername(e.target.value)} type='text' className='border-b-2 border-pink-600 bg-[#c1c2be33] text-black
              hover:bg-[#9fa19e44] transition-all focus: outline-none'></input>
        </div>
        <div>
            <label>PASSWORD</label>
            <input onChange={e => setpassword(e.target.value)} type='password' className='border-b-2 border-pink-600 bg-[#c1c2be33] text-black
              hover:bg-[#9fa19e44] transition-all focus: outline-none'></input>
        </div>
            <button onClick={uyesor} className='bg-[#d51760fe] rounded-md text-white h-[30px] w-auto py-1 px-2
             place-self-center hover:bg-[#ec5b67d6] transition-all'>SIGN IN</button>
             <div className='flex flex-col gap-2 items-center'>        
            <Link to="/Register" className='bg-[#d51760fe] rounded-md text-white h-[30px] w-auto py-1 px-2
             place-self-center hover:bg-[#ec5b67d6]'> SIGN UP</Link>
              <p className='text-sm mt-1'>Do not have an account?</p>
             </div>
        </form>
      
    </div>
    )
}

export default Login
