import { BrowserRouter, Route, Routes } from 'react-router-dom'
import Home from './full_pages/Home.jsx'
import Navbar from './Components/Navbar.jsx'
import Footer from './Components/Footer.jsx'
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

import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css"
import { FetchProvider } from './Context/FetchContext.jsx'

import Settings from './full_pages/Settings.jsx'
import Reports from './full_pages/Reports.jsx'

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
          <FetchProvider>
            <div className="flex flex-col min-h-screen">
              <header className='sticky top-0'>
                <Navbar />
              </header>
              <main className="flex grow bg-background-light">
                <Routes>
                  <Route path="/" element={<Home />}></Route>
                  <Route path="/Login" element={
                    <PublicRoute ><Login /></PublicRoute>
                  }></Route>
                  <Route path="/Register" element={
                    <PublicRoute ><Register /></PublicRoute>
                  }></Route>
                  <Route path='/MyBooks' element={
                    <ProtectedRoute roles={["author"]}>
                      <MyBooks />
                    </ProtectedRoute>
                  }></Route>
                  <Route path='/WriteBook' element={
                    <ProtectedRoute roles={["author"]}>
                      <WritePage />
                    </ProtectedRoute>
                  }></Route>
                  <Route path="/SearchBook" element={
                    <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                      <SearchBookOP />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/BorrowedBooks" element={
                    <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                      <BorrowedBooksOP />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/SendMessage" element={
                    <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                      <SendMessageOP />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/ViewInbox" element={
                    <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                      <ViewInboxOP />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/ReadBook" element={
                    <ProtectedRoute roles={["author", "member", "staff", "manager"]}>
                      < BookReadingPage />
                    </ProtectedRoute>}>
                  </Route>

                  <Route path="/BorrowRequests" element={
                    <ProtectedRoute roles={["staff", "manager"]}>
                      < BorrowRequestsOP />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/MemberRegistirations" element={
                    <ProtectedRoute roles={["staff", "manager"]}>
                      < MemberRegistirationsOP />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/PunishSomeone" element={
                    <ProtectedRoute roles={["staff", "manager"]}>
                      < PunishSomeoneOP />
                    </ProtectedRoute>}>
                  </Route>

                  <Route path="/ChangeRole" element={
                    <ProtectedRoute roles={["manager"]}>
                      < ChangeRoleOP />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/BookCreateRequests" element={
                    <ProtectedRoute roles={["manager"]}>
                      < BookCreateReqOP />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/Settings" element={
                    <ProtectedRoute roles={["manager"]}>
                      <Settings />
                    </ProtectedRoute>}>
                  </Route>
                  <Route path="/Reports" element={
                    <ProtectedRoute roles={["manager"]}>
                      <Reports />
                    </ProtectedRoute>}>
                  </Route>
                </Routes>
              </main>
              <footer className="mt-auto">
                <Footer />
              </footer>
            </div>
          </FetchProvider>
        </UserProvider>
      </div>
    </BrowserRouter >
  )
}

export default App
