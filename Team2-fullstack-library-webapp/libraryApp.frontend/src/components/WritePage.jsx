import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from 'react-toastify';


const WritePage = () => {

  const [user, setUser] = useState({});
  const bookId = new URLSearchParams(location.search).get("bookId");
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
    else if (user.rolIsmi !== "yazar") {
      nav("/HomePage");
    }
    else {
      setUser(user);
    }
  }, []);

  const nav = useNavigate();
  const [pageContent, setPageContent] = useState("");

  const handleContentChange = (e) => {
    setPageContent(e.target.value);
  };

  const handleSave = async () => {
    try {
      const yanit = await fetch('http://localhost:5075/api/Kitap/sayfaEkle', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          kitapId: bookId,
          icerik: pageContent,  //sayfa içeriği
        }),
      });


      if (!yanit.ok) {
        toast.error("Unsuccessful");
      }
      else {
        toast.success("Page saved successfully.", {
          onClose: () => nav(0)
        });
      }
    }
    catch (error) {
      toast.success("An error occurred while saving the page.", error);

    }
  };

  return (
    <div className="min-h-screen bg-White textblack-">
      <header className="flex items-center justify-between p-4 bg-indigo-200 text-white shadow-lg">
        <h1 className="text-3xl font-bold">Book Editor</h1>
        <div className="flex">
          <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>
          <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
        </div>
      </header>

      <div className="flex flex-col items-center justify-center mt-10 w-full">
        <textarea
          onChange={handleContentChange}
          placeholder="Type the content of the page here..."
          className="w-full max-w-5xl h-64 p-4 bg-white text-black rounded-lg shadow-md focus:outline-none focus:ring-2 focus:ring-violet-700"
        ></textarea>

        <div className="w-full max-w-5xl flex justify-between items-center mt-4">
          <button
            onClick={handleSave}
            className="ml-auto px-4 py-2 bg-violet-600 text-white rounded-lg shadow hover:bg-violet-700"
          >
            Save
          </button>
        </div>

      </div>
    </div>

  );
}

export default WritePage;
