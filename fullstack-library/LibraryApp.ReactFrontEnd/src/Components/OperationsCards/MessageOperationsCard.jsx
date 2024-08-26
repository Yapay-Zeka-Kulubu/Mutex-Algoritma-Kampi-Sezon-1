import { Link } from "react-router-dom"
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"


function MessageOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <Link className="btn bg-custom-primary" to="/SendMessage">Send message</Link>
            </li>
            <li className="">
                <Link className="btn bg-custom-primary" to="/ViewInbox">View inbox</Link>
            </li>
        </>)

    return (
        <HomeGeneralOperationsCard title="Message Operations" items={items} />
    )
}

export default MessageOperationsCard