import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';


const bookCreation = () => {
  const [requests, setRequests] = useState([]);
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
    if (user === null) {//kullanıcı giriş yapmamışsa login sayfası
      nav("/login");
    }
    else if (user.rolIsmi !== "yonetici") {//giriş yapan yazar değilse homepage e at
      nav("/HomePage");
    }
    else {
      setUser(user);
    }
  }, []);

  useEffect(() => {
    const fetchBooks = async () => {
      const yanit = await fetch("http://localhost:5075/api/Kitap/kitapYayinlamaİstekleri", {
        method: "GET",
      });
      if (yanit.ok) {

        const data = await yanit.json();
        setRequests(data);
        console.log(data);
      } else {
      }
    };

    fetchBooks();
  }, []);

  const handlePendingBookClick = () => {
    alert('This will show pending book creation requests');
  };


  const handleApproveReject = async (isApproved, requestId) => {
    const req = {
      "yayinIstekId": requestId,
      "onaylandiMi": isApproved
    };
    const yanit = await fetch("http://localhost:5075/api/Kitap/yayinlamaIstegineCevapVer", {
      method:"PUT",
      headers: {"Content-Type":"Application/json"},
      body: JSON.stringify(req)
    });

    if(yanit.ok)
    {
      toast.success("Succesfull", {
        onClose: () => nav(0)
      });
    }
    else{
      toast.error("Failed");
    }
  };

  
  return (
    <div className="flex flex-col h-screen w-full">
      {/* Sağ İçerik */}
      <div className="flex-grow bg-white text-white flex flex-col">
        {/* Üst Menü */}
        <header className="flex justify-between items-center p-4 bg-violet-500">
            <h1 className='text-2xl font-bold'>Book Create</h1>
            <div className="flex">
            <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
            <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>

        </div>
        </header>
        {/* İçerik Tablosu */}
        <div className="p-5 flex-grow overflow-auto">
          <table className="w-full text-left">
            <thead>
              <tr className="bg-violet-200 text-black">
                <th className="p-3">BOOK NAME</th>
                <th className="p-3">AUTHOR</th>
                <th className="p-3">REQUEST DATE</th>
                <th className="p-3">ACTIONS</th>
              </tr>
            </thead>
            <tbody>
              {requests.map((request, index) => (
                <tr key={index} className="bg-blue-50 text-black">
                  <td className="p-3">{request.kitapIsmi}</td> 
                  <td className="p-3">{request.kitapYazarlari.join(" , ")}</td>
                  <td className="p-3">{request.talepTarihi}</td>
                  <td className="p-3 flex space-x-2">
                    <Link to={`/ReadBook?bookId=` + request.kitapId} className="bg-green-500 hover:bg-green-600 text-black px-3 py-1 rounded">Read the book</Link>
                    <button onClick={() => {handleApproveReject(true,request.id)}} className="bg-blue-500 hover:bg-blue-600 text-black px-3 py-1 rounded">Approve</button>
                    <button onClick={() => {handleApproveReject(false,request.id)}} className="bg-red-500 hover:bg-red-600 text-black px-3 py-1 rounded">Reject</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default bookCreation;
