import React, { useEffect, useState } from 'react';
import { Link,useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

export default function BookList() {
const [books, setBooks] = useState([]); 
const [bookName , setBookName] = useState("");
const [user,setUser] =useState({});
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
  if (user === null)
  {
    nav("/login");
  }
  else
  {
    setUser(user);
    fetchBooks("");
  }
}, []);

const fetchBooks =async(bookName) => {
const yanit= await fetch("http://localhost:5075/api/Kitap/kitapArama?kitapIsmi=" + bookName);
if(yanit.ok){
  const data = await yanit.json();
  setBooks(data);
  console.log(data);
  }
};

const handleSearch = () => {
  fetchBooks(bookName); 
};

const handleBorrowClick = async (bookId) => {
  try{
    const yanit = await fetch ("http://localhost:5075/api/Kitap/kitapOduncTalepEt",
      {
        method : "POST",
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify ({
          isteyenId : user.id,
          kitapId : bookId,
        }),
      });

     
    if(yanit.ok)
      {
        toast.success("Borrowing request sent.", {
          onClose: () => nav(0)
        });
      }
      else{
        toast.error("Borrow request failed.");
      }
  }
  catch
  {
    toast.error("An error occurred while submitting a borrowing request");

  }
}

  return (
    <div>
      <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6 ">
        <h1 className="text-3xl font-bold">Books List</h1>
        <div className="flex">
            <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>
            <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>


        </div>
      </div>

      <div className='pl-6 pr-6 pt-2'>
        <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6 ">
          <div className="flex">

            <input
              onChange={e=>setBookName(e.target.value)}
              id="book-search"
              className="pr-10 pl-10 border text-black border-gray-300 rounded-lg shadow-sm"
              type="text"
              placeholder="Book Name..."
            />

            <button 
             onClick={handleSearch}
            className="bg-violet-700 text-white py-2 px-4 ml-2 rounded-lg shadow-lg">
              Search
            </button>

          </div>
        </div>
      </div>

      <div className='pl-10 pr-10'>
        <div className="bg-white shadow-lg rounded-lg p-6">
        <table className="min-w-full">
                    <thead>
                      <tr className="bg-purple-600 text-white">
                        <th className="p-6 text-left">Title</th>
                        <th className="p-6 text-left">Authors</th>
                        <th className="p-6 text-left">Publication Date</th>
                        <th className="p-6 text-left">Is Borrowed</th>
                        <th className="p-6 text-left">Actions</th>
                      </tr>
                    </thead>
                    <tbody>
                      {books.map((book, index) => (
                        <tr key={index} className="border-b">
                          <td className="p-6">{book.kitapIsmi}</td>
                          <td className="p-6">{book.kitapYazarlari.join(" , ")}</td>
                          <td className="p-6">{book.yayinlanmaTarihi}</td>
                          <td className="p-6">{book.oduncAlindiMi?"Yes":"No"}</td>

                          <td className="p-6">
                            <Link to={"/ReadBook?bookId="+book.id} className="bg-blue-500 text-white py-1 px-2 rounded-lg mr-2">
                              Preview
                            </Link>
                            <button
                            onClick={ () => handleBorrowClick(book.id)}
                            disabled={book.oduncAlindiMi}
                            className="bg-green-500 text-white py-1 px-2 rounded-lg disabled:bg-green-500/50">
                              Borrow
                            </button>
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
        </div>
      </div>
    </div>
  );
}