import { useNavigate, Link, Navigate } from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import { useState } from "react";

function BookOperationsCard({ onSearch }) {

    const [bookQuery, setBookQuery] = useState('');
    const nav = useNavigate();

    function handleInputChange(e) {
        setBookQuery(e.target.value);
    }

    const searchBookLink = "/SearchBook?book=" + bookQuery;
    function handleSearch() {
        if (onSearch) {
            onSearch(bookQuery);
            nav(searchBookLink);
        }
        else
            nav(searchBookLink);
    }


    const items = (
        <>
            <li className="mb-4">
                <div className="input-group">
                    <input type="text" className="form-control" placeholder="Book's name" onChange={handleInputChange} />
                    <button className="btn bg-custom-primary" onClick={handleSearch}>Search book</button>
                </div>
            </li>
            <li className="">
                <Link className="btn bg-custom-primary" to="/BorrowedBooks">View borrowed books</Link>
            </li>
        </>
    );

    return (
        <HomeGeneralOperationsCard title="Book Operations" items={items} />
    )
}

export default BookOperationsCard