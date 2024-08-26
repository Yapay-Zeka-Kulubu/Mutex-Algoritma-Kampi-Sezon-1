import { Link } from "react-router-dom";
import MemberOperationsCard from "../../Components/OperationsCards/MemberOperationsCard"
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { toast } from "react-toastify";


function MemberRegistirationsOP() {

    //TODO wrap all fetchs with try catch and give user feedback about all actions
    const [pendingUsers, setPendingUsers] = useState([]);

    const fetchRegistirations = async function () {
        const res = await fetch("http://localhost:5109/api/User/MemberRegistirations", {
            method: "GET", headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });
        if (!res.ok) return;

        setPendingUsers(await res.json());
    }

    useEffect(() => {
        fetchRegistirations();
    }, []);

    async function handleClick(user, isApproved) {

        const regisDTO = {
            userId: user.id,
            isApproved: isApproved,
        }

        const res = await fetch("http://localhost:5109/api/User/SetRegistirationRequest", {
            method: "PUT",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(regisDTO),
        });

        if (!res.ok) return;

        const data = await res.json();

        if (isApproved) toast.success("Request approved");
        else toast.error("Request rejected");

        fetchRegistirations();
    }

    const rightPanel = (
        <table className="table table-light table-striped table-hover flex-fill">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Full name</th>
                    <th>Username</th>
                    <th>Gender</th>
                    <th>Birthdate</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {pendingUsers.map((pu, index) => (
                    <tr key={index}>
                        <td>{pu.id}</td>
                        <td>{pu.name + " " + pu.surname}</td>
                        <td>{pu.username}</td>
                        <td>{pu.gender}</td>
                        <td>{new Date(pu.birthDate).toLocaleDateString("en-us")}</td>
                        <td>
                            <ul className="list-inline d-flex justify-content-start">
                                <li className="me-2"><Link onClick={() => { handleClick(pu, true) }} className={`py-1 px-2 btn btn-success`}>Approve</Link></li>
                                <li className="me-2"><Link onClick={() => { handleClick(pu, false) }} className={`py-1 px-2 btn btn-danger`}>Reject</Link></li>
                            </ul>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table >
    )
    return (<GeneralOperationsPage leftPanel={(<MemberOperationsCard />)} rightPanel={rightPanel} />)
}

export default MemberRegistirationsOP