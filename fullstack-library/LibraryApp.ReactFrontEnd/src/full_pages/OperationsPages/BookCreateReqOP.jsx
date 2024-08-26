import { Link } from "react-router-dom"
import AuthorOperationsCard from "../../Components/OperationsCards/AuthorOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react"
import { toast } from "react-toastify";

function BookCreateReqOP() {

    const [requests, setRequests] = useState([]);

    const getPendingRequests = async function () {
        const response = await fetch("http://localhost:5109/api/Book/BookPublishRequests", {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }
        });

        const data = await response.json();
        if (!response.ok) return;
        setRequests(data);
    }

    useEffect(() => {
        getPendingRequests();
    }, []);

    async function handleApproveRejectClick(requestId, isApproved) {
        const publishBookDTO = {
            requestId: requestId,
            isApproved: isApproved,
        }

        const response = await fetch("http://localhost:5109/api/Book/SetPublishing", {
            method: "PUT",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(publishBookDTO),
        });

        const data = await response.json();
        console.log(data);
        if (!response.ok) return;

        if (isApproved) toast.success("Request approved");
        else toast.error("Request rejected");

        const updatedRequests = requests.filter(r => r.id != requestId);
        setRequests(updatedRequests);
    }

    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Book Name</th>
                    <th>Authors</th>
                    <th>Request Date</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {requests.map((b, index) => (
                    <tr key={index}>
                        <td>{b.bookName}</td>
                        <td>{b.authors.join(", ")}</td>
                        <td>{new Date(b.requestDate).toLocaleDateString("en-us")}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link to={`/ReadBook?bookId=` + b.bookId} className={`py-1 px-2 btn btn-danger`}>Read the book</Link></li>
                                <li className="me-2"><button onClick={() => { handleApproveRejectClick(b.id, true) }} className={`py-1 px-2 btn btn-success`}>Approve</button></li>
                                <li className="me-2"><button onClick={() => { handleApproveRejectClick(b.id, false) }} className={`py-1 px-2 btn btn-danger`}>Reject</button></li>
                            </ul>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table >
    )

    return (<GeneralOperationsPage leftPanel={(<AuthorOperationsCard />)} rightPanel={rightPanel} />)
}

export default BookCreateReqOP