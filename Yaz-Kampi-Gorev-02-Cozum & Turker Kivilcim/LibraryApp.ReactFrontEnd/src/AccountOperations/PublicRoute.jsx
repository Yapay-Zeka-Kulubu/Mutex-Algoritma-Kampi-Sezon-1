import React from 'react'
import { Navigate } from "react-router-dom";
import { useUser } from "./UserContext"

const PublicRoute = ({ children }) => {
    const { user } = useUser();

    if (!user)
        return children;
    else
        return <Navigate to="/" />
}

export default PublicRoute