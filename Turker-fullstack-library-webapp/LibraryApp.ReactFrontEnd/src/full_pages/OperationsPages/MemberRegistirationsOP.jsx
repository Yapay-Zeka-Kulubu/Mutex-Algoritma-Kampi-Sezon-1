import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useFetch } from "../../Context/FetchContext";
import DefaultTableTemplate from "../../Components/DefaultTableTemplate";
import { useUser } from "../../AccountOperations/UserContext";
import SuccessButton from "../../Components/SuccessButton";
import DangerButton from "../../Components/DangerButton";

function MemberRegistirationsOP() {
    const [pendingUsers, setPendingUsers] = useState([]);
    const { fetchData } = useFetch();
    const { user } = useUser();

    const fetchRegistirations = async function () {
        const data = await fetchData("/api/User/MemberRegistirations", "GET");
        setPendingUsers(data ?? []);
    }

    useEffect(() => {
        fetchRegistirations();
    }, []);

    const handleApproveRejectClick = async (userId, isApproved) => {
        const regisDTO = {
            userId: userId,
            isApproved: isApproved,
            staffId: user.id,
        }

        fetchData("/api/User/SetRegistirationRequest", "PUT", regisDTO)
            .then(() => {
                fetchRegistirations();
            });
    }

    const headersArray = ["Full name", "Username", "Gender", "Birthdate", "Actions"];
    const datasArray = pendingUsers.map((pu, index) => [
        pu.name + " " + pu.surname,
        pu.username,
        pu.gender,
        new Date(pu.birthDate).toLocaleDateString("en-us"),
        (<ul key={index} className="flex justify-start">
            <li className="me-2">
                <SuccessButton callback={() => { handleApproveRejectClick(pu.id, true) }} text={"Approve"} />
            </li>
            <li className="me-2">
                <DangerButton callback={() => { handleApproveRejectClick(pu.id, false) }} text={"Reject"} />
            </li>
        </ul>),
    ]);

    const rightPanel = (
        <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
    )
    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default MemberRegistirationsOP