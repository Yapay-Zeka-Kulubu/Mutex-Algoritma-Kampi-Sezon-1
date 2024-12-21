import { Link } from "react-router-dom";
import { useUser } from "../AccountOperations/UserContext";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useFetch } from "../Context/FetchContext";
import DefaultTableTemplate from "../Components/DefaultTableTemplate";
import SuccessButton from "../Components/SuccessButton";
import DefaultLink from "../Components/DefaultLink";
import * as pdfjs from "pdfjs-dist";
import "pdfjs-dist/build/pdf.worker.min.mjs"


function MyBooksOP() {

    const { user } = useUser();
    const [myBooks, setMyBooks] = useState([]);
    const { fetchData } = useFetch();
    const [importedPages, setImportedPages] = useState([]);

    const fetchBooks = async function () {
        const data = await fetchData("/api/Book/GetBooksByAuthor?userId=" + user.id, "GET");

        var newMyBooks = data?.map(mb => ({
            bookId: mb.bookId,
            oldBookName: mb.bookName,
            newBookName: mb.bookName,
            publishDate: mb.publishDate,
            status: mb.status,
        }));
        setMyBooks(newMyBooks ?? []);
    }

    useEffect(() => {
        fetchBooks();
    }, []);

    const handleRequestClick = async function (bookId) {
        fetchData("/api/Book/RequestPublishment", "POST", bookId)
            .then(() => {
                fetchBooks();
            });
    }

    const handleCreateClick = async function () {
        fetchData("/api/Book/CreateBook", "POST", user.id)
            .then(() => {
                fetchBooks();
            });
    }

    const handleChangeClick = async function (book) {
        if (book.oldBookName === book.newBookName) {
            toast.error("You did not changed the name");
            return;
        }

        const bookDTO = {
            bookId: book.bookId,
            bookName: book.newBookName,
            publishDate: book.publishDate,
            status: book.status,
        }

        fetchData("/api/Book/UpdateBookName", "PUT", bookDTO)
            .then(() => {
                fetchBooks();
            });
    }

    const handleTitleChange = function (book, e) {
        book.newBookName = e.target.value;
    }

    const handleImportPdfClick = (e) => {
        //get selected file from user
        const file = e.target.files[0];
        console.log(file);

        if (file) {
            const reader = new FileReader();
            reader.onload = (event) => {
                //on reader load convert our file name into uint8array to give pdfjs library's getdocument method a valid parameter
                const uint8array = new Uint8Array(event.target.result);
                pdfjs.getDocument(uint8array).promise.then((pdf) => {
                    //for each pdf page get text content and add it to array.
                    const pages = [];
                    for (let i = 1; i <= pdf.numPages; i++) {
                        pdf.getPage(i).then((page) => {
                            page.getTextContent().then((pageText) => {
                                const string = "Page " + i + ": " + pageText.items.map(i => i.str).join(" ");
                                pages.push(string);
                                console.log(string);
                            });
                        });
                    }

                    setImportedPages(pages);
                });
            };

            reader.readAsArrayBuffer(file);
        }
        else {
            setImportedPages([]);
        }
    };

    useEffect(() => {
        //being unsorted, sort pages depending on first page numbers that i added above
        importedPages.sort((a, b) => parseInt(a.match(/Page (\d+):/)[1]) - parseInt(b.match(/Page (\d+):/)[1]));
        console.log(importedPages);
    }, [importedPages]);

    const handleSaveImportedBookClick = () => {
        //first replace page numbers that i added from actual content
        //then filter empty pages
        //then create book to db
        const bookDTO = {
            authorId: user.id,
            pages: importedPages
                .map(ip => ip.replace(/Page (\d+):/, "").trim())
                .filter(ip => ip.length > 0 && ip !== undefined)
                .map((ip, index) => {
                    return {
                        pageNumber: index + 1,
                        content: ip,
                    };
                })
        };
        fetchData("/api/Book/CreateBookWithDetails", "POST", bookDTO)
            .then(() => {
                fetchBooks();
            });
    };

    const headersArray = ["Book name", "Status", "Publish date", "Actions"];
    const datasArray = myBooks.map((mb, index) => [
        mb.oldBookName,
        mb.status,
        new Date(mb.publishDate).toLocaleDateString("en-us"),
        (<div key={index} className="gap-2 flex-wrap flex w-full">
            {(mb.status !== "Published") && <>
                <div className="flex mb-2 w-full">
                    <input type="text" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded-s" placeholder="Enter new name" onChange={(e) => handleTitleChange(mb, e)} />
                    <SuccessButton callback={() => handleChangeClick(mb)} text={"Change"} />
                </div>
                <DefaultLink url={"/WriteBook?bookId=" + mb.bookId} text={"Write"} />
                <SuccessButton callback={e => handleRequestClick(mb.bookId)} text={"Request publishment"} />
            </>}
            <DefaultLink url={"/ReadBook?bookId=" + mb.bookId} text={"Read"} />
        </div>),
    ]);

    return (
        <div className="container lg:px-16 mx-auto grow w-full flex flex-col text-text">
            <div className="flex flex-row justify-between px-1 pt-4 pb-2 border-text items-end">
                <h1 className="text-3xl ms-2">My Books</h1>
                <div className="flex flex-row gap-2 items-center">
                    {(importedPages.length === 0 || importedPages === undefined || importedPages === null) ? (<SuccessButton callback={handleCreateClick} text={"Create another book"} />) : (<SuccessButton callback={handleSaveImportedBookClick} text={"Save imported book"} />)}
                    <p className="">Or import a pdf</p>
                    <input className="p-1 bg-secondary-light rounded hover:ring-2 hover:cursor-pointer transition-all duration-100 active:bg-primary-light lg:self-center lg:me-2" id="fileUpload" type="file" onChange={e => handleImportPdfClick(e)} accept=".pdf" />
                </div>
            </div>
            <DefaultTableTemplate headersArray={headersArray} datasArray={datasArray} />
        </div>
    )
}

export default MyBooksOP;