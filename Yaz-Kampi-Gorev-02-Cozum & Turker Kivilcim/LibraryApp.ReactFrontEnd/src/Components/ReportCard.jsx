
function ReportCard({ title, items }) {
    return (
        <div className="bg-transparent border border-text grow mt-4 rounded flex flex-col">
            <h4 className="border-b border-secondary rounded text-center text-2xl py-2 text-text font-medium">{title}</h4>
            <ul className="flex flex-col p-4 self-center grow">
                {(items.length < 1) && (<p className="text-3xl text-center font-bold text-text">N/A</p>)}
                {items?.map((i, index) => (
                    <li className="flex grow" key={index}>
                        <p className={`${i.key !== "" ? "text-2xl" : "text-5xl lg:text-9xl grow self-center"} text-start font-bold text-text`}>{(i.key !== "" ? `${index + 1}- ${i.key.replace(i.key[0], i.key[0].toUpperCase())}: ` : "") + i.value}</p>
                    </li>
                ))}
            </ul>
        </div>)
}

export default ReportCard;

//TODO pdften kitap yükleme