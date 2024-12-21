import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

const AubookRequest = () => {
//özge
  const [requests, setrequests] = useState([]);
  const [user, setUser] = useState({});
  const nav=useNavigate();
  // const requestId= new URLSearchParams(location.search).get("requestId");
 
  const checkUser = () => {
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/Login");
      return;
    }
    
    const user = JSON.parse(data);
    setUser(user);

    if (user.roleName !== "manager") {
     nav("/");
     return;
    }
  }


  const BookCreateReq = async () => {
    const yanit = await fetch(`http://localhost:5249/api/Book/publishrequests`, {
      method: "GET"
    });
    if (yanit.ok) {
      const requests = await yanit.json();
      console.log(requests);
      setrequests(requests);
    }
  }

  useEffect(() => {
    checkUser();
    BookCreateReq();
  }, [])

  const ApproveReq = async (id) => {
    const request = {
      id: id,
      confirmation: true
    }
    const yanit = await fetch(`http://localhost:5249/api/Book/setpublishing`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(request),
    });
    if (yanit.ok) {
      const data=await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }
    else {
      const data=await yanit.json();
      toast.error(data.message);
    }
  }

  const RejectReq = async (id) => {
    const request = {
      id:id,
      confirmation: false,
    }

    const yanit = await fetch(`http://localhost:5249/api/Book/setpublishing`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(request),
    });
    if (yanit.ok) {
      const data=await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }
    else {
      const data=await yanit.json();
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
      {/*  underside */}
      <div className='flex flex-row'>
        {/* sidebar */}
        <div className='text-white bg-black  flex flex-col gap-8 items-center w-[300px] min-h-screen'>
          <h1 className='text-xl font-serif mt-[60px] hover:border-b-2'>AUTHOR OPERATIONS</h1>
          <Link to="/BookSearch" className=' bg-[#fab914fe] py-3 px-7 text-lg font-semibold rounded-sm mt-[30px] hover:bg-[#fec752] '>BOOK SEARCH</Link>

        </div>
        {/* table */}
        <div className=' bg-white w-[1220px] h-[780px] overflow-y-auto max-h-[780px]'>

          <table className=' bg-white text-black w-[1220px] '>
            <thead className='bg-[#f9dc7654]  text-sm'>
              <tr className='border-b-2 border-black'>
                <th className='py-3 pl-2 pr-[150px] font-serif'>BOOK NAME</th>
                <th className='py-3  pr-[100px] font-serif'>AUTHOR</th>
                <th className='py-3  pr-[60px] font-serif'>REQUEST DATE</th>
                <th className='py-3  pl-12 pr-[230px] font-serif'>ACTIONS</th>
              </tr>
            </thead>
            <tbody className='text-black text-base'>
              {requests.map((request, index) => (
                <tr className='border-b-2 border-black'>
                  <td className='py-3 pl-8 font-bold'>{request.bookTitle}</td>
                  <td className='py-3 pl-4 font-medium'>{request.userFullname}</td>
                  <td className='py-3 pl-6 font-medium'>{request.requestDate}</td>
                  <td className='py-2 pl-6 flex flex-row gap-3'>
                    <Link to={"/ReadBook?bookId="+ request.bookId} className=' bg-[#fab914fe] text-white  rounded-md text-sm font-medium p-2 hover:bg-[#dcaa4de7] ml-[80px] '>READ THE BOOK</Link>
                    <button onClick={() => ApproveReq(request.id)} className=' bg-[#19871b] text-white rounded-md text-sm font-medium p-2 hover:bg-[#58bb46d2]'>APPROVE</button>
                    <button onClick={() => RejectReq(request.id)} className='bg-[#d51760fe] text-white rounded-md text-sm font-medium p-2 hover:bg-[#ec5b67d6]'>REJECT</button>
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

export default AubookRequest
