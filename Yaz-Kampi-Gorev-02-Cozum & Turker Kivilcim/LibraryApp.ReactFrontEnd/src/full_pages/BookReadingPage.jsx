import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { useUser } from "../AccountOperations/UserContext";
import { useFetch } from "../Context/FetchContext";
import SuccessButton from "../Components/SuccessButton";

function BookReadingPage() {

    const [book, setBook] = useState({});
    const location = useLocation();
    const bookId = new URLSearchParams(location.search).get("bookId");
    const [pageNum, setPageNum] = useState();
    const [pageContent, setPageContent] = useState("");
    const [newPageContent, setNewPageContent] = useState("");
    const [selectedPageId, setSelectedPageId] = useState();
    const { user } = useUser();
    const { fetchData } = useFetch();
    const [isEditing, setIsEditing] = useState(false);

    const fetchBook = async function () {
        await fetchData("/api/Book/GetBook?bookId=" + bookId, "GET")
            .then((book) => {
                book.pages.sort((a, b) => a.pageNumber - b.pageNumber);

                const isMemberOrAuthor = ["member", "author"].includes(user.roleName);
                const isBorrowedByUser = book.borrowedById == user.id;
                const isWrittenByUser = book.authorIds?.includes(user.id);

                book.pages = !isMemberOrAuthor || isBorrowedByUser || isWrittenByUser ? book.pages : book.pages.slice(0, 3);
                book.title = !isMemberOrAuthor || isBorrowedByUser || isWrittenByUser ? book.title : book.title + " [Preview]";
                setBook(book);
                setPageContent(book.pages[0].content);
                setPageNum(book.pages[0].pageNumber);
                setSelectedPageId(book.pages[0].pageId);
            });
    }

    useEffect(() => {
        fetchBook();
    }, []);

    const handlePageClick = function (p) {
        setPageContent(p.content);
        setPageNum(p.pageNumber);
        setSelectedPageId(p.pageId);
        console.log(p.pageId);
        setIsEditing(isEditing ? !isEditing : false);
    }

    const handleEditPageClick = async function () {
        if (isEditing && newPageContent !== pageContent) {
            const pageDTO = {
                bookId: bookId,
                pageId: selectedPageId,
                content: newPageContent,
            };
            fetchData("/api/Book/EditPage", "PUT", pageDTO)
                .then(() => {
                    setPageContent(newPageContent);
                    const page = book?.pages?.find(p => p.pageId == selectedPageId);
                    page.content = newPageContent;
                });
        }
        setIsEditing(!isEditing);
        setNewPageContent(pageContent);
    }

    return (
        <div className=" lg:px-16 xl:px-16 flex flex-col grow items-center space-y-4 text-text">
            <h2 className="mb-0 mt-4 p-0 text-3xl">{book.title}</h2>
            <div className="container space-x-2 mb-5 mt-4 p-2 bg-primary-light rounded flex text-center grow">
                <div className="w-5/6 flex flex-col">
                    <div className="flex justify-end text-xl bg-secondary-light border-b border-text px-3 pt-3 pb-1 rounded mb-2">
                        <h5 className="mx-auto">Page {pageNum}</h5>

                        {(user?.roleName === "author" && !book.isPublished && book.pages?.length > 0) && (<SuccessButton callback={handleEditPageClick} text={isEditing ? "Save" : "Edit page"} />)}
                    </div>
                    <div className="p-3 bg-secondary-light rounded grow flex">
                        {(isEditing) ? (<textarea className="grow bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded p-4" style={{ resize: "none" }} defaultValue={newPageContent} onChange={e => setNewPageContent(e.target.value)}></textarea>) : (<p className="text-start">{pageContent}</p>)}
                    </div>
                </div>
                <div className="w-1/6">
                    <div className="flex justify-center bg-secondary-light border-b border-text px-3 pt-3 pb-2 rounded mb-2">
                        <h4>Pages</h4>
                    </div>
                    <div className="flex items-center justify-center p-3 flex-wrap bg-secondary-light rounded gap-2">
                        {book?.pages?.map((p, index) => (
                            <SuccessButton key={index} callback={() => handlePageClick(p)} text={p.pageNumber}/>
                        ))}
                    </div>
                </div>
            </div>
        </div >
    );
}

export default BookReadingPage;