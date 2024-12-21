import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { GrCaretNext } from "react-icons/gr";
import { GrCaretPrevious } from "react-icons/gr";
import { FaSearch } from "react-icons/fa";

//seçili kitap okunacak mı
const ReadPage = () => {

  const [book, setBook] = useState([]);
  const [kitapAdi, setKitapAdi] = useState("");
  const [sayfalar, setSayfalar] = useState(["", ""]);
  const [user, setUser] = useState({});
  const nav = useNavigate();
  const [currentpage, setcurrentpage] = useState(1);

  const bookId = new URLSearchParams(location.search).get("bookId");

  const kitabiAl = async (user) => {
    const yanit = await fetch(`http://localhost:5249/api/Book/GetBookById?bookId=${bookId}&requestorId=${user.id}`, {
      method: "GET",
    });

    if (yanit.ok) {
      const book = await yanit.json();
      console.log(book);
      setBook(book);
      sayfalar[0] = book.pages[currentpage - 1];
      sayfalar[1] = book.pages[currentpage];
      book.pages.push("---END---");
      console.log(sayfalar);
    }
  }

  const nextpage = () => {
    setcurrentpage(currentpage + 2);
    sayfalar[0] = book.pages[currentpage + 2 - 1];
    sayfalar[1] = book.pages[currentpage + 2];
  };

  const prevpage = () => {
    setcurrentpage(currentpage - 2);
    sayfalar[0] = book.pages[currentpage - 2 - 1];
    sayfalar[1] = book.pages[currentpage - 2];
  };

  const searchpage = (e) => {
    console.log(e.target.value);
    let page = parseInt(e.target.value === "" ? "1" : e.target.value);
    page = page < 1 ? 1 : page;
    page = page > book?.pages?.length - 1 ? book?.pages.length - 1 : page;
    setcurrentpage(page);
    sayfalar[0] = book.pages[page - 1];
    sayfalar[1] = book.pages[page];
  };

  useEffect(() => {
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/Login");
    }
    const user = JSON.parse(data);
    setUser(user);
    console.log(user);

    kitabiAl(user);
  }, []);

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

      <div className='bg-hero-pattern h-screen flex flex-col items-center gap-5 '>
        <div className='bg-[#fdc13ffe] h-10 w-auto py-1 px-3 text-lg rounded-md flex items-center mr-[150px]'>
          <h2 className='text-l font-serif text-black'>{book?.title}</h2>
        </div>
        <div className='flex justify-between'>
          <button
            onClick={prevpage}
            className="px-4 py-2 rounded-lg bg-[#fdc13ffe] text-black font-semibold h-10 mt-[300px] mr-2 disabled:opacity-50 disabled:cursor-not-allowed"
            disabled={currentpage === 1} >
            <GrCaretPrevious />
          </button>
          <div className="bg-[#f2e6c9fe] p-6 h-8/9 w-[500px] rounded-l-md shadow-md ">
            <p className='font-serif text-xl'>{"Page: " + currentpage}</p>
            <p>{sayfalar[0]}</p>
          </div>
          <div className='bg-black h-[600px] w-[8px]'>
          </div>

          <div className="bg-[#f2e6c9fe] p-6 h-8/) w-[500px] rounded-r-md shadow-md">
            <p className='font-serif text-xl '>{"Page: " + (currentpage + 1)}</p>
            <p>{sayfalar[1]}</p>
          </div>

          <button
            onClick={nextpage}
            className="px-4 py-2 rounded-lg bg-[#fdc13ffe] text-black  font-semibold h-10 mt-[300px] ml-2 disabled:opacity-50 disabled:cursor-not-allowed"
            disabled={currentpage >= book?.pages?.length - 1} >
            <GrCaretNext />
          </button>
          <div className='flex flex-col'>
            <div className='flex items-center bg-[#f4eee2eb] p-1 rounded-full mt-8'>
              <input min={1} max={book?.pages?.length - 1} type="number" onChange={searchpage} className=' bg-transparent py-2 px-3 rounded-full hover:bg-[#dad2c0eb] text-lg font-semibold h-10 w-20 flex-1 placeholder-slate-400 ' placeholder='Enter page' />
              <FaSearch className='size-6 mr-1' />
            </div>
            <Link to="/BorrowedBooks" className='bg-[#fdc13ffe] py-2 px-3 text-lg rounded-lg hover:bg-[#f6ca6beb] h-10 w-auto mt-[400px]'>Go Borrowed Books</Link>
            {(user.roleName === "author") && (
              <Link to="/AuMyBook" className='bg-[#fdc13ffe] py-2 px-3 text-lg rounded-lg hover:bg-[#f6ca6beb] h-10 w-auto mt-4'>Go My Books</Link>
            )}
          </div>
        </div>
      </div>

    </div>
  )
}
export default ReadPage