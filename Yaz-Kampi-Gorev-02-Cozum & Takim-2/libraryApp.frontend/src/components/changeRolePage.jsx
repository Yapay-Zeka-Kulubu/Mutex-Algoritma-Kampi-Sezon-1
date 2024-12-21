import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

const ChangeRole = () => {
  const [users, setUsers] = useState([]);
  const [roles, setRoles] = useState([]);
  const [selectedUserId, setSelectedUserId] = useState('');
  const [selectedRole, setSelectedRole] = useState('');
  const nav = useNavigate();
  const [user, setUser] = useState({});

  
  const handleLogoutClick = () => {
    localStorage.removeItem("userData");
    nav("/");
  };
  const handleHomePageClick = () => {
    nav("/HomePage");
  };

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    }
    else if ( user.rolIsmi !== "yonetici") {
      nav("/HomePage");
    }
    else {
      setUser(user);
    }
   

    const fetchUsers = async () => {
      const response = await fetch("http://localhost:5075/api/User/rolDegistirilecekUserlariGetir/" + user.rolId, {
        method: "GET",
      });
      if (response.ok) {
        const dummyUsers = await response.json();
        setUsers(dummyUsers);
      }
    };

    const fetchRoles = async () => {
      const response = await fetch("http://localhost:5075/api/User/rolleriGetir", {
        method: "GET",
      });
      if (response.ok) {
        const dummyRoles = await response.json();
        setRoles(dummyRoles);
      }
    };

    fetchRoles();
    fetchUsers();
  }, []);

  const handleUpdateClick = async () => {
    const yanit= await fetch("http://localhost:5075/api/User/roluGuncelle" ,{
      method:"PUT",
      headers:{
        "Content-Type" : "application/json" 
      },
      body:JSON.stringify(
        {
          
              "userId": selectedUserId,
              "yeniRolId": selectedRole,
        }
      ),

    });

    if(yanit.ok)
      {
        toast.success("Güncellendi", {
          onClose: () => nav(0)
        });
      }
      else{
        toast.error("Güncelleme olmadı");
      }
  }

  useEffect(() => {
    console.log(selectedUserId);

  }, [selectedUserId]);
  //selecteduserıd değişince bu useeffect içibndeki fonksiyon calışır 

  return (
    <div className=" flex flex-col h-screen bg-white">
      <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6 ">
        <h1 className="text-3xl font-bold">Punishment Page</h1>
        <div className="flex">
            <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
            <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>

        </div>
      </div>
      {/* Main Content */}
      <main className="flex flex-col justify-center items-center p-8 text-black">
        <div className=' flex flex-col w-3/5 '>
          <h1 className="text-2xl mb-10 mt-10">Change Role</h1>
          <div>
            <label className="block mb-2">Select user</label>
            <select
              value={selectedUserId}
              onChange={(e) => {
                setSelectedUserId(e.target.value);
              }}
              className="w-full p-2 bg-blue-50 border rounded"
            >
              <option value="">Select someone</option>
              {users.map(user => (
                <option key={user.userId} value={user.userId}>{user.isım + " " + user.soyisim + " - " + user.rolIsmi}</option>
              ))}
            </select>
          </div>

          <div>
            <label className="block mb-2">Select role</label>
            <select
              value={selectedRole}
              onChange={(e) => setSelectedRole(e.target.value)}
              className="w-full p-2 bg-blue-50 border rounded"
            >
              <option value="">Select role</option>
              {roles.map(role => (
                <option key={role.id} value={role.id}>{role.rolIsmi}</option>
              ))}
            </select>
          </div>

          <div className='self-end'>
            <button
              className="bg-green-600 mt-5 hover:bg-green-700 text-white py-2 px-4 rounded"
              onClick={handleUpdateClick}
            >
              Update
            </button>
          </div>
        </div>
      </main >
    </div >
  );
};

export default ChangeRole;
