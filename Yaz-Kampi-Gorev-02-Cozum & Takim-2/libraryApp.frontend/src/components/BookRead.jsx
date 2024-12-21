import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useLocation } from "react-router-dom";


const BookReader = () => {
  const [book, setBook] = useState(null);
  const [currentPageNumber, setCurrentPageNumber] = useState(1);
  const navigate = useNavigate();
  const location = useLocation(); //url'deki parametreleri almak için
  const [user, setUser] = useState({});


  const bookId = new URLSearchParams(location.search).get("bookId");


  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      navigate("/login");
    } else {
      setUser(user);
      console.log(user);
    }

    const fetchBookData = async () => {
      try {
        const response = await fetch(
          `http://localhost:5075/api/Kitap/kitapOku?kitapId=${bookId}&isteyenId=${user.id}`
        );

        if (!response.ok) {
          throw new Error("Kitap verisi alınamadı.");
        }

        const data = await response.json();
        setBook(data);
      } catch (error) {
        console.error(error);
      }
    };

    if (bookId) {
      fetchBookData();
    }
  }, [bookId]);


  const handleLogoutClick = () => {
    localStorage.removeItem("userData");
    navigate("/firstPage");
  };


  const handleHomePageClick = () => {
    navigate("/HomePage");
  };


  const handleNextPage = () => {
    if (book && currentPageNumber < book.sayfalar.length) {
      setCurrentPageNumber(currentPageNumber + 1);
    }
  };



  const handlePreviousPage = () => {
    if (currentPageNumber > 1) {
      setCurrentPageNumber(currentPageNumber - 1);
    }
  };

  return (
    <div className="flex flex-col h-screen">

      <nav className="bg-violet-500 text-white p-4 flex justify-between items-center shadow-md">
        <h1 className="text-2xl font-bold">Book Read</h1>
        <div className="flex">
          <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2">Home Page</button>
          <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
        </div>
      </nav>


      <div className="flex flex-col items-center justify-center flex-grow bg-blue-50 p-6">

        <h2 className="font-bold text-xl mb-2">{book?.kitapIsmi}</h2>

        <h1 className="font-bold text-2xl mb-4">Sayfa {currentPageNumber}</h1>


        <div className="p-6 border border-gray-400 rounded bg-white w-full max-w-2xl text-center shadow-lg mb-4">
          <p className="text-lg text-gray-700">
            {book?.sayfalar?.[currentPageNumber - 1]?.icerik}
          </p>
        </div>


        <div className="flex space-x-4 mb-4">
          <button
            onClick={handlePreviousPage}
            disabled={currentPageNumber === 1}
            className="px-4 py-2 bg-violet-500 text-white rounded disabled:opacity-50"
          >
            Önceki
          </button>
          <button
            onClick={handleNextPage}
            disabled={book && currentPageNumber === book.sayfalar.length}
            className="px-4 py-2 bg-violet-500 text-white rounded disabled:opacity-50"
          >
            Sonraki
          </button>
        </div>
      </div>
    </div>
  );
};

export default BookReader;
