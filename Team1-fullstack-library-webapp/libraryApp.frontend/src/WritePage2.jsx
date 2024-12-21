import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';
//Zeh
const WritePage2 = () => {
  const [book,setBook] = useState({});
  const [kitapAdi, setKitapAdi] = useState("");
  const [type, setType] = useState("");
  const [numOfPages, setNumOfPages] = useState([]);
  const [content, setContent] = useState("");
  const [pageNum, setPageNum] = useState(0);
  const [Page, setPage] = useState([]);

  const bookId = new URLSearchParams(location.search).get("bookId");
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
    kitabiAl(user);

  }

  const kitabiAl = async (user) => {
    console.log(bookId)
    const yanit = await fetch(`http://localhost:5249/api/Book/GetBookById?bookId=${bookId}&requestorId=${user.id}`, {
      method: "GET",
    });

    if (yanit.ok) {
      const kitap = await yanit.json();
      console.log(kitap);
      setBook(kitap);
      setKitapAdi(kitap.title);
      setType(kitap.type);
      setPageNum(kitap.number_of_pages + 1);
    }
  }

  const handleInputChange = (e) => {
    setPage(e.target.value);
  };


  useEffect(() => {
    checkUser();
  }, []);

  const sayfaEkle = async (e) => {
    e.preventDefault();
    const page = {
      bookId: bookId,
      content: content,
    }

    const yanit = await fetch(`http://localhost:5249/api/Book/${bookId}/addpage`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(page),
    });

    if (yanit.ok) {
     const data = await yanit.json();
     toast.success(data.message, {onClose:() => nav(0)});
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
      <div className='bg-[#fdf2d8fe] h-screen flex flex-col gap-3 items-center '>
        {/* <h2 className='text-l font-semibold text-slate-50 mt-5'>{kitapAdi}</h2> */}
        <form className='bg-[#fde5b1fe] border-2 border-[#f9ca67fe] h-4/5 w-4/5 rounded mt-5'>
          <div className='flex justify-between gap-2 mt-2 ml-2 mr-2'>
            <form className='bg-[#f9ca67fe] h-16 w-4/5 rounded flex flex-row justify-center gap-2'>
            <h2 className='text-xl font-bold text-white mt-5'>{kitapAdi}</h2>
            </form>
            <form className='bg-slate-50 border-2 border-[#f9ca67fe] h-16 w-1/5 rounded flex justify-center'>
              <h2 className='mt-4 text-lg text-black'>Pages</h2>
            </form>
          </div>
          <div className='flex justify-between h-3/5 gap-2 mt-2 ml-2 mr-2'>
            <textarea onChange={e => setContent(e.target.value)} className='bg-slate-50 border-2 border-[#f9ca67fe] h-6/7 w-4/5 py-1 px-2' />
            <form className='bg-slate-50 border-2 border-[#f9ca67fe] rounded flex flex-row w-1/5 flex-wrap'>
            {book?.pages?.map((page, index) => (
                <div key={index} className='bg-[#f9ca67fe] rounded-full flex justify-center h-6 w-6 m-1'>
                  <p className='ml-1 font-bold '>{index + 1}</p>
                </div>
              ))}
            </form>
          </div>
          <form className='bg-[#fde5b1fe]  h-7 w w-3/4 ml-12'></form>
          <div className='bg-[#fde5b1fe] h-20 w-3/4 ml-12 flex flex-row justify-end gap-3 '>
            <button onClick={e => sayfaEkle(e)} className='bg-green-600 hover:bg-green-700 h-10 w-auto py-1 px-8 text-slate-50 text-xl font-semibold rounded'> Save </button>
          </div>
        </form>

      </div>


    </div>

  )
}

export default WritePage2