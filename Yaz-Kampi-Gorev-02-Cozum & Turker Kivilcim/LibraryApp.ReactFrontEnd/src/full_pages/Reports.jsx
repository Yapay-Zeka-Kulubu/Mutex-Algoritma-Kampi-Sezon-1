import { useState } from "react";
import ReportCard from "../Components/ReportCard";
import { useFetch } from "../Context/FetchContext";
import SuccessButton from "../Components/SuccessButton";

function Reports() {

    const [startDate, setStartDate] = useState("");
    const [endDate, setEndDate] = useState("");
    const [reportDTO, setReportDTO] = useState(null);
    const { fetchData } = useFetch();

    const handleGetReportClick = async () => {
        const data = await fetchData(`/api/Reports/GetReports?startDate=${startDate}&endDate=${endDate}`, "GET");
        setReportDTO(data ?? null);
        console.log(startDate);
        console.log(endDate);
    }

    return (
        <div className="container md:mx-20 mx-10 my-4 flex flex-col">
            <div className="flex flex-col">
                <div className="lg:flex lg:space-x-4 lg:space-y-0 space-y-2 grow">
                    <div className="grow">
                        <label className="text-text block font-medium mb-1" htmlFor="startDate">Start date</label>
                        <input id="startDate" className="px-4 py-2 w-full  bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" onChange={e => setStartDate(e.target.value)} type="date" />
                    </div>
                    <div className="grow">
                        <label className="text-text block font-medium mb-1" htmlFor="endDate">End date</label>
                        <input id="endDate" className="px-4 py-2 w-full  bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="date" onChange={e => setEndDate(e.target.value)} />
                    </div>
                </div>
                <div className="self-end my-4">
                <SuccessButton callback={handleGetReportClick} text={startDate === "" || endDate === "" ? "Get report of all time" : "Get report in that range"} />
                </div>
            </div>
            {(reportDTO !== null) && (<div className="flex flex-col lg:flex-none lg:grid lg:grid-cols-2 lg:gap-x-10 lg:gap-y-5 lg:grid-rows-3">
                <ReportCard title="Books published" items={
                    [{ "key": "", "value": reportDTO?.totalBookCount }]
                } />
                <ReportCard title="Most borrowed books" items={reportDTO?.mostBorrowedBooks} />
                <ReportCard title="Users registered" items={
                    [{ "key": "", "value": reportDTO?.totalUserCount }]
                } />
                <ReportCard title="Users per role" items={reportDTO?.usersPerRole} />
                <ReportCard title="Top borrower users" items={reportDTO?.mostBorrowers} />
                <ReportCard title="Top members/authors that return book in time" items={reportDTO?.mostScoredMembers} />
            </div >
            )}
        </div >
    )
}
export default Reports;
