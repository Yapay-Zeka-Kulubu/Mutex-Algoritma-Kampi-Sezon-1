import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
//özge
//Approve ve reject butonları çaşışmıyor

const BorrowRequest = () => {
  const [reqBooks, setreqBooks] = useState([]); 
  const [user, setUser] = useState({});
  const nav = useNavigate();
  
  const checkUser = () => {
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/Login");
      return;
    }
    
    const user = JSON.parse(data);
    setUser(user);

    if (user.roleName !== "manager" && user.roleName !== "staff") {
     nav("/");
     return;
    }
  }


  const borrowRequest = async () => {
    const yanit = await fetch(`http://localhost:5249/api/Book/getBorrowRequests`, {
      method: "GET"
    });

    if (yanit.ok) {
      const reqBooks = await yanit.json();
      setreqBooks(reqBooks);
    }
  }

  useEffect(() => {
    borrowRequest();
    checkUser();
  }, [])

  const ApproveReq = async (id) => {
    const request ={
      requestId: id,
      confirmation: true
    }
    const yanit = await fetch(`http://localhost:5249/api/Book/setBorrowRequest`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(request),
    });
    if (yanit.ok) {
     const data=await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }
    else {
      const data = await yanit.json();
    toast.error(data.message);
    }
  }

  const RejectReq = async (id) => {
    const request = {
      requestId: id,
      confirmation: false
    }
    const yanit = await fetch(`http://localhost:5249/api/Book/setBorrowRequest`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(request),
    });
    if (yanit.ok) {
      const data= await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });

    }
    else {
      const data = await yanit.json();
      toast.error(data.message);

    }
  }

  return (
    <div>
     <nav className='bg-black text-white h-24 flex items-center justify-between'>
        <div className=' flex flex-col gap-1 ml-10'>
          <div className=' font-extrabold text-4xl'>KURTUBA</div>
          <Link to="/Home" className='text-l font-thin' >HOME</Link>
        </div>

        <div className='flex gap-4 text-base'>
        <span className='text-[#fed478fe] font-semibold '>{user.name + " " + user.surname}</span>
            <button onClick={() => {
              localStorage.removeItem("userData");
              nav("/Login");
              }} className='mr-4 text-red-700'>LOGOUT</button>
        </div>
      </nav>

      {/* underside*/}
      <div className='flex flex-row'>
        {/* sidebar */}
        <div className='text-white bg-black  flex flex-col gap-8 items-center w-[300px] min-h-screen'>
          <h1 className='text-xl font-serif mt-[60px] hover:border-b-2'>MEMBER OPERATIONS</h1>
          <Link to="/AccountRequest" className=' bg-[#fab914fe] py-3 px-7 text-lg font-semibold rounded-sm mt-[30px] hover:bg-[#fec752]'>REGISTER REQUESTS</Link>

        </div>
        {/* table */}
        <div className=' bg-white w-[1220px] h-[780px] overflow-y-auto max-h-[780px]'>

          <table className=' bg-white text-black w-[1220px] '>
            <thead className='bg-[#f9dc7654] text-sm'>
              <tr className='border-b-2 border-black'>
                <th className='py-3 pl-4 pr-[200px] font-serif'>BOOK</th>
                <th className='py-3  pr-[100px] font-serif'>REQUESTOR</th>
                <th className='py-3  pr-[100px] font-serif'>BORROW DATE</th>
                <th className='py-3  pr-[100px] font-serif'>RETURN DATE</th>
                <th className='py-3  pr-[270px] font-serif'>ACTIONS</th>
              </tr>
            </thead>
            {/* burada db de göremediğim için parametreleri rastgele atadım */}
            <tbody className='text-black text-base'>
              {reqBooks.map((request, index) => (
                <tr className='border-b-2 border-black'>
                  <td className='py-3 pl-4 font-bold'>{request.bookTitle}</td>
                  <td className='py-3 font-medium'>{request.userFullname}</td>
                  <td className='py-3 font-medium'>{request.borrowDate}</td>
                  <td className='py-3 font-medium'>{request.returnDate}</td>
                  <td className='py-2 flex flex-row gap-3'>
                    <button onClick={() => ApproveReq(request.id)} className='bg-[#19871b] text-white rounded-md text-sm font-medium p-2 hover:bg-[#58bb46d2] ml-3 '>APPROVE</button>
                    <button onClick={() => RejectReq(request.id)} className='bg-[#d51760fe] text-white rounded-md text-sm font-medium p-2 hover:bg-[#ec5b67d6]'>REJECT</button>
                    {/* setborrowrequestden approve ve reject çekeceğim */}
                    </td>
                </tr>
              ))}





            </tbody>
          </table>
        </div>
      </div>

    </div>
  )
}

export default BorrowRequest
