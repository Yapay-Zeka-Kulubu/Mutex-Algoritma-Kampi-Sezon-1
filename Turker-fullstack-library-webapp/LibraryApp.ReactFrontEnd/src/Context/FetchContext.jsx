
import { createContext, useContext } from 'react'
import { toast } from 'react-toastify';
import { useUser } from '../AccountOperations/UserContext';

const FetchContext = createContext();

export const FetchProvider = ({ children }) => {

    const { logout } = useUser();

    const fetchData = async (endpoint, method, dto) => {
        try {
            let response;
            const authorization = `Bearer ${JSON.parse(localStorage.getItem("token"))}`
            if (method === "GET") {
                response = await fetch("http://localhost:5109" + endpoint, {
                    method: method,
                    headers: {
                        Authorization: authorization,
                    }
                });
            } else {
                response = await fetch("http://localhost:5109" + endpoint, {
                    method: method,
                    headers: {
                        "Content-Type": "application/json",
                        Authorization: authorization,
                    },
                    body: JSON.stringify(dto),
                });
            }


            if (!response.ok) {

                if(response.status === 401)
                    logout();

                    let data = {};
                try {
                    data = await response.json();
                } catch (e) {
                    console.log(e);
                } finally {
                    toast.error(data?.message || "An error occured.");
                }
                return;
            }

            const data = await response.json();
            if (data.message) toast.success(data.message);
            console.log(data);

            return data;
        } catch (error) {
            toast.error(error || "Something bad happened.")
            console.log(error || "Something bad happened.");
        }
    };

    return (<FetchContext.Provider value={{ fetchData }}>
        {children}
    </FetchContext.Provider>);
};

export const useFetch = () => useContext(FetchContext);
