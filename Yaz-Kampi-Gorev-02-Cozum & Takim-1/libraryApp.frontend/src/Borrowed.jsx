import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
//özge
const Borrowed = () => {
  const [kitaplar2, setKitaplar2] = useState([]);
  const [user, setUser] = useState({});
  const nav= useNavigate();

  const checkUser = () => {
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/Login");
      return;
    }
    
    const user = JSON.parse(data);
    setUser(user);

    fetchBorrowedBooks(user);
  }


  const fetchBorrowedBooks = async (user) => {
    const yanit = await fetch(`http://localhost:5249/api/Book/borrowed/${user.id}`, {
      method: "GET"

    });

    if (yanit.ok) {
      const kitaplar = await yanit.json();
      setKitaplar2(kitaplar);
      console.log(kitaplar);
    }
  };

  useEffect(() => {
    checkUser();
  },[])
  
  const returnBook = async (id) => {

    const yanit = await fetch(`http://localhost:5249/api/Book/returnBook`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(id),
    });

    console.log(id);

    if(yanit.ok)
    {
      const data=await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }else{
      const data=await yanit.json();
      toast.error(data.message);
    }
  }


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

      {/*  underside */}
      <div className='flex flex-row bg-[#f9dc7654]'>
        {/* sidebar */}
        <div className=' bg-black  flex flex-col gap-8 items-center w-[320px] min-h-screen'>
          <h2 className='text-white text-2xl font-serif mt-[60px] hover:border-b-2'>BOOK OPERATIONS</h2>
          <Link to={"/BookSearch"} className='bg-[#fab914fe] py-3 px-7 text-white text-lg font-semibold rounded-sm mt-[30px] hover:bg-[#fec752]'>BOOK SEARCH</Link>
        </div>
        {/* table */}
        <div className='mt-[70px] ml-[55px] overflow-y-auto max-h-[550px] '>
          <table className='border-2 border-black bg-white text-black'>
            <thead className='bg-[#f9dd769e]  text-sm'>
              <tr className='border-b-2 border-black'>
                <th className='py-3 pl-4 pr-[150px] font-serif'>TITLE</th>
                <th className='py-3  pr-[100px] font-serif'>AUTHOR</th>
                <th className='py-3  pr-[100px] font-serif'>BORROWED DATE</th>
                <th className='py-3  pr-[100px] font-serif'>RETURN DATE</th>
                <th className='py-3  pr-[200px] font-serif'>ACTIONS</th>
              </tr>
            </thead>
            <tbody className='text-black text-base'>
              {kitaplar2.map((kitap, index) => (
                <tr className='border-b-2 border-black'>
                  <td className='py-3 pl-4 font-bold'>{kitap.title}</td>
                  <td className='py-3 font-medium'>{kitap.bookAuthors.join(",")}</td>
                  <td className='py-3 font-medium'>{kitap.requestDate}</td>
                  <td className='py-3 font-medium'>{kitap.returnDate}</td>
                  <td className='py-2'>
                    <Link to={"/ReadBook?bookId="+kitap.bookId} className='bg-[#fab914fe] text-white  rounded-md text-sm font-medium p-2 hover:bg-[#dcaa4de7] mr-3 '>READ</Link>
                    <button onClick={() => {returnBook(kitap.bookId)}} className='bg-[#d51760fe] text-white rounded-md text-sm font-medium p-2 hover:bg-[#ec5b67d6]'>RETURN</button>
                  </td>
                </tr>
              ))}
            {/* return hatalı */}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  )
}

export default Borrowed
