import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'

const HomePage = () => {
  const [user, setUser] = useState({});
  const nav = useNavigate();

  useEffect(() => {
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/login");
    }

    const user = JSON.parse(data);
    setUser(user);

    console.log(user);
  }, []);



  return (
    <div>
     <nav className='bg-black text-white h-24 flex items-center justify-between'>
        <div className=' flex flex-col gap-1 ml-10'>
          <div className=' font-extrabold text-4xl'>KURTUBA</div>
          <Link to="/Home" className='text-l font-thin' >HOME</Link>
        </div>

        <div className='flex gap-4 text-base'>
          <span className='text-[#fed478fe] font-semibold'>{user.name + " " + user.surname}</span>
          <button onClick={() => {
            localStorage.removeItem("userData");
            nav("/Login"); //bulunduğu sayfayı yeniden yüklemeye yarar ama biz logine yönlendirmeliyiz
          }} className='mr-4 text-red-700'>LOGOUT</button>
        </div>
      </nav>

      <div className='text-white flex flex-col  gap-4 items-center w-[300px] min-h-screen'>
        <h1 className='text-xl font-serif mt-[60px] hover:border-b-2'>GENERAL OPERATIONS</h1>
        {(user.roleName === "manager") && (
          <div className='text-white flex flex-col  gap-4 items-center w-[300px]'>
            <Link to="/Changerole" className='   bg-[#fab914fe] py-2 px-3 font-semibold  hover:bg-[#fec752] rounded-sm mt-[30px]'>CHANGE ROLE</Link>
            <Link to="/AubookRequest" className=' bg-[#fcb92afe] py-2 px-3  font-semibold rounded-sm hover:bg-[#fec752] '>AUTHOR BOOK REQUEST</Link>
          </div>
        )}
        {(user.roleName === "manager" || user.roleName === "staff") && (
          <div className='text-white flex flex-col  gap-4 items-center w-[300px]'>
            <Link to="/Punishing" className=' bg-[#fcb92afe] py-2 px-3 rounded-sm  font-semibold hover:bg-[#fec752]'>PUNISH</Link>
            <Link to="/AccountRequest" className=' bg-[#fcb92afe] py-2 px-3  font-semibold rounded-sm hover:bg-[#fec752]'>REGISTER REQUESTS</Link>
            <Link to="/BorrowRequest" className=' bg-[#fcb92afe] py-2 px-3  font-semibold rounded-sm hover:bg-[#fec752]'>BORROW REQUESTS</Link>
          </div>
        )}
        {(user.roleName === "author") && (
          <Link to="/AuMybook" className=' bg-[#fcb92afe] py-2 px-3  font-semibold rounded-sm hover:bg-[#fec752] mt-[30px]'> MY BOOKS</Link>
        )}
      
         <Link to="/Booksearch" className=' bg-[#fcb92afe] py-2 px-3  font-semibold rounded-sm hover:bg-[#fec752] mt-[30px]'> SEARCH BOOK</Link>
         <Link to="/BorrowedBooks" className=' bg-[#fcb92afe] py-2 px-3  font-semibold rounded-sm hover:bg-[#fec752]'> MY BORROWED BOOKS</Link>
        <Link to="/Messaging" className=' bg-[#fcb92afe] py-2 px-3  font-semibold rounded-sm hover:bg-[#fec752] '> MESSAGING</Link>
        <Link to="/Inbox" className=' bg-[#fcb92afe] py-2 px-3  font-semibold rounded-sm hover:bg-[#fec752]'> INBOX</Link>
    
       

      </div>

    </div>
  )
}

export default HomePage