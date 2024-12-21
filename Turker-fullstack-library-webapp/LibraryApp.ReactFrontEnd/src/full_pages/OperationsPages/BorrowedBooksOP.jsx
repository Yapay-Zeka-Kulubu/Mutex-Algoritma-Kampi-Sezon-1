import BookOperationsCard from "../../Components/OperationsCards/BookOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";
import DefaultLink from "../../Components/DefaultLink";
import SuccessButton from "../../Components/SuccessButton";


function BorrowedBooksOP() {

    const { user } = useUser();
    const [books, setBooks] = useState([]);
    const { fetchData } = useFetch();

    const fetchBorrowedBooks = async function () {
        const data = await fetchData("/api/Book/BorrowedBooks?userId=" + user.id, "GET");
        setBooks(data ?? []);
    }

    useEffect(() => {
        fetchBorrowedBooks();
    }, []);

    const handleReturnClick = async (book) => {
        fetchData("/api/Book/ReturnBook", "PUT", book.id)
            .then(() => {
                fetchBorrowedBooks();
            });
    }

    const headersArray = ["Title", "Authors", "Publish Date", "Borrowed Date", "Return Date", "Actions"];
    const datasArray = books.map((b, index) => [
        b.bookDTO.title,
        b.bookDTO.authors.join(", "),
        new Date(b.bookDTO.publishDate).toLocaleDateString("en-us"),
        new Date(b.borrowDate).toLocaleDateString("en-us"),
        new Date(b.returnDate).toLocaleDateString("en-us"),
        (<ul key={index} className="flex justify-start">
            <li className="me-2">
                <DefaultLink url={`/ReadBook?bookId=` + b.bookDTO.id} text={"Read"} />
            </li>
            <li className="me-2">
                <SuccessButton callback={() => { handleReturnClick(b.bookDTO) }} text={"Return"} />
            </li>
        </ul>),
    ]);


    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<BookOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowedBooksOP