import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

export default function RegisterRequests() {

  const [user, setUser] = useState({});
  const nav = useNavigate();
  const [requests, setRequests] = useState([]);

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
    else if (user.rolIsmi !== "gorevli" && user.rolIsmi !== "yonetici") {
      nav("/HomePage");
    }
    else {
      setUser(user);
      fetchRequest();
    }
  }, []);

  const fetchRequest = async () => {
    try {
      const yanit = await fetch("http://localhost:5075/api/Account/HesapAcmaTalepleriniGotruntule");
      if (yanit.ok) {
        const data = await yanit.json();
        console.log(data);
        setRequests(data);
      }
    }
    catch (error) {
      toast.error("talepler çağırılırken hata oluştu.",error);

    }
  }

  const handleApproveClick = async (id) => {
    try {
      const yanit = await fetch("http://localhost:5075/api/Account/HesapAcmaTaleplerineYanıtVer",
        {
          method: "PUT",
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            id: id,
            onaylandiMi: true,
          }),
        });

      if (yanit.ok) {
        toast.success("Approved", {
          onClose: () => nav(0)
        });
      }
    }
    catch {
      toast.error("Hata oluştu",);
    }
  }


  const handleRejectClick = async (id) => {
    try {
      const yanit = await fetch("http://localhost:5075/api/Account/HesapAcmaTaleplerineYanıtVer",
        {
          method: "PUT",
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            id: id,
            onaylandiMi: false,
          }),
        });

      if (yanit.ok) {
        toast.success("Rejected", {
          onClose: () => nav(0)
        });
      }
    }
    catch {
      toast.error("Error occurred.",);
    }
  }


  return (
    <div className="bg-white min-h-screen">

      <div className="flex justify-between items-center bg-violet-500 text-white p-4 shadow-lg">
        <h1 className="text-3xl font-bold">Borrow Request</h1>
        <div className="flex">
          <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>
          <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
        </div>
      </div>

      <div className='pl-6 pr-6'>
        <div className="bg-white shadow-lg rounded-lg p-6">
          <table className="min-w-full">
            <thead>
              <tr className="bg-violet-600 text-white">
                <th className="p-6 text-left">Name</th>
                <th className="p-6 text-left">Surname</th>
                <th className="p-6 text-left">Email</th>
                <th className="p-6 text-left">Request Date</th>
                <th className="p-6 text-left">Actions</th>
              </tr>
            </thead>
            <tbody>
              {requests.map((request, index) => (

                <tr className="border-b">
                  <td className="p-6">{request.isim}</td>
                  <td className="p-6">{request.soyIsim} </td>
                  <td className="p-6">{request.email}</td>
                  <td className="p-6">{request.talepTarihi}</td>
                  <td className="p-6 flex space-x-2">
                    <button
                      onClick={() => handleApproveClick(request.id)
                      }
                      className="bg-green-500 text-white py-2 px-4 rounded-lg">
                      Approve
                    </button>
                    <button
                      onClick={() => handleRejectClick(request.id)}
                      className="bg-red-500 text-white py-2 px-4 rounded-lg">
                      Reject
                    </button>
                  </td>
                </tr>))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}
