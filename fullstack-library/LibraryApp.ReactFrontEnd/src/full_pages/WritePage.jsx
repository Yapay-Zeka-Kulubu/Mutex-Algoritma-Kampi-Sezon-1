import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { toast } from "react-toastify";

function WriteBook() {
    const location = useLocation();
    const bookId = new URLSearchParams(location.search).get("bookId");
    const [book, setBook] = useState({});
    const [pageContent, setPageContent] = useState("");
    const [pageNum, setPageNum] = useState(0);

    const fetchBook = async function () {
        const res = await fetch("http://localhost:5109/api/Book/GetBook?bookId=" + bookId, {
            method: "GET",
            headers: { Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` }

        });

        if (!res.ok) return;
        const data = await res.json();
        data.pages.sort((a, b) => a.pageNumber - b.pageNumber);
        setBook(data);
    };

    useEffect(() => {
        fetchBook();
    }, []);

    const handleSaveClick = async function () {
        if (!pageContent || !pageNum) {
            toast.error("Please fill all the fields.");
            return;
        }

        if (book.pages.find(p => p.pageNumber == pageNum)) {
            toast.error("There is a page with that number");
            return;
        }

        const pageDTO = {
            bookId: bookId,
            content: pageContent,
            pageNumber: pageNum,
        };

        const res = await fetch("http://localhost:5109/api/Book/WritePage", {
            method: "POST",
            headers: { "Content-Type": "application/json",Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
            body: JSON.stringify(pageDTO),
        });

        if (!res.ok) {
            const data = await res.json();
            toast.error(data?.message ?? "An error occured");
            return;
        }
        toast.success("Page saved");
        setPageContent("");
        setPageNum(0);
        await fetchBook();
    };

    const handleFileSelection = function (e) {
        const file = e.target.files[0];
        console.log(file);

        if (file) {
            const reader = new FileReader();
            reader.readAsText(file);
            reader.onload = () => {
                setPageContent(prev => prev + reader.result);
            }
        }
    }

    return (
        <div className="d-flex flex-column flex-fill align-items-center">
            <h3 className="mb-2 mt-4 p-0">{book?.title}</h3>
            <div className="mb-5 p-2 bg-light rounded d-flex text-center flex-fill container">
                <div className="flex-fill col-9">
                    <div className="d-flex justify-content-center align-items-center bg-success-subtle border-bottom border-dark pt-3 pb-2 rounded mb-2">
                        <div className="d-flex align-items-center">
                            <h5>Page</h5><input type="number" className="ms-4 form-control d-inline" min={0} placeholder="Enter the page number" value={pageNum} onChange={e => setPageNum(e.target.value)} />
                        </div>
                    </div>
                    <div className="bg-success-subtle rounded d-flex mb-2">
                        <textarea className="rounded flex-fill bg-success-subtle px-4 py-3" placeholder="Enter the content of page" rows={9} maxLength={1250} style={{ resize: "none" }} onChange={e => setPageContent(e.target.value)} value={pageContent}></textarea>
                    </div>
                    <div className="d-flex justify-content-end">
                        <label className="align-self-center me-2" htmlFor="fileUpload">Import text from .txt file:</label>
                        <input class="form-control w-50 me-2" id="fileUpload" type="file" onChange={e => handleFileSelection(e)} accept=".txt" />
                        <button className="btn btn-success px-5" onClick={handleSaveClick}>Save</button>
                    </div>
                </div>

                <div className="col-3 ps-2">
                    <div className="d-flex justify-content-center bg-success-subtle border-bottom border-dark px-3 pt-4 pb-1 rounded mb-2">
                        <h5>Current pages</h5>
                    </div>
                    <div className="d-flex justify-content-center flex-wrap p-3 bg-success-subtle rounded">
                        {book?.pages?.map((p, index) => (
                            <p key={index} className="border border-dark rounded px-2 py-0 me-2 mb-2">{p.pageNumber}</p>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    )
}

export default WriteBook