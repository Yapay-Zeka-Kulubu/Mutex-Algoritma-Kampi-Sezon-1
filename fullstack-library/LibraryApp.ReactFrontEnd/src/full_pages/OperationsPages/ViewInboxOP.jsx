import { useEffect, useState } from "react";
import MessageOperationsCard from "../../Components/OperationsCards/MessageOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useUser } from "../../AccountOperations/UserContext"

function ViewInboxOP() {
    //TODO maybe do message card jsx component for left panel to not repeat same codes
    //TODO add title of message

    const { user } = useUser();
    const [messages, setMessages] = useState([]);
    const [senderName, setSenderName] = useState("");
    const [msgDetails, setMsgDetails] = useState("");
    const [msgTitle, setMsgTitle] = useState("");

    const getInbox = async function () {
        const res = await fetch("http://localhost:5109/api/User/GetInbox?userId=" + user.id, {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });
        if (!res.ok) return;
        const messages = await res.json();
        setMessages(messages);
        console.log(messages);
    }

    const updateReadMsg = async function (msg) {
        console.log(JSON.stringify(msg));
        const res = await fetch("http://localhost:5109/api/User/UpdateMessageReadState", {
            method: "POST",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(msg),
        });

        if (!res.ok) return;

        const data = await res.json();
        console.log(data);
    }

    useEffect(() => {
        getInbox();
    }, []);

    const handleMsgCardClick = async function (message) {
        setSenderName(message.senderName);
        setMsgDetails(message.details);
        setMsgTitle(message.title);

        if (!message.isReceiverRead) {
            updateReadMsg(message);

            message.isReceiverRead = true;

            //to make react re render page
            const updatedMessages = messages.map(m =>
                m.id === message.id ? { ...m, isReceiverRead: true } : m
            );
            setMessages(updatedMessages);
        }
    }
    //FIXME long compound words breaks the style of title etc.
    const rightPanel = (
        <div className="d-flex flex-column flex-fill">
            <h6 className="text-start ms-2">[ {messages.filter(m => !m.isReceiverRead).length} unread messages ]</h6>
            <div className="d-flex container p-0 flex-fill justify-content-between">
                <div className="col-3 me-2 p-2 bg-light rounded" style={{ height: "65vh", overflow: "auto" }}>
                    {messages.map((m, index) =>
                    (
                        <div key={index} onClick={() => { handleMsgCardClick(m) }} className="mb-2 d-flex flex-column border border-dark rounded p-2 bg-success-subtle btn">
                            <div className="d-flex mb-2 justify-content-between border-bottom border-dark">
                                <p className="mb-1 pe-1 text-start fs-7">{m.title.slice(0, 10) + "..."}</p>
                                <p className="mb-1 ps-1 fs-8 text-end"><b>{m.senderName}</b></p>
                            </div>
                            <div className="d-flex justify-content-between">
                                <p className="pt-1 fs-8 mb-2 text-start">{m.details.slice(0, 20) + "..."}</p>
                                <span className={`badge ${m.isReceiverRead ? "text-bg-primary" : "text-bg-danger"} align-self-center ms-2 p-1`}>{m.isReceiverRead ? "read" : "unread"}</span>
                            </div>
                        </div>
                    )
                    )}
                </div>
                <div className="col-9 p-2 bg-light rounded d-flex flex-column" style={{ height: "65vh" }}>
                    <div className="d-flex justify-content-between bg-success-subtle border-bottom border-dark px-3 pt-3 pb-0 rounded mb-2">
                        <div className="text-start">{msgTitle}</div>
                        <h5 className="text-end">{senderName}</h5>
                    </div>
                    <div className="p-3 bg-success-subtle px-3 pt-3 pb-0 rounded flex-fill" style={{ overflow: "auto" }}>
                        <p>{msgDetails}</p>
                    </div>
                </div>
            </div>
        </div>
    );
    //FIXME yazı uzayınca nedense genişliyor
    return (<GeneralOperationsPage leftPanel={(<MessageOperationsCard />)} rightPanel={rightPanel} />)
}

export default ViewInboxOP