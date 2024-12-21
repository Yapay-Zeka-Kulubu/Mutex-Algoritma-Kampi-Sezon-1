import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";
import GeneralOperationsCard from "../../Components/OperationsCards/GeneralOperationsCard";
import { toast } from "react-toastify";
import { useFetch } from "../../Context/FetchContext";
import DangerButton from "../../Components/DangerButton";
import SuccessButton from "../../Components/SuccessButton";

function PunishSomeoneOP() {
    const [lowerRoleUsers, setLowerRoleUsers] = useState([]);
    const { user } = useUser();
    const [selectedUser, setSelectedUser] = useState();
    const [details, setDetails] = useState("");
    const [totalFine, setTotalFine] = useState(0);
    const { fetchData } = useFetch();

    const fetchLowerRoleUsers = async function () {
        const data = await fetchData(`/api/User/GetUsersOfLowerRole?roleId=${user.roleId}&userId=${user.id}`, "GET");
        setLowerRoleUsers(data ?? []);
    }

    useEffect(() => {
        fetchLowerRoleUsers();
    }, []);

    const handleSelectionChange = function (e) {
        setTotalFine(0);
        const us = lowerRoleUsers.find(lru => lru.id == e.target.value);
        setSelectedUser(us);
        setTotalFine(us.fineAmount);
    }

    const handleInputChange = function (e, callback) {
        callback(prev => prev = e.target.value);
    }

    const handleUpdateClick = async function (e) {
        e.preventDefault();

        if (!selectedUser) {
            toast.error("Please select someone");
            return;
        }

        if (selectedUser.fineAmount === totalFine) {
            toast.error("Nothing changed");
            return;
        }

        const punishUserDTO = {
            userId: selectedUser.id,
            punisherId: user.id,
            isPunished: totalFine > 0,
            fineAmount: totalFine,
            details: details,
        }

        fetchData("/api/User/SetPunishment", "PUT", punishUserDTO)
            .then(() => {
                setTotalFine(0);
                setLowerRoleUsers([]);
                setDetails("");
                setSelectedUser();
                fetchLowerRoleUsers();
            });
    }

    const rightPanel = (
        <div className="grow flex flex-col justify-start px-12 py-4">
            <div className="mb-3 p-3 border rounded">
                <label htmlFor="sendingTo" className="block text-text font-medium mb-1">Select user to view punishment status</label>
                <select id="sendingTo" className="px-4 py-2  bg-primary-light text-text block w-full hover:ring-accent/50 focus:ring-accent focus:ring-2  focus:outline-none hover:ring-2 rounded" onChange={e => handleSelectionChange(e)}>
                    <option value="">Select someone</option>
                    {lowerRoleUsers.map((lru, index) => (
                        <option key={index} value={lru.id}>{lru.name + " - " + lru.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="grow border rounded p-3 flex">
                <div className="flex flex-col grow">
                    <h5 className="border-b pb-1 text-text font-bold">Punishment of {selectedUser?.name}</h5>
                    <form className="flex flex-col grow">
                        <div className="flex flex-col lg:flex-row items-center justify-center lg:justify-between mb-3 lg:grow">
                            <div className="flex mb-3">
                                <div className="my-3 mt-12 mb-2 grow flex">
                                    <label htmlFor="isPunished" className="text-text font-medium mb-1 me-5">Is user punished?</label>
                                    <input type="checkbox" id="isPunished" name="isPunished" className="mt-1 w-4 h-4  focus:ring-accent focus:ring-2" checked={selectedUser?.isPunished ?? false} readOnly />
                                </div>
                            </div>
                            <div className="self-center text-center lg:text-end lg:grow lg:ms-6">
                                <label htmlFor="fineAmount" className="text-text mb-1 font-bold">User's current Fine</label>
                                <input id="fineAmount" className="px-4 py-2 w-full bg-primary-light rounded focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100" type="number" value={totalFine} onChange={e => setTotalFine(e.target.value)} min={0} step={0.1} />
                            </div>
                        </div>
                        <div className="mb-3 grow flex flex-col">
                            <label htmlFor="message" className="block text-text font-medium mb-1">Cause & details of punishment</label>
                            <textarea value={details} type="text" className="grow px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded me-2" style={{ resize: "none" }} onChange={e => handleInputChange(e, setDetails)}></textarea>
                        </div>
                        <div className="self-end inline-block">
                            {(selectedUser?.isPunished) ? (<SuccessButton callback={(e) => { handleUpdateClick(e) }} text={"Update"} />) : (<DangerButton callback={(e) => { handleUpdateClick(e) }} text={"Punish"} />)}
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
    return (<GeneralOperationsPage leftPanel={(<GeneralOperationsCard />)} rightPanel={rightPanel} />)
}

export default PunishSomeoneOP