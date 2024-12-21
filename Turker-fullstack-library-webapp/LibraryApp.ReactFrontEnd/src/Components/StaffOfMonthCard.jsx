import HomeGeneralOperationsCard from "./OperationsCards/HomeGeneralOperationsCard"
import { useFetch } from "../Context/FetchContext";
import { useEffect, useState } from "react";

function StaffOfMonthCard() {
    const { fetchData } = useFetch();
    const [staffOfMonthDTO, setStaffOfMonthDTO] = useState({});

    const fetchStaffOfMonth = async () => {
        fetchData("/api/User/GetStaffOfMonth", "GET")
            .then(data => {
                setStaffOfMonthDTO(data ?? {});
            });
        console.log(staffOfMonthDTO);
    }

    useEffect(() => {
        fetchStaffOfMonth();
    }, []);

    const items = (
        <>
            <li className="flex space-x-5 justify-center items-center">
                <div>
                    <h6 className="text-2xl text-text border-b pb-1">Staff of previous month</h6>
                    <ul>
                        <li className="text-text text-xl mt-2">
                            {staffOfMonthDTO?.staffOfPrevMonth?.name + " " + staffOfMonthDTO?.staffOfPrevMonth?.surname}
                        </li>
                        <li className="text-text-light text-md">
                            {"Birthdate: " + new Date(staffOfMonthDTO?.staffOfPrevMonth?.birthDate).toLocaleDateString("en-us")}
                        </li>
                        <li className="text-text-light text-md">
                            {"Gender: " + (staffOfMonthDTO?.staffOfPrevMonth?.gender === "M" ? "Male" : "Female")}
                        </li>
                    </ul>
                </div>
                <div>
                    {(staffOfMonthDTO?.currentTop3Staff?.length === 3) && (
                        <>
                            <h6 className="text-md border-b pb-1 pt-10 mb-2 text-text-light">Current Month's Top 3</h6>
                            <ul className="flex flex-col">
                                <li className="text-sm text-text-light">1-) {staffOfMonthDTO?.currentTop3Staff[0]?.name + " " + staffOfMonthDTO?.currentTop3Staff[0]?.surname + " - " + staffOfMonthDTO?.currentTop3Staff[0]?.monthlyScore}</li>
                                <li className="text-sm text-text-light">2-) {staffOfMonthDTO?.currentTop3Staff[1]?.name + " " + staffOfMonthDTO?.currentTop3Staff[1]?.surname + " - " + staffOfMonthDTO?.currentTop3Staff[1]?.monthlyScore}</li>
                                <li className="text-sm text-text-light">3-) {staffOfMonthDTO?.currentTop3Staff[2]?.name + " " + staffOfMonthDTO?.currentTop3Staff[2]?.surname + " - " + staffOfMonthDTO?.currentTop3Staff[2]?.monthlyScore}</li>
                            </ul>
                        </>)}
                </div>
            </li>
        </>

    );

    return <HomeGeneralOperationsCard title="Hall Of Fame" items={items} />
}

export default StaffOfMonthCard