import React, { useEffect, useState } from 'react'
import { TbBrandD3 } from 'react-icons/tb'
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
//özge
//EN BAŞTA TÜM KİTAPLARIN GELMESİNİ YAPAMADIM
const Booksearch = () => {

  const [kitapIsmi, setKitapIsmi] = useState("");
  const [kitaplar, setKitaplar] = useState([]);
  const [user, setUser] = useState({});
  const nav = useNavigate();

  const checkUser = () => {
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/Login");
      return;
    }

    const user = JSON.parse(data);
    setUser(user);

  }

  useEffect(() => {
    handleSearchClick();
    checkUser();
  }, [])


  const handleSearchClick = async () => {
    const yanit = await fetch(`http://localhost:5249/api/Book/bytitle?title=${kitapIsmi}`, {
      method: "GET",
    });

    if (yanit.ok) {
      const kitaplar = await yanit.json();
      setKitaplar(kitaplar);
      console.log(kitaplar);
    }

  };

  const borrowRequest = async (bookId) => {

    const request = {
      userId: user.id,
      bookId: bookId,
    }

    const yanit = await fetch(`http://localhost:5249/api/Book/requestBook`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(request),
    });

    if (yanit.ok) {
      toast.success("Successful");
    } else {
      const data = await yanit.json();
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
      <div className='flex flex-row'>
        {/* sidebar */}
        <div className=' bg-black  flex flex-col gap-8 items-center w-[300px] min-h-screen'>
          <h2 className='text-white text-2xl font-serif mt-[60px] hover:border-b-2'>BOOK OPERATIONS</h2>

          {/* search bar */}
          <div className=' flex item-center'>
            <input onChange={e => setKitapIsmi(e.target.value)} type='text' className='border-2  w-50 h-9 bg-gray-300 p-2 rounded-l-full focus:border-[#ffc13bf4]' placeholder='  search book...' />
            <button onClick={handleSearchClick} className='bg-pink-700 w-20 h-9 text-white font-bold text-sm hover:bg-pink-900 rounded-r-full'>SEARCH</button>
          </div>
          <Link className='bg-[#fab914fe] py-3 px-7 text-white text-lg font-semibold rounded-sm mt-[30px] hover:bg-[#fec752]' to="/BorrowedBooks">BORROWED BOOKS</Link>
        </div>
        {/* table */}
        <div className='bg-white w-[1220px] h-[780px] overflow-y-auto max-h-[780px]'>
          <table className='border-2 border-black bg-white text-black w-[1220px]'>
            <thead className='bg-[#f9dc7654] text-sm'>
              <tr className='border-b-2 border-black'>
                <th className='py-3 pl-4 pr-[250px] font-serif'>TITLE</th>
                <th className='py-3  pr-[160px] font-serif'>TYPE</th>
                <th className='py-3  pr-[150px] font-serif'>AUTHORS</th>
                <th className='py-3  pr-[150px] font-serif'>IS BORROWED</th>
                <th className='py-3  pr-[270px] font-serif '>ACTIONS</th>
              </tr>
            </thead>
            <tbody className='text-black text-base'>
              {
                kitaplar.map((kitap, index) => (
                  <tr className='border-b-2 border-black'>
                    <td className='py-3 pl-4 font-bold'>{kitap.title}</td>
                    <td className='py-3 font-medium'>{kitap.type}</td>
                    <td className='py-3 font-medium'>{kitap.bookAuthors.join(", ")}</td>
                    <td className='py-3 pl-9 font-medium'>{kitap.isBorrowed ? "Yes" : "No"}</td>
                    <td className='py-2'>
                    <Link className='bg-[#fab914fe] text-white  rounded-md text-sm font-medium p-2 hover:bg-[#dcaa4de7] mr-3 ' to={"/ReadBook?bookId=" + kitap.id}>READ THE BOOK</Link>
                      <button disabled={kitap.isBorrowed} onClick={() => borrowRequest(kitap.id)} className='bg-[#d51760fe] text-white rounded-md text-sm font-medium p-2 hover:bg-[#ec5b67d6] disabled:bg-[#d51760fe]/30'>BORROW</button>
                      {/* post borrow request */}
                    </td>
                      
                  </tr>
                ))
              }
            </tbody>

          </table>
        </div>
      </div>
    </div>
  )
}

export default Booksearch
