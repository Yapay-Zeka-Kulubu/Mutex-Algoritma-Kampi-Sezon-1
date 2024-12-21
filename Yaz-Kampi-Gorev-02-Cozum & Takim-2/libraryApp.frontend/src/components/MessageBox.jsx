import React, { useEffect, useState } from 'react';
import { useNavigate , Link} from 'react-router-dom';
import { toast } from 'react-toastify';

const MessageBox = () => {
  const [user, setUser] = useState({});
  const [messages, setMessages] = useState([]);
  const [selectedMessage, setSelectedMessage] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const nav = useNavigate();

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
    else {
      setUser(user);
      fetchMessages(user);
    }
  }, []);

  const openModal = (message) => {
    setSelectedMessage(message);
    setShowModal(true);         
  };

  const closeModal = () => {
    setShowModal(false); 
  }; 
  
  const fetchMessages = async (user) => {
    try {
      const yanit = await fetch(`http://localhost:5075/api/Mesaj/mesajAlmakutusu/${user.id}`);
      if (yanit.ok) {
        const data = await yanit.json();
        setMessages(data);
      }
    }
    catch (error) {
      console.log("Mesajlar çağırılırken hata oluştu.");
    }
  }

  return (
    <div>
      <header className="flex items-center justify-between p-4 bg-violet-500 text-white shadow-lg">
        <h1 className="text-3xl font-bold">Message Box</h1>
        <div className="flex">
            <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>
            <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
        </div>
      </header>

      {messages.map((message, index) => (
        <div className="bg-white shadow-md rounded-lg p-4 mt-4 ml-4 mr-4 border-l-4 border-violet-200">
          <div className="flex justify-between items-center">
            <h3 className="text-lg font-medium">{message.baslik}</h3>
          </div>
          <p className="text-sm text-gray-600">Gönderen: {message.gonderenIsmi}</p>
          <button onClick={() => openModal(message)} className="mt-2 text-blue-500 hover:underline">Görüntüle</button>
        </div>
      ))}

     {showModal && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
          <div className="bg-white p-6 rounded-lg shadow-lg w-3/4 md:w-1/2 lg:w-1/3">
            <button onClick={closeModal} className="text-gray-500 float-right">X</button>
            <h3 className="text-xl font-semibold">{selectedMessage.baslik}</h3>
            <p className="mt-2">{selectedMessage.detaylar}</p>
          </div>
        </div>
      )}
    </div>
  );
}

export default MessageBox;
