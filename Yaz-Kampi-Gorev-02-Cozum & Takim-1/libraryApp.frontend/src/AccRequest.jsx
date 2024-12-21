import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

const AccRequest = () => {
  const [users, setusers] = useState([]);

  const [user, setUser] = useState({});//kullanıcı bilgileri için
  const nav = useNavigate();

  const fetchAccRequest = async () => {
    const yanit = await fetch(`http://localhost:5249/api/Account/getaccountcreationrequests`, {
      method: "GET"
    });

    if (yanit.ok) {
      const users = await yanit.json();
      setusers(users);

    }
  };
  useEffect(
    () => {
      fetchAccRequest();
      checkUser();
    }, [])

  //
  const ApproveReq = async (id) => {
    const request = {
      requestId: id,
      isApproved: true,
    }

    const yanit = await fetch(`http://localhost:5249/api/Account/setaccountcreationrequest`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(request),
    });
    if (yanit.ok) {
      const data = await yanit.json();
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
      isApproved: false,
    }

    const yanit = await fetch(`http://localhost:5249/api/Account/setaccountcreationrequest`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(request),
    });
    if (yanit.ok) {
      const data = await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }
    else {
      const data = await yanit.json();
      toast.error(data.message);
    }
  }

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

      {/* underside*/}
      <div className='flex flex-row'>
        {/* sidebar */}
        <div className='text-white bg-black  flex flex-col gap-8 items-center w-[300px] min-h-screen'>
          <h1 className='text-xl font-serif mt-[60px] hover:border-b-2'>MEMBER OPERATIONS</h1>
          <Link to="/BorrowRequest" className=' bg-[#ffb71cfe] text-lg font-semibold py-2 px-3 rounded-sm hover:bg-[#fec752] mt-[30px] w-[200px]'>BORROW REQUESTS</Link>
        </div>
        {/* table */}
        <div className=' bg-white w-[1220px] h-[780px] overflow-y-auto max-h-[780px]'>

          <table className=' bg-white text-black w-[1220px] '>
            <thead className='bg-[#f9dc7654]  text-sm'>
              <tr className='border-b-2 border-black'>
                <th className='py-3 pl-4 pr-[200px] font-serif'>FULL NAME</th>
                <th className='py-3  pr-[100px] font-serif'>USERNAME</th>
                <th className='py-3  pr-[100px] font-serif'>REQUEST DATE</th>
                <th className='py-3  pr-[270px] font-serif'>ACTIONS</th>
              </tr>
            </thead>
            <tbody className='text-black text-base'>
              {users.map((user, index) => (
                <tr className='border-b-2 border-black'>
                  <td className='py-3 pl-10 font-bold'>{user.fullName}</td>
                  <td className='py-3 pl-5 font-medium'>{user.username}</td>
                  <td className='py-3 pl-6 font-medium'>{user.requestDate}</td>
                  <td className='py-2 pl-4 flex flex-row gap-3'>
                    <button onClick={() => ApproveReq(user.id)} className=' bg-[#19871b] text-white rounded-md text-sm font-medium p-2 hover:bg-[#58bb46d2] ml-3 '>APPROVE</button>
                    <button onClick={() => RejectReq(user.id)} className='bg-[#d51760fe] text-white rounded-md text-sm font-medium p-2 hover:bg-[#ec5b67d6]'>REJECT</button>
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

export default AccRequest
