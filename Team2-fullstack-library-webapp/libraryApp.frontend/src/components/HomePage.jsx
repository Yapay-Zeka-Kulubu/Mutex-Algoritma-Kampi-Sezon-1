import React, { useEffect, useState } from 'react';
import { Link, useNavigate, useSearchParams } from 'react-router-dom';
import { toast } from 'react-toastify';

export default function HomePage() {
  const nav = useNavigate();
  const [user, setUser] = useState({});

  const handleLogoutClick = () => {
    localStorage.removeItem("userData");
    nav("/");
  };

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    } else {
      setUser(user);
    }


  }, []);

  return (
    <div className="h-screen flex flex-col items-center justify-start bg-white"> {/* Arka plan beyaz yapıldı */}
      <div className=''>
        {/* Ana içerik */}
        <div className="text-center mt-20"> {/* Yukarıda ortalandı */}
          <h1 className="text-5xl font-bold mb-4 text-violet-700" style={{ fontFamily: "cursive" }}>
            Welcome to Your Library!
          </h1>
        </div>

        {/* Üst menü */}
        <div className="flex flex-col items-center  mt-10">
          <h2 className="text-violet-700 text-xl mb-4">Select an Option:</h2>


          {(user.rolIsmi === "yazar") && (<Link className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center" to="/MyBooks">
            My Books
          </Link>)}


          <Link to="/BookList" className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center">
            Book List
          </Link>


          {(user.rolIsmi === "yonetici" || user.rolIsmi === "gorevli") &&
            (
              <>
                <Link to="/BorrowRequests" className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center">
                  Borrow Requests
                </Link>
                <Link to="/Punishment" className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center">
                  Punishment
                </Link>
                <Link to="/RegisterRequests" className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center">
                  Register requests
                </Link>
              </>
            )}



          <Link to="/BorrowedBooksList" className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center">
            My borrowed Books
          </Link>


          <Link to="/MessagePage" className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center">
            Send Message
          </Link>


          <Link to="/MessageBox" className="bg-violet-700 text-white py-2 px-4 rounded-lg mb-2 mt-2 hover:bg-violet-600 transition-all w-64 text-center">
            Message Inbox
          </Link>


          {(user.rolIsmi === "yonetici") && (
            <>
              <Link to="/ChangeRole" className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center">
                Change Role
              </Link>
              <Link to="/BookCreation" className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64 text-center">
                Book Publish requests
              </Link>
            </>
          )}

          <button onClick={handleLogoutClick} className="bg-violet-700 text-white py-2 px-4 mb-2 mt-2 rounded-lg hover:bg-violet-600 transition-all w-64">
            Logout
          </button>

        </div>
      </div>
    </div>
  );
}
