import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
import Home from './full_pages/Home.jsx'
import Navbar from './Components/Navbar.jsx'
import Footer from './Components/Footer.jsx'
import 'bootstrap/dist/css/bootstrap.min.css'
import Login from './full_pages/Login.jsx'
import Register from './full_pages/Register.jsx'
import SearchBookOP from './full_pages/OperationsPages/SearchBookOP.jsx'
import BorrowedBooksOP from './full_pages/OperationsPages/BorrowedBooksOP.jsx'
import SendMessageOP from './full_pages/OperationsPages/SendMessageOP.jsx'
import ViewInboxOP from './full_pages/OperationsPages/ViewInboxOP.jsx'
import BorrowRequestsOP from './full_pages/OperationsPages/BorrowRequestsOP.jsx'
import MemberRegistirationsOP from './full_pages/OperationsPages/MemberRegistirationsOP.jsx'
import PunishSomeoneOP from './full_pages/OperationsPages/PunishSomeoneOP.jsx'
import ChangeRoleOP from './full_pages/OperationsPages/ChangeRoleOP.jsx'
import BookCreateReqOP from './full_pages/OperationsPages/BookCreateReqOP.jsx'
import BookReadingPage from './full_pages/BookReadingPage.jsx'
import { UserProvider } from './AccountOperations/UserContext.jsx'
import ProtectedRoute from './AccountOperations/ProtectedRoute.jsx'
import PublicRoute from './AccountOperations/PublicRoute.jsx'
import MyBooks from './full_pages/MyBooks.jsx'
import WritePage from './full_pages/WritePage.jsx'

import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css"

function App() {
  return (
    <BrowserRouter>
      <div>
        <ToastContainer
          position="top-right"
          autoClose={2000}
          hideProgressBar={false}
          newestOnTop={false}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
          theme="light"
          transition:Bounce />
        <UserProvider>
          <div className="d-flex flex-column min-vh-100">
            <header>
              <Navbar />
            </header>
            <main className="flex-fill d-flex bg-custom-primary">
              <Routes>
                <Route exact path="/" element={<Home />}></Route>
                <Route exact path="/Login" element={
                  <PublicRoute ><Login /></PublicRoute>
                }></Route>
                <Route exact path="/Register" element={
                  <PublicRoute ><Register /></PublicRoute>
                }></Route>
                <Route exact path='/MyBooks' element={
                  <ProtectedRoute roles={["author"]}>
                    <MyBooks />
                  </ProtectedRoute>
                }></Route>
                <Route exact path='/WriteBook' element={
                  <ProtectedRoute roles={["author"]}>
                    <WritePage />
                  </ProtectedRoute>
                }></Route>
                <Route exact path="/SearchBook" element={
                  <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                    <SearchBookOP />
                  </ProtectedRoute>}>
                </Route>
                <Route exact path="/BorrowedBooks" element={
                  <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                    <BorrowedBooksOP />
                  </ProtectedRoute>}>
                </Route>
                <Route exact path="/SendMessage" element={
                  <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                    <SendMessageOP />
                  </ProtectedRoute>}>
                </Route>
                <Route exact path="/ViewInbox" element={
                  <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                    <ViewInboxOP />
                  </ProtectedRoute>}>
                </Route>
                <Route exact path="/ReadBook" element={
                  <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                    < BookReadingPage />
                  </ProtectedRoute>}>
                </Route>

                <Route exact path="/BorrowRequests" element={
                  <ProtectedRoute roles={["staff", "manager"]}>
                    < BorrowRequestsOP />
                  </ProtectedRoute>}>
                </Route>
                <Route exact path="/MemberRegistirations" element={
                  <ProtectedRoute roles={["staff", "manager"]}>
                    < MemberRegistirationsOP />
                  </ProtectedRoute>}>
                </Route>
                <Route exact path="/PunishSomeone" element={
                  <ProtectedRoute roles={["staff", "manager"]}>
                    < PunishSomeoneOP />
                  </ProtectedRoute>}>
                </Route>

                <Route exact path="/ChangeRole" element={
                  <ProtectedRoute roles={["manager"]}>
                    < ChangeRoleOP />
                  </ProtectedRoute>}>
                </Route>
                <Route exact path="/BookCreateRequests" element={
                  <ProtectedRoute roles={["manager"]}>
                    < BookCreateReqOP />
                  </ProtectedRoute>}>
                </Route>
              </Routes>
            </main>
            <footer className="mt-auto">
              <Footer />
            </footer>
          </div>
        </UserProvider>
      </div>
    </BrowserRouter >
  )
}

export default App
