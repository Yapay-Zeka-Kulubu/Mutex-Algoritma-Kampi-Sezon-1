import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

//özge
const AuMybook = () => {

  const [reqBooks, setreqBooks] = useState([]);
  const [user, setUser] = useState({});
  const nav = useNavigate();
  //request url içine id girdim doğru mu 
  const [showForm, setshowForm] = useState(false);
  const [title, settitle] = useState("");
  const [type, settype] = useState("");
  const [pages, setpages] = useState(0);

  //button değişikliği için
  // const [buttonText, setbuttonText] = useState('Request Publishment');
  // const [buttonColor, setbuttonColor] = useState('#2345');
  // const[isClicked, setisClicked]=useState(false);

  const checkUser = () => {
    const data = localStorage.getItem("userData");
    if (data === null) {
      nav("/Login");
      return;
    }

    const user = JSON.parse(data);
    setUser(user);

    if (user.roleName !== "author") {
      nav("/");
      return;
    }

    fetchAumybookRequest(user);
  }

  const fetchAumybookRequest = async (user) => {
    const yanit = await fetch(`http://localhost:5249/api/Book/byauthor/${user.id}`, {
      method: "GET"
    });

    if (yanit.ok) {
      const reqBooks = await yanit.json();
      setreqBooks(reqBooks);
    }
  }

  useEffect(() => {
    checkUser();
  }, [])

  const createbook = async (e) => {
    e.preventDefault();

    const newbook = {
      title: title,
      type: type,
      yazarId: user.id,
    }

    const yanit = await fetch(`http://localhost:5249/api/Book/create`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newbook),
    });

    setshowForm(!showForm);
    if (yanit.ok) {
      const data=await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }
    else {
      const data=await yanit.json();
      toast.error("Something went wrong!");
    }
  }
  // //BU FONKSİYON DA ÇALIŞMIYOR :(((((
  // const AddPage = async () => {
  //   const Page = {
  //     bookId: 0,
  //     content: "string",
  //     pageNumber: 0,
  //   }
  //   const yanit = await fetch(`http://localhost:5249/api/Book/5/addpage`, {
  //     method: "POST",
  //     headers: { "Content-Type": "application/json" },
  //     body: JSON.stringfy(Page),
  //   });
  //   if (yanit.ok) {
  //     console.log("yeni sayfa eklendi");
  //   }
  //   else {
  //     console.log("yeni sayfa eklenemedi");
  //   }

  // }

  const PublishRequest = async (bookId) => {
    const yanit = await fetch(`http://localhost:5249/api/Book/requestpublishment`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        kitapId: bookId,
        yazarId: user.id,
      }),
    });
    if (yanit.ok) {
      const data=await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }
    else {
      const data=await yanit.json();
      toast.error("Something went wrong!");
    
    }
  }


  // const handleClick = () => {
  //   // setbuttonText('Pending');
  //   // setbuttonColor('#3456');
  //   setisClicked(!isClicked);
  // }

  const handleTitleChange = (e, id) => {
    const book = reqBooks.find(book => book.id == id);
    book.title = e.target.value;
  };

  const changeTitle = async (bookId) => {
    const book = reqBooks.find(book => book.id == bookId);
    const newbook = {
      yeniIsim: book.title,
      bookId: bookId
    };

    const yanit = await fetch(`http://localhost:5249/api/Book/editBookTitle`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newbook),
    });

    if (yanit.ok) {
    const data=await yanit.json();
      toast.success(data.message, { onClose: () => nav(0) });
    }
    else {
    const data= await yanit.json();
    toast.error("Something went wrong!");
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
      {/*under side  */}
      <div>
        <button onClick={() => setshowForm(!showForm)} className=' bg-[#d51760fe] text-white rounded-md text-lg font-medium p-2 hover:bg-[#ec5b67d6] ml-[1300px] mt-[15px] '>Create a book</button>
        {/* ekrana verilecek  olan form */}

        {showForm &&
          (<form onSubmit={(e) => {
            e.preventDefault();

          }} className=' fixed inset-0 bg-white h-[450px] w-[300px] rounded-md text-black text-base 
        tracking-normal p-8 flex flex-col gap-4 border border-black cursor-pointer place-self-center'>
            <h1 className='text-3xl text-center text-black font-bold tracking-wider'>CREATE NEW BOOK</h1>

            <div className='flex flex-col justify-center items-center'>
              <label>TİTLE</label>
              <input onChange={e => settitle(e.target.value)} type='text' className='border-b-2 border-pink-600 bg-[#c1c2be33] text-black
              hover:bg-[#9fa19e44] transition-all focus: outline-none'></input>
            </div>
            <div className='flex flex-col justify-center items-center'>
              <label>TYPE</label>
              <input onChange={e => settype(e.target.value)} type='text' className='flex flex-col border-b-2 border-pink-600 bg-[#c1c2be33] text-black
              hover:bg-[#9fa19e44] transition-all focus: outline-none'></input>
            </div>
            <button onClick={createbook} className='bg-[#d51760fe] text-white rounded-md text-md font-medium hover:bg-[#ec5b67d6] h-[30px] w-[150px] absolute bottom-[105px]
              place-self-center transition-all  '>CREATE</button>
          </form>)}

        <h1 className='text-2xl font-serif pl-[700px]'>MY BOOKS</h1>
        <div className='mt-[20px] ml-[90px] overflow-y-auto max-h-[550px]  '>
          <table className='border-2 border-black bg-white text-black'>
            <thead className='bg-[#f9dd76c6] text-xs'>
              <tr className='border-b-2 border-black'>
                <th className='py-3 pl-4 pr-[180px] font-serif'>BOOK NAME</th>
                <th className='py-3  pr-[150px] font-serif'>TYPE OF BOOK</th>
                <th className='py-3  pr-[100px] font-serif'>PAGES</th>
                <th className='py-3  pr-[600px] font-serif'>ACTIONS</th>
              </tr>
            </thead>
            <tbody className='text-black text-base'>
              {reqBooks.map((book, index) => (
                <tr className='border-b-2 border-black'>
                  <td className='py-3 pl-4 font-medium text-lg'>{book.title}</td>
                  <td className='py-3 font-medium'>{book.type}</td>
                  <td className='py-3 font-medium'>{book.number_of_pages}</td>
                  <td className='py-2'>
                    {/* name input */}
                    {(!book.isBookPublished) && (
                      <>
                        <div className='flex flex-row mb-2'>
                          <input onChange={e => handleTitleChange(e, book.id)} type='text' className='  w-60 h-8 bg-gray-300 p-2 rounded-sm text-black' placeholder='Enter new name' />
                          <button onClick={e => changeTitle(book.id)} className='bg-black  text-white rounded-sm text-sm font-medium p-1 hover:bg-neutral-900 mr-3 '>CHANGE</button>
                        </div>

                        <Link to={"/WriteBook?bookId=" + book.id} className='bg-[#19871b] text-white rounded-md text-sm font-medium p-2 hover:bg-[#58bb46d2]  mr-3 '>WRITE</Link>
                        <button onClick={() => PublishRequest(book.id)} className='bg-[#d51760fe] text-white rounded-md text-sm font-medium p-2 hover:bg-[#ec5b67d6] mr-3 '> Request Publishment </button>
                      </>)}
                    <Link to={"/ReadBook?bookId=" + book.id} className='bg-[#fab914fe] text-white  rounded-md text-sm font-medium p-2 hover:bg-[#dcaa4de7] ml-[80px]] mr-3 '>READ</Link>
                    {/* create:create change : add page, write:router writepage2???? req:req  read: router read page miii */}
                  </td>
                </tr>
              ))}



            </tbody>
          </table>
        </div>

      </div>
    </div>
  )
}

export default AuMybook
