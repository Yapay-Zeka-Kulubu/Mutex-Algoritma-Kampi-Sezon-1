import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useUser } from '../../AccountOperations/UserContext'
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";
import SuccessButton from "../../Components/SuccessButton";


function SendMessageOP() {

    const [receivers, setReceivers] = useState([]);
    const { user } = useUser();
    const [receiverId, setReceiverId] = useState(0);
    const [title, setTitle] = useState("");
    const [message, setMessage] = useState("");
    const { fetchData } = useFetch();

    const fetchReceivers = async function () {
        const data = await fetchData(`/api/User/GetUsersOfLowerUpperRole?roleId=${user.roleId}&userId=${user.id}`, "GET");
        setReceivers(data ?? []);
    }

    useEffect(() => {
        fetchReceivers();
        console.log(receivers);
    }, []);

    const handleSendClick = async function (e) {
        e.preventDefault();

        if (!receiverId || !title || !message) {
            toast.error("Please fill all the fields");
            return;
        }

        const messageDTO = {
            senderId: user.id,
            receiverId: receiverId,
            title: title,
            details: message,
        }

        fetchData("/api/User/SendMessage", "POST", messageDTO)
            .then(() => {
                setReceiverId(0);
                setTitle("");
                setMessage("");
            });
    }

    const rightPanel = (
        <form className="grow flex flex-col px-14 py-6">
            <div className="mb-3">
                <label htmlFor="sendingTo" className="text-text block font-medium mb-1">Select an option</label>
                <select id="sendingTo" value={receiverId} className="px-4 py-2 bg-primary-light text-text block w-full hover:ring-accent/50 focus:ring-accent focus:ring-2  focus:outline-none hover:ring-2 rounded" onChange={e => setReceiverId(e.target.value)}>
                    <option value="">Select receiver</option>
                    {receivers.map((rc, index) => (
                        <option key={index} value={rc.id}>{rc.name + " - " + rc.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="mb-3">
                <label htmlFor="title" className="text-text font-medium mb-1 block">Title</label>
                <input type="text" id="title" className="px-4 py-2 w-full rounded bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100" onChange={e => setTitle(e.target.value)} value={title} maxLength={75} />
            </div>
            <div className="mb-3 grow flex flex-col">
                <label htmlFor="message" className="block text-text font-medium mb-1">Your message</label>
                <textarea type="text" id="message" className="grow px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" style={{ resize: "none" }} value={message} onChange={e => setMessage(e.target.value)}></textarea>
            </div>
            <div className="self-end">
                <SuccessButton callback={e => handleSendClick(e)} text={"Send"} />
            </div>
        </form>
    );

    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default SendMessageOP