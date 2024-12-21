


function DefaultTableTemplate(props) {

    return (<div className="grow w-screen lg:w-full overflow-x-auto bg-primary">
        <table className="w-full text-sm text-left rtl:text-right text-text/50">
            <thead className="text-xs uppercase bg-primary-light text-text/50">
                <tr>
                    {props.headersArray.map((hc, index) => (
                        <th key={index} className="px-6 py-4">{hc}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {props.datasArray.map((da, index) => (
                    <tr key={index} className="border-b bg-primary border-primary-light/50">
                        {da.map((d, index) => (
                            <td key={index} className={`px-6 py-4 ${index == 0 ? "text-text font-medium whitespace-nowrap" : ""}`}>{d}</td>
                        ))}
                    </tr>
                ))}
            </tbody>
        </table >
    </div>)
}

export default DefaultTableTemplate;