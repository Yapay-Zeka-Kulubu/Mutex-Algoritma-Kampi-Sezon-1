import { Link } from "react-router-dom";
import GeneralOperationsPage from "./GeneralOperationsPage"
import { useEffect, useState } from "react";
import { useUser } from "../../AccountOperations/UserContext";
import GeneralOperationsCard from "../../Components/OperationsCards/GeneralOperationsCard";
import { toast } from "react-toastify";

function PunishSomeoneOP() {
    const [lowerRoleUsers, setLowerRoleUsers] = useState([]);
    const { user } = useUser();
    const [selectedUser, setSelectedUser] = useState();
    const [delayedDays, setDelayedDays] = useState(0);
    const [finePerDay, setFinePerDay] = useState(0);
    const [details, setDetails] = useState("");
    const [totalFine, setTotalFine] = useState(0);

    const fetchLowerRoleUsers = async function () {
        const res = await fetch(`http://localhost:5109/api/User/GetUsersOfLowerRole?roleId=${user.roleId}&userId=${user.id}`, {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });

        if (!res.ok) return;

        setLowerRoleUsers(await res.json());
    }

    useEffect(() => {
        fetchLowerRoleUsers();
    }, []);

    const handleSelectionChange = function (e) {
        setDelayedDays(0);
        setFinePerDay(0);
        setTotalFine(0);
        setSelectedUser(lowerRoleUsers.find(lru => lru.id == e.target.value));
    }

    const handleInputChange = function (e, callback) {
        callback(prev => prev = e.target.value);
    }

    //FIXME for example 4 is the fine at first then i make it 6 directly then i changed delayeddays calculation it is 0.4. it is making total fine 4.4 instead of 6.4
    useEffect(() => {
        setTotalFine((selectedUser?.fineAmount ?? 0) + Math.round(delayedDays * finePerDay * 10) / 10);
    }, [delayedDays, finePerDay, selectedUser])

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

        const res = await fetch(`http://localhost:5109/api/User/SetPunishment`, {
            method: "PUT",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(punishUserDTO),
        });

        const data = await res.json();
        console.log(data);
        if (!res.ok) return;
        toast.success(selectedUser.isPunished ? "Updated." : "User punished");
        setDelayedDays(0);
        setFinePerDay(0);
        setTotalFine(0);
        setLowerRoleUsers([]);
        setDetails("");
        setSelectedUser();
        fetchLowerRoleUsers();
    }

    const rightPanel = (
        <div className="flex-fill">
            <div className="mb-3 border-bottom border-dark p-3 border rounded">
                <label htmlFor="sendingTo" className="form-label">Select user to view punishment status</label>
                <select id="sendingTo" className="form-select" onChange={e => handleSelectionChange(e)}>
                    <option value="">Select someone</option>
                    {lowerRoleUsers.map((lru, index) => (
                        <option key={index} value={lru.id}>{lru.name + " - " + lru.roleName}</option>
                    ))}
                </select>
            </div>
            <div className="row m-0 p-0">
                <div className="col border border-dark rounded p-3 me-2">
                    <h5 className="border-bottom border-dark pb-1">Punishment of {selectedUser?.name}</h5>
                    <form>
                        <div className="d-flex flex-fill">
                            <div className="my-3 mb-2 flex-fill align-self-center">
                                <label htmlFor="isPunished" className="form-label  me-2">Is user already punished?</label>
                                <input type="checkbox" id="isPunished" name="isPunished" className="form-check-input" checked={selectedUser?.isPunished ?? false} onChange={e => selectedUser?.isPunished} />
                            </div>
                        </div>
                        <div className="my-3 row">
                            <div className="align-self-center col text-start pe-0">
                                <label className="form-label" htmlFor="delayedDays">Delayed days</label>
                                <input id="delayedDays" value={delayedDays} className="form-control d-inline" type="number" min={0} step={1} onChange={e => handleInputChange(e, setDelayedDays)} />
                            </div>
                            <div className=" col text-center align-self-center">
                                <label className="form-label" htmlFor="finePerDay">Fine amount per day ($)</label>
                                <input id="finePerDay" className="form-control d-inline" type="number" min={0} step={0.1} value={finePerDay} onChange={e => handleInputChange(e, setFinePerDay)} />
                            </div>
                            <div className="col align-self-center text-end">
                                <label htmlFor="fineAmount" className="form-label"><b>User's final total fine</b></label>
                                <input id="finePerDay" className="form-control" type="number" value={totalFine} onChange={e => setTotalFine(e.target.value)} min={0} step={0.1} />
                            </div>
                        </div>
                        <div className="mb-0">
                            <label htmlFor="message" className="form-label">Cause & details of punishment</label>
                            <div className="d-flex align-items-center">
                                <textarea value={details} type="text" className="form-control me-2" rows={2} style={{ resize: "none" }} onChange={e => handleInputChange(e, setDetails)}></textarea>
                                <button onClick={(e) => { handleUpdateClick(e) }} className="btn btn-danger py-2 px-4">{selectedUser?.isPunished ? "Update" : "Punish"}</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
    return (<GeneralOperationsPage leftPanel={(<GeneralOperationsCard />)} rightPanel={rightPanel} />)
}

export default PunishSomeoneOP