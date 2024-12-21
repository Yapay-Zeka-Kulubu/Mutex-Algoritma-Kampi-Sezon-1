import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { toast } from "react-toastify";
import { useFetch } from "../Context/FetchContext";
import SuccessButton from "../Components/SuccessButton";

function WriteBook() {
    const location = useLocation();
    const bookId = new URLSearchParams(location.search).get("bookId");
    const [book, setBook] = useState({});
    const [pageContent, setPageContent] = useState("");
    const [pageNum, setPageNum] = useState(0);
    const { fetchData } = useFetch();

    const fetchBook = async function () {
        const data = await fetchData("/api/Book/GetBook?bookId=" + bookId, "GET");

        data?.pages?.sort((a, b) => a.pageNumber - b.pageNumber);
        setBook(data ?? []);
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

        fetchData("/api/Book/WritePage", "POST", pageDTO)
            .then(() => {
                setPageContent("");
                setPageNum(0);
                fetchBook();
            });
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
        <div className="flex flex-col w-screen lg:container lg:mx-auto lg:px-16 xl:px-16 grow items-center text-text">
            <h3 className="mb-2 mt-4 p-0 text-3xl">{book?.title}</h3>
            <div className="mb-5 p-2 bg-primary-light rounded flex text-center grow flex-col-reverse lg:flex-row w-full">
                <div className="grow flex flex-col lg:w-5/6">
                    <div className="flex justify-center items-center bg-secondary-light border-b border-text pt-3 pb-2 rounded mb-2">
                        <div className="flex items-center">
                            <h5 className="text-xl">Page</h5><input type="number" className="ms-4 px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" min={0} placeholder="Enter the page number" value={pageNum} onChange={e => setPageNum(e.target.value)} />
                        </div>
                    </div>
                    <div className="rounded flex mb-2 grow ">
                        <textarea className="ring-1 ring-text-light border-text px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" placeholder="Enter the content of page" maxLength={1250} style={{ resize: "none" }} onChange={e => setPageContent(e.target.value)} value={pageContent}></textarea>
                    </div>
                    <div className="flex justify-center flex-col items-end lg:flex-row lg:justify-end">
                        <label className="lg:self-center lg:me-2 hover:cursor-pointer" htmlFor="fileUpload">Import text from .txt file:</label>
                        <input className="p-1 bg-secondary-light rounded hover:ring-2 hover:cursor-pointer transition-all duration-100 active:bg-primary-light lg:self-center lg:me-2" id="fileUpload" type="file" onChange={e => handleFileSelection(e)} accept=".txt" />
                        <div className="mt-2 lg:mt-0">
                            <SuccessButton callback={handleSaveClick} text={"Save"} />
                        </div>
                    </div>
                </div>

                <div className="lg:ps-2 mb-2 lg:mb-0 lg:w-1/6">
                    <div className="flex justify-center lg:justify-start text-xl bg-secondary-light border-b border-text px-3 pt-4 pb-4 rounded lg:mb-2">
                        <h5 className="">Current pages</h5>
                    </div>
                    <div className="flex justify-center flex-wrap p-3 bg-secondary-light rounded gap-2">
                        {book?.pages?.map((p, index) => (
                            <p key={index} className="bg-primary-light rounded px-2 py-0">{p.pageNumber}</p>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    )
}

export default WriteBook