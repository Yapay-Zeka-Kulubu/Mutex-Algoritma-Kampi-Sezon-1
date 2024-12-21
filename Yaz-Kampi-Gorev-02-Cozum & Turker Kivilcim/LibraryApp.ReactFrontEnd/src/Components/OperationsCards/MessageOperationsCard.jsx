import { Link } from "react-router-dom"
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import CardLink from "../CardLink"


function MessageOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <CardLink url="/SendMessage" text="Send message" />
            </li>
            <li className="">
                <CardLink url="/ViewInbox" text="View inbox" />
            </li>
        </>)

    return (
        <HomeGeneralOperationsCard title="Message Operations" items={items} />
    )
}

export default MessageOperationsCard