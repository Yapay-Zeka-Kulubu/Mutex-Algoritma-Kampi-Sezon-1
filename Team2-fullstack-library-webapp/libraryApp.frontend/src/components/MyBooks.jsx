import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

export default function MyBooks() {

    const [user, setUser] = useState({});
    const [books, setBooks] = useState([]);
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
        else if (user.rolIsmi !== "yazar") {
            nav("/HomePage");
        }
        else {
            setUser(user);
            fetchBooks(user);
        }
    }, []);


    const fetchBooks = async (user) => {
        const yanit = await fetch("http://localhost:5075/api/Kitap/yazarinKitaplariniGetir/" + user.id, {
            method: "GET",
        });

        if (yanit.ok) {
            const data = await yanit.json();
            setBooks(data);
            console.log(data);
        }
    }

    const createBook = async () => {
        const yanit2 = await fetch("http://localhost:5075/api/Kitap/kitapOlustur", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(user.id),
        });

        if (yanit2.ok) {
            toast.success("Book created successfully.", {
                onClose: () => nav(0)
            });
        } else {
            toast.error("An error occurred while creating the book.");
        }
    }

    const handleRequestClick = async (kitapId) => {
        const yanit = await fetch("http://localhost:5075/api/Kitap/yayinlamaIstegiAt", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                yazarId: user.id,
                kitapId: kitapId
            })
        });

        if (yanit.ok) {
            toast.success("Success.", {
                onClose: () => nav(0) })
        } else {
            toast.error("Failed.")
        }
    };

    const handleChangeNameInput = (e, bookId) => {
        const book = books.find(b => b.id == bookId);
        book.kitapIsmi = e.target.value;
    };

    const handleChangeNameClick = async (bookId) => {
        const book = books.find(b => b.id == bookId);
        console.log(book);

        const yanit = await fetch("http://localhost:5075/api/Kitap/kitapIsimDegis", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                "kitapId": bookId,
                "yeniIsim": book.kitapIsmi,
            })
        });

        if (yanit.ok) {
            toast.success("Success.", {
                onClose: () => nav(0) })
        }
        else {
            toast.error("Failed.")
        }
    };

    return (
        <div className="p-6 bg-white min-h-screen">

            <div className="flex justify-between items-center bg-violet-700 text-white p-4 rounded-md shadow-lg mb-6">
                <h1 className="text-2xl font-bold">My Books</h1>
                <div className="flex">
                    <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>
                    <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
                </div>
            </div>


            <div className="flex justify-end mb-4">
                <button onClick={createBook} className="bg-violet-500 text-white py-2 px-4 rounded-md shadow-lg">
                    Create a book
                </button>
            </div>


            <div className="bg-gray-100 shadow-lg rounded-lg p-6">
                <table className="min-w-full table-auto">
                    <thead>
                        <tr className="bg-violet-500 text-white">
                            <th className="p-4 text-left">BOOK NAME</th>
                            <th className="p-4 text-left">STATUS</th>
                            <th className="p-4 text-left">PUBLISH DATE</th>
                            <th className="p-4 text-left">ACTIONS</th>
                        </tr>
                    </thead>

                    <tbody>
                        {books.map((book, index) => (
                            <tr key={index} className="border-b border-gray-700">
                                <td className="p-4">{book.kitapIsmi}</td>
                                <td className="p-4">{book.yayinlandiMi ? "Yes": "No"}</td>
                                <td className="p-4">{book.yayinlanmaTarihi}</td>
                                <td className="p-4 flex space-x-2">
                                    {(!book.yayinlandiMi) && (
                                        <>
                                            <input
                                                type="text"
                                                placeholder="Enter new name"
                                                className="p-1 rounded-md text-black"
                                                onChange={(e) => handleChangeNameInput(e, book.id)}
                                            />
                                            <button onClick={() => { handleChangeNameClick(book.id) }} className="bg-green-500 text-white py-1 px-2 rounded-lg">
                                                Change name
                                            </button>
                                            <Link className="bg-blue-500 text-white py-1 px-2 rounded-lg" to={"/WritePage?bookId=" + book.id}>
                                                Write
                                            </Link>
                                            <button onClick={() => { handleRequestClick(book.id) }} className="bg-green-500 text-white py-1 px-2 rounded-lg">
                                                Request publishment
                                            </button>
                                        </>
                                    )}
                                    <Link to={"/ReadBook?bookId=" + book.id} className="bg-gray-500 text-white py-1 px-2 rounded-lg">
                                        Read
                                    </Link>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}