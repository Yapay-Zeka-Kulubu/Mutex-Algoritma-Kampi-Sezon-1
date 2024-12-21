import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './components/Login';
import Register from './components/Register';
import FirstPage from './components/FirstPage';
import MyBooks from './components/MyBooks';
import BookList from './components/BookList';
import BorrowedBooksList from './components/BorrowedBooksList';
import BorrowRequests from './components/BorrowRequests';
import MessagePage from './components/MessagePage';
import WritePage from './components/WritePage';
import HomePage from './components/HomePage';
import BookCreate from './components/bookCreation';
import ChangeRole from './components/changeRolePage';
import BookRead from './components/BookRead';
import Punishment from './components/Punishment';
import MessageBox from './components/MessageBox';
import RegisterRequests from './components/RegisterRequests';

import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';



function App() {
  return (
    <Router>
      <ToastContainer
        position="top-right"
        autoClose={1000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="light"
        transition:Bounce />
      <Routes>
        <Route path="/" element={<FirstPage />} />
        <Route path="/Punishment" element={<Punishment />} />
        <Route path="/ChangeRole" element={<ChangeRole />} />
        <Route path="/BookCreation" element={<BookCreate />} />
        <Route path="/ReadBook" element={<BookRead />} />
        <Route path="/MyBooks" element={<MyBooks />} />
        <Route path="/BookList" element={<BookList />} />
        <Route path="/BorrowedBooksList" element={<BorrowedBooksList />} />
        <Route path="/BorrowRequests" element={<BorrowRequests />} />
        <Route path="/Login" element={<Login />} />
        <Route path="/MessagePage" element={<MessagePage />} />
        <Route path="/Register" element={<Register />} />
        <Route path="/WritePage" element={<WritePage />} />
        <Route path="/HomePage" element={<HomePage />} />
        <Route path="/MessageBox" element={<MessageBox />} />
        <Route path="/RegisterRequests" element={<RegisterRequests />} />
      </Routes>
    </Router>
  );
}

export default App;