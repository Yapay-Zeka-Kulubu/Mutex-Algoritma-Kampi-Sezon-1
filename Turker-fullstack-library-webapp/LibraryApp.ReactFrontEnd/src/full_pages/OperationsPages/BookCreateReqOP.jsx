import AuthorOperationsCard from "../../Components/OperationsCards/AuthorOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react"
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";
import { useUser } from "../../AccountOperations/UserContext";
import DefaultLink from "../../Components/DefaultLink";
import SuccessButton from "../../Components/SuccessButton";
import DangerButton from "../../Components/DangerButton";

function BookCreateReqOP() {

    const [requests, setRequests] = useState([]);
    const [details, setDetails] = useState("");
    const { fetchData } = useFetch();
    const { user } = useUser();

    const fetchPendingRequests = async function () {
        const data = await fetchData("/api/Book/BookPublishRequests", "GET");
        setRequests(data ?? []);
    }

    useEffect(() => {
        fetchPendingRequests();
    }, []);

    async function handleApproveRejectClick(requestId, isApproved) {
        const publishBookDTO = {
            requestId: requestId,
            isApproved: isApproved,
            managerId: user.id,
            details: details,
        }

        await fetchData("/api/Book/SetPublishing", "PUT", publishBookDTO);

        const updatedRequests = requests.filter(r => r.id != requestId);
        setRequests(updatedRequests);
    }

    const headersArray = ["Book name", "Author", "Request date", "Actions"];
    const datasArray = requests.map((r, index) => [
        r.bookName,
        r.authors.join(", "),
        new Date(r.requestDate).toLocaleDateString("en-us"),
        (<ul key={index} className="flex justify-start flex-wrap">
            <li className="me-2">
                <DefaultLink url={`/ReadBook?bookId=` + r.bookId} text="Read the book" />
            </li>
            <li className="me-2">
                <SuccessButton callback={() => handleApproveRejectClick(r.id, true)} text={"Approve"} />
            </li>
            <li className="me-2">
                <DangerButton callback={() => { handleApproveRejectClick(r.id, false) }} text={"Reject"}/>
            </li>
            <li className="me-2 grow"><input onChange={e => setDetails(e.target.value)} placeholder="Details" type="text" className="rounded mt-3 lg:mt-0 px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100" /></li>
        </ul>),
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )

    return (<GeneralOperationsPage leftPanel={(<AuthorOperationsCard />)} rightPanel={rightPanel} />)
}

export default BookCreateReqOP