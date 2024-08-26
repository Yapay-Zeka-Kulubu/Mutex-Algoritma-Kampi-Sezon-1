import { Link } from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";
import { toast } from "react-toastify";


function BorrowedBooksOP() {

    const { user } = useUser();
    const [books, setBooks] = useState([]);

    const getBorrowedBooks = async function () {
        var response = await fetch("http://localhost:5109/api/Book/BorrowedBooks?userId=" + user.id, {
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }
        });
        var books = await response.json();
        console.log(books);
        setBooks(books);
    }

    useEffect(() => {
        getBorrowedBooks();
    }, []);

    async function handleReturnClick(book) {
        console.log(book.id);
        const res = await fetch("http://localhost:5109/api/Book/ReturnBook", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`
            },
            body: JSON.stringify(book.id),
        });

        const data = await res.json();
        if (!res.ok) return;
        toast.success(data.message);
        getBorrowedBooks();
    }

    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Authors</th>
                    <th>Publish Date</th>
                    <th>Borrowed Date</th>
                    <th>Return Date</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {books.map((b, index) => (
                    <tr key={index}>
                        <td>{b.bookDTO.title}</td>
                        <td>{b.bookDTO.authors.join(", ")}</td>
                        <td>{new Date(b.bookDTO.publishDate).toLocaleDateString("en-us")}</td>
                        <td>{new Date(b.borrowDate).toLocaleDateString("en-us")}</td>
                        <td>{new Date(b.returnDate).toLocaleDateString("en-us")}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link to={`/ReadBook?bookId=` + b.bookDTO.id} className={`py-1 px-2 btn btn-danger`}>Read</Link></li>
                                <li className="me-2"><Link onClick={() => { handleReturnClick(b.bookDTO) }} className={`py-1 px-2 btn btn-success`}>Return</Link></li>
                            </ul>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table >
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowedBooksOP