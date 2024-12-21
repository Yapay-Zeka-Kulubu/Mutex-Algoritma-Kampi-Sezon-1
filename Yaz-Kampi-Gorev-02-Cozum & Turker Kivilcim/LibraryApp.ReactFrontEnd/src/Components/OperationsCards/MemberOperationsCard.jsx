import { Link } from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import CardLink from "../CardLink";


function MemberOperationsCard() {

    const items = (
        <>
            <li className="mb-4">
                <CardLink url="/BorrowRequests" text="See pending borrow requests" />
            </li>
            <li className="">
                <CardLink url="/MemberRegistirations" text="See pending member registirations" />
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="Member Operations" items={items} />
    )
}

export default MemberOperationsCard