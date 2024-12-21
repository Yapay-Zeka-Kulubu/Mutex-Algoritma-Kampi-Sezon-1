import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import CardLink from "../CardLink"
import { useUser } from "../../AccountOperations/UserContext"


function GeneralOperationsCard() {
    const { user } = useUser();

    const items = (
        <>
            {(user.roleName !== "staff") && (
                <li className="mb-4">
                    <CardLink url="/ChangeRole" text="Change role of someone" />
                </li>
            )}
            <li className="">
                <CardLink url="/PunishSomeone" text="Set punishment of a user" />
            </li>
        </>
    )

    return (
        <HomeGeneralOperationsCard title="General Operations" items={items} />
    )
}

export default GeneralOperationsCard