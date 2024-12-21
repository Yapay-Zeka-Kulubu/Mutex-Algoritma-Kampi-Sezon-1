import React, { useEffect, useState } from 'react'
import { Link, Navigate, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
//bu sayfanın logout ve name kısmı doğru
const Changerole = () => {
  const [users, setusers] = useState([]); //userdan ne dönüyor dizi mi
  const [selectedRoleId, setSelectedRoleId] = useState(0);
  const [selectedUserId, setSelectedUserId] = useState(0);
 //nav için
  const nav = useNavigate();
  //logout için
  const [user, setuser] = useState({});


  const checkUser = () => {
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/Login");
      return;
    }

    const user = JSON.parse(data);
    setuser(user);

    if (user.roleName !== "manager") {
      nav("/");
      return;
    }

    fetchUsers(user);
  }

  const fetchUsers = async (user) => {
    const yanit = await fetch(`http://localhost:5249/api/User/getusersforrolechanging/${user.roleId}`, {
      method: "GET"
    });
    if (yanit.ok) {
      const users = await yanit.json();
      setusers(users);
    }
  };

  useEffect(
    () => {
      checkUser();
    },
    []);

  //userId ve newRoleId kısmına ne vereceğiz + fonkksiyonum neden tanımlanmıyor
  const updateRole = async (e) => {
    e.preventDefault();

    const role = {
      userId: selectedUserId,
      newRoleId: selectedRoleId
    }

    //path içine book id vermemiz gerekiyor mu
    const yanit = await fetch(`http://localhost:5249/api/User/ChangeRole`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(role),
    });

    if (yanit.ok) {
      const data= await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }
    else {
      const data =await yanit.json();
      toast.error(data.message);
    }

  };



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
          <h1 className='text-xl font-serif mt-[60px] hover:border-b-2'>GENERAL OPERATIONS</h1>
          <Link to="/Punishing" className=' bg-[#fab914fe] py-3 px-7 text-lg font-semibold rounded-sm mt-[30px] hover:bg-[#fec752] '>PUNISH A USER</Link>

        </div>
        {/* form */}
        <form className='text-black text-lg  bg-[#f9dc7654]  border-2 border-black h-[600px] w-[1000px] flex flex-col py-7 px-7 gap-6 ml-[120px] mt-[40px]'>
          <div className='flex flex-col'>
            <label >SELECT USER</label>
            <select onChange={e => setSelectedUserId(e.target.value)} className=' bg-[#f9dd76ae] w-[800px] hover:bg-[#ecd16fef]'>
              <option value="" >Select an option</option>
              {users.map((user, index) => (
                <option value={user.userId} >{user.fullname + " - " + user.roleName}</option>
              ))}
            </select>
          </div>

          <div className='flex flex-col py-3'>
            <label>ROLES</label>
            <select onChange={e => setSelectedRoleId(e.target.value)} className=' bg-[#f9dd76b8] w-[800px] hover:bg-[#ecd16fef] '>
              <option value="" >Select an option</option>
              <option value="1" >MEMBER</option>
              <option value="2" >MANAGER</option>
              <option value="3" >STAFF</option>
              <option value="4" >AUTHOR</option>
            </select>
          </div>

          <button onClick={updateRole} className='bg-[#faa914fe] text-white rounded-md text-md font-semibold py-2 hover:bg-[#dcaa4de7] ml-[670px] mt-[50px]'>UPDATE</button>

        </form>

      </div>
    </div>
  )
}

export default Changerole
