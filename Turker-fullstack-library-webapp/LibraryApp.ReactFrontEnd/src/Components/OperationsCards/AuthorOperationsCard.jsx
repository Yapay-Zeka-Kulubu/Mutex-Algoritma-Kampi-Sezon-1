import HomeGeneralOperationsCard from "./HomeGeneralOperationsCard"
import CardLink from "../CardLink";

function AuthorOperationsCard() {

    const items = (
        <>
            <li className="">
                <CardLink url="/BookCreateRequests" text="See pending book creation requests" />
            </li>
        </>
    );

    return (
        <>
            <HomeGeneralOperationsCard title="Author operations" items={items} />
        </>
    )
}

export default AuthorOperationsCard