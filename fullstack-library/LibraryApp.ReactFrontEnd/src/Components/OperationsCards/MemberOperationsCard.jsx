import { Link } from "react-router-dom";
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"


function MemberOperationsCard() {

    const items = (
        <>
            <li className="mb-4">
                <Link className="btn bg-custom-primary" to="/BorrowRequests">See borrow requests</Link>
            </li>
            <li className="">
                <Link className="btn bg-custom-primary" to="/MemberRegistirations">See member registirations</Link>
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="Member Operations" items={items} />
    )
}

export default MemberOperationsCard