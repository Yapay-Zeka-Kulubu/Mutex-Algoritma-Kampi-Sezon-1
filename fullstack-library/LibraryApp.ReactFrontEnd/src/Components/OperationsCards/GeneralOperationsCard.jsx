import { Link } from "react-router-dom"
import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"

function GeneralOperationsCard() {
    const items = (
        <>
            <li className="mb-4">
                <Link className="btn bg-custom-primary" to="/ChangeRole">Change role of someone</Link>
            </li>
            <li className="">
                <Link className="btn bg-custom-primary" to="/PunishSomeone">Punish someone</Link>
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="General Operations" items={items} />
    )
}

export default GeneralOperationsCard

//TODO profile page and my books page for authors. my books page includes writing a book and books of all currently being writed ones