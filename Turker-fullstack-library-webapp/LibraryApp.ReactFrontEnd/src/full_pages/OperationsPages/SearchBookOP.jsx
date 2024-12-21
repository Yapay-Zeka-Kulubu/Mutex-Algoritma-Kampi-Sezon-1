import { useLocation} from "react-router-dom";
import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext"
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";
import DefaultLink from "../../Components/DefaultLink";

function SearchBookOP() {
    const [books, setBooks] = useState([]);
    const location = useLocation();
    const bookName = new URLSearchParams(location.search).get("book");
    const { user } = useUser();
    const { fetchData } = useFetch();

    const onSearch = async function (bookQuery) {
        const data = await fetchData("/api/Book/SearchBook?bookName=" + encodeURIComponent(bookQuery), "GET");
        setBooks(data ?? []);
    };

    useEffect(() => {
        onSearch(bookName);
    }, [])

    const handleBorrowClick = async (book) => {
        const bookDTO = { userId: user.id, bookId: book.id }
        await fetchData("/api/Book/BorrowBook", "POST", bookDTO);
    }

    const headersArray = ["Title", "Publish date", "Is Borrowed", "Actions"];
    const datasArray = books.map((b,index) => [
        b.title,
        new Date(b.publishDate).toLocaleDateString("en-us"),
        b.isBorrowed ? "Yes" : "No",
        (<ul key={index} className="flex justify-start">
            <li className="me-2">
                <DefaultLink url={`/ReadBook?bookId=` + b.id} text={"Preview the book"} /> 
            </li>
            <li className="me-2">
                <button onClick={() => { handleBorrowClick(b) }} className="border border-transparent inline-block rounded px-4 py-2 bg-success hover:bg-success-dark hover:ring-2 hover:ring-success transition-all duration-100 text-text disabled:bg-success-dark/40 disabled:ring-0 disabled:outline-none active:bg-success-dark/60 font-medium focus:outline-none focus:ring-2 focus:ring-success-dark  hover:outline-none active:outline-none" disabled={b.isBorrowed}>Borrow</button>
            </li>
        </ul>)
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard onSearch={onSearch} />)} rightPanel={rightPanel} />)
}

export default SearchBookOP