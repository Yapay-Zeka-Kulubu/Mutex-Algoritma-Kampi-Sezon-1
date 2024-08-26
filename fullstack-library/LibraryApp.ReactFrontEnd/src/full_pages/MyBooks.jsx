import { Link } from "react-router-dom";
import { useUser } from "../AccountOperations/UserContext";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";

function MyBooksOP() {

    const { user } = useUser();
    const [myBooks, setMyBooks] = useState([]);

    const fetchBooks = async function () {
        const res = await fetch("http://localhost:5109/api/Book/GetBooksByAuthor?userId=" + user.id, {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });

        if (!res.ok) {
            const ressss = await res.json();
            console.log(ressss);
            return;
        }

        var myBooks = await res.json();
        var newMyBooks = myBooks.map(mb => ({
            bookId: mb.bookId,
            oldBookName: mb.bookName,
            newBookName: mb.bookName,
            publishDate: mb.publishDate,
            status: mb.status,
        }));
        setMyBooks(newMyBooks);
        console.log(newMyBooks);
    }

    useEffect(() => {
        fetchBooks();
    }, []);

    const handleRequestClick = async function (bookId) {
        const res = await fetch("http://localhost:5109/api/Book/RequestPublishment", {
            method: "POST",
            headers: { "Content-Type": "application/json",Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(bookId)
        });

        if (!res.ok) {
            const data = await res.json();
            console.log(data);
            toast.error(data.message || "An error occured");
            return;
        }
        toast.success("Request has sent");
        await fetchBooks();
    }

    const handleCreateClick = async function () {
        const res = await fetch("http://localhost:5109/api/Book/CreateBook", {
            method: "POST",
            headers: { "Content-Type": "application/json",Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(user.id)
        });

        if (!res.ok) return;
        const data = await res.json();
        toast.success(data.message || "Created.");
        await fetchBooks();
    }

    const handleChangeClick = async function (book) {
        if (book.oldBookName === book.newBookName) {
            toast.error("You did not changed the name");
            return;
        }

        const bookDTO = {
            bookId: book.bookId,
            bookName: book.newBookName,
            publishDate: book.publishDate,
            status: book.status,
        }

        const res = await fetch("http://localhost:5109/api/Book/UpdateBookName", {
            method: "PUT",
            headers: { "Content-Type": "application/json",Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(bookDTO)
        });

        const data = await res.json();
        if (!res.ok) return;

        toast.success(data.message);
        await fetchBooks();
    }

    const handleTitleChange = function (book, e) {
        book.newBookName = e.target.value;
    }

    return (
        <div className="container ">
            <div className="d-flex flex-row justify-content-between border-bottom border-dark align-items-end">
                <h1 className="pt-4">My Books</h1>
                <button onClick={handleCreateClick} className="btn btn-success mb-2">Create a book</button>
            </div>
            <div className="row py-2">
                <table className="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Book Name</th>
                            <th>Status</th>
                            <th>Publish Date</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {myBooks.map((mb, index) => (
                            <tr key={index}>
                                <td>{mb.oldBookName}</td>
                                <td>{mb.status}</td>
                                <td>{new Date(mb.publishDate).toLocaleDateString("en-us")}</td>
                                <td className="">
                                    <Link className="btn btn-success me-2" to={"/ReadBook?bookId=" + mb.bookId}>Read</Link>
                                    {(mb.status !== "Published") && <>
                                        <Link className="btn btn-success me-2" to={"/WriteBook?bookId=" + mb.bookId}>Write</Link>
                                        <button className="btn btn-success me-2" onClick={e => handleRequestClick(mb.bookId)}>Request publishment</button>
                                        {/* <button className="btn btn-success me-2">Delete</button> */}
                                        <div className="input-group w-75 mt-2">
                                            <input type="text" className="form-control" placeholder="Enter new name" onChange={(e) => handleTitleChange(mb, e)} />
                                            <button className="btn btn-success me-2" onClick={() => handleChangeClick(mb)}>Change</button>
                                        </div>
                                    </>}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default MyBooksOP;

//TODO profile page?