import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";
import { useUser } from "../../AccountOperations/UserContext";
import SuccessButton from "../../Components/SuccessButton";
import DangerButton from "../../Components/DangerButton";

function BorrowRequestsOP() {

    const [bookBorrowDTOS, setBookBorrowDTOS] = useState([]);
    const [details, setDetails] = useState("");
    const { fetchData } = useFetch();
    const { user } = useUser();

    const fetchBorrowRequests = async function () {
        const data = await fetchData("/api/Book/BorrowRequests", "GET");
        setBookBorrowDTOS(data, []);
    };

    useEffect(() => {
        fetchBorrowRequests();
    }, []);

    const handleApproveRejectClick = async (isApproved, requestId) => {
        const br = {
            id: requestId,
            isApproved: isApproved,
            staffId: user.id,
            details: details,
        }

        fetchData("/api/Book/SetBorrowRequest", "POST", br)
            .then(async () => {
                await fetchBorrowRequests();
            });
    }

    const headersArray = ["Book", "Requestor", "Borrow Date", "Return Date", "Actions"];
    const datasArray = bookBorrowDTOS.map((b, index) => [
        b.bookDTO.title,
        b.requestorName,
        new Date(b.borrowDate).toLocaleDateString("en-US"),
        new Date(b.returnDate).toLocaleDateString("en-US"),
        (<ul key={index} className="flex justify-start ">
            <li className="me-2">
                <SuccessButton callback={() => { handleApproveRejectClick(true, b.id) }} text="Approve" />
            </li>
            <li className="me-2">
                <DangerButton callback={() => { handleApproveRejectClick(false, b.id) }} text="Reject" />
            </li>
            <li className="me-2 grow">
                <input onChange={e => setDetails(e.target.value)} placeholder="Details" type="text" className="px-4 py-2 rounded bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100" />
            </li>
        </ul>),
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default BorrowRequestsOP

//FIXME bazı sayfaların tasarımı küçük ekranlarda bozuluyor.