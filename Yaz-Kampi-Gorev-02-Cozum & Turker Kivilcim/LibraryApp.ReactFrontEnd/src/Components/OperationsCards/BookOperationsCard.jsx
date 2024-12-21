import { useNavigate} from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import { useState } from "react";
import CardLink from "../CardLink";

function BookOperationsCard({ onSearch }) {

    const [bookQuery, setBookQuery] = useState('');
    const nav = useNavigate();

    function handleInputChange(e) {
        setBookQuery(e.target.value);
    }

    const searchBookLink = "/SearchBook?book=" + bookQuery;
    function handleSearchClick() {
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
                <div className="flex grow">
                    <input type="text" className="px-4 py-3 text-sm w-full rounded-s bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100" placeholder="Book's name" onChange={handleInputChange} />
                    <button className="text-xs rounded-e bg-accent inline-block px-5 py-1 hover:bg-accent-dark transition-all duration-100 active:bg-accent-dark/50 text-text font-semibold ease-in-out hover:ring-2 hover:ring-accent" onClick={handleSearchClick}>Search</button>
                </div>
            </li>
            <li className="">
                <CardLink url="/BorrowedBooks" text="View borrowed books"/>
            </li>
        </>
    );

    return (
        <HomeGeneralOperationsCard title="Book Operations" items={items} />
    )
}

export default BookOperationsCard