import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { toast } from 'react-toastify';

const MessagePage = () => {
  const [user, setUser] = useState({});
  const [users, setUsers] = useState([]);
  const [title, setTitle] = useState("");
  const [message, setMessage] = useState("");
  const [aliciId, setAliciId] = useState("");
  const nav =useNavigate();

  const handleLogoutClick = () => {
    localStorage.removeItem("userData");
    nav("/");
  };
  const handleHomePageClick = () => {
    nav("/HomePage");
  };
  // Sayfa yüklendiğinde localStorage'dan mesajları çek
  useEffect(() => {
    const user = JSON.parse(localStorage.getItem("userData"));
    if (user === null) {
      nav("/login");
    }
    else {
      setUser(user);
      fetchusers(user);
    }
  }, []);

  const handleAliciId = (e) => {
    setAliciId(e.target.value);
  };

  const handleTitleChange = (e) => {
    setTitle(e.target.value);
  };

  const handleMessageChange = (e) => {
    setMessage(e.target.value);
  };

  const fetchusers = async (user) => {
    const yanit = await fetch("http://localhost:5075/api/User/mesajGonderilebilecekUserlarGetir/" + user.rolId);
    if (yanit.ok) {
      const data = await yanit.json();
      setUsers(data);
    }
  }

  const sendMessage = async () => {
    try {
      const yanit2 = await fetch("http://localhost:5075/api/Mesaj/mesajOlustur", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          baslik: title,
          detaylar: message,
          gonderenId: user.id,
          alanId: aliciId,
        }),
      });

      if (!yanit2.ok)  {
          toast.error("Mesaj gönderilemedi", {
            onClose: () => nav(0)
          });
        }
      else {
        toast.success("Mesaj başarıyla gönderildi", {
          onClose: () => nav(0)
        });
      }
    }

    catch (error) {
      toast.error("Mesaj gönderilemedi",error);
    }
  }

  return (
    <div className="min-h-screen bg-White text-black">
      <header className="flex items-center justify-between p-4 bg-violet-500 text-white shadow-lg">
        <h1 className="text-3xl font-bold">Message Operations</h1>
        <div className="flex">
            <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>
            <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
        </div>
      </header>

      <div className="flex flex-col items-center justify-center mt-10 w-full">
        <select onChange={handleAliciId} className="w-full max-w-5xl p-4 bg-white text-black rounded-lg shadow-md">
          <option>
            SELECT
          </option>
          {users.map((user, index) => (
            <option value={user.userId}>
              {user.isım + " " + user.soyisim + " - " + user.rolIsmi}
            </option>
          ))}
        </select>
      </div>

      <div className="flex flex-col items-center justify-center mt-10 w-full">
        <input
          placeholder="Enter message title..."
          onChange={handleTitleChange}
          className="w-full max-w-5xl p-4 bg-white text-black rounded-lg shadow-md focus:outline-none focus:ring-2 focus:ring-violet-700"
        />
      </div>


      <div className="flex flex-col items-center justify-center mt-10 w-full">
        <textarea
          placeholder="Write your message..."
          onChange={handleMessageChange}
          className="w-full max-w-5xl h-64 p-4 bg-white text-black rounded-lg shadow-md focus:outline-none focus:ring-2 focus:ring-violet-700"
        ></textarea>

        <div className="w-full max-w-5xl flex justify-between items-center mt-4">
          <button onClick={sendMessage} className="ml-auto px-4 py-2 bg-violet-600 text-white rounded-lg shadow hover:bg-violet-700">
            Send
          </button>
        </div>
      </div>
    </div>
  );
};

export default MessagePage;
