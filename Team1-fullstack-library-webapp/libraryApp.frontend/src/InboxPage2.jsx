import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';

const InboxPage2 = () => {

  const [mesajlar2, setmesajlar2] = useState([]);
  const [ShowedTitle, setShowedTitle] = useState("");
  const [ShowedContent, setShowedContent] = useState("");
  const [ShowedSender, setShowedSender] = useState("");
  const [Showedadate, setShowedDate] = useState("");

  const [user, setUser] = useState({});
  const nav = useNavigate();

  useEffect(() => {
    
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/login");
    }
    const user = JSON.parse(data);
    setUser(user);
    console.log(user);


    fetchmessages(user);
  }, []);

  const fetchmessages = async (user) => {
    const yanit = await fetch(`http://localhost:5249/api/Message/getInbox/${user.id}`, {
      method: "GET"

    });

    if (yanit.ok) {
      const mesajlar = await yanit.json();
      setmesajlar2(mesajlar);
      console.log(mesajlar)
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


      <div className='bg-black flex flex-row justify-between'>
        <form className='flex flex-col items-center bg-slate-50 border-2 border-[#f0b954] rounded h-screen space-x-5 ml-3 mt-4 p-10 pl-5'>
          <h2 className='text-xl text-black font-serif font-bold rounded mx-3 p-3'>MESSAGE OPTIONS </h2>
          <div className='flex flex-col items-center justify-center'>
            <Link to="/Messaging" className='bg-[#fcb92afe] hover:bg-[#fec752] text-white font-semibold py-2 px-2 rounded  mt-10'>SEND MESSAGE</Link>
            <div className='bg-[#fcb92afe] text-white font-semibold py-2 px-4 rounded  mt-10'>VIEW INBOX</div>
          </div>
        </form>

        <div className="container p-4 w-1/2">
          <form className="bg-slate-50 border-2 border-[#f0b954] rounded space-x-5 h-screen">
            <label className="flex-auto text-lg font-semibold ml-[115px] ">Select a message</label>
            <ul className="p-4 space-y-2 overflow-y-auto h-screen">
              {mesajlar2.map((mesaj, index) => (
                <li onClick={() => {
                  setShowedTitle(mesaj.title);
                  setShowedContent(mesaj.content);
                  setShowedSender(mesaj.senderName);
                  setShowedDate(mesaj.sendingDate);

                  if (!mesaj.isRead) {
            const updatedMessages = mesajlar2.map((m) => {
                if (m.id === mesaj.id) {
                    return { ...m, isRead: true }; // Okundu olarak güncelle
                }
                return m;
            });

            // Mesajları güncelle
            setMesajlar2(updatedMessages);

            
                }}} className="p-4 rounded shadow">
                  <article className='p-4 flex rounded-md bg-[#fbce8b] hover:bg-[#f0bd60] border-2 border-[#f0b954] justify-between items-center'>
                    <div>
                      <h3 className=" text-[#880906fe] font-semibold text-lg">{mesaj.title}</h3>
                      <h3 className="text-gray-500 font-semibold text-lg">A message from {mesaj.senderName}</h3>
                      <p className="text-black">{mesaj.content.substring(0, 30)}</p>
                    </div>
                  </article>
                </li>
              ))}
            </ul>
          </form>
        </div>
        <div className=' bg-slate-50 border-2 border-[#f0b954] rounded space-x-2 w-full p-4 pb-0 h-screen mt-4 flex flex-col space-y-2'>
          <div className='bg-[#fbce8b] border-2 border-[#f0b954] h-4 rounded flex flex-auto  justify-between ml-[9px] '>
            <h3 className="  text-black font-semibold text-lg ml-2 mt-2">{ShowedTitle}</h3>
            <h3 className="  text-black font-semibold ml-4 mt-2 mr-2">{ShowedSender + "  " + Showedadate}</h3>
          </div>
          <form className='bg-[#f8d49e] border-2 border-[#f0b954] rounded h-5/6 flex flex-auto'>
            <h3 className="  text-black font-semibold text-lg ml-4 mt-2">{ShowedContent}</h3>
          </form>
        </div>
      </div>

    </div>
  )
}

export default InboxPage2