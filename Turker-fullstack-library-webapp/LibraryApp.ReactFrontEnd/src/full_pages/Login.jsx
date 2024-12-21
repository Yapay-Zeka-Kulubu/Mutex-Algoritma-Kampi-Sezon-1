import { Link, useNavigate } from 'react-router-dom'
import { useState, useEffect } from 'react'
import { useUser } from '../AccountOperations/UserContext'
import { toast } from "react-toastify";
import SuccessButton from '../Components/SuccessButton';

function Login() {

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const { user, login } = useUser();
    const navigate = useNavigate();

    useEffect(() => {
        if (user) navigate("/");
    }, [user, navigate])

    const handleLoginClick = async function (e) {
        e.preventDefault();

        if (!username || !password) {
            toast.error("Please fill all the fields");
            return;
        }

        const loginDTO = {
            username: username,
            password: password
        }

        if (username)
            try {
                const response = await fetch("http://localhost:5109/api/Account/Login", {
                    method: "POST",
                    headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
                    body: JSON.stringify(loginDTO)
                });
                if (!response.ok) {
                    const data = await response.json();
                    toast.error(data.message || 'An error occurred. Please try again.');
                    return;
                }

                const data = await response.json();
                localStorage.setItem("token", JSON.stringify(data.token));

                login(data.userDTO);
                navigate("/");
            } catch (error) {
                console.log("There was an error in the process", error);
            }
    };

    return (
        <div className="grow flex justify-center items-center p-10 my-5">
            <div className="p-3 border rounded">
                <form className='flex flex-col'>
                    <div className="mb-3">
                        <label className="text-text block font-medium mb-1" htmlFor="username">Username</label>
                        <input id="username" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="text" onChange={e => setUsername(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="text-text block font-medium mb-1" htmlFor="password">Password</label>
                        <input id="password" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="password" onChange={e => setPassword(e.target.value)} />
                    </div>
                    <div className="mb-3 px-1">
                        <p className="text-xs inline me-1 text-text">Are you not signed up yet?</p><Link className="text-xs border-b border-transparent hover:border-b-accent text-accent font-medium" to="/Register">Create an account</Link>
                    </div>
                    <div className='self-end'>
                        <SuccessButton callback={handleLoginClick} text={"Login"} />
                    </div>
                </form>
            </div>
        </div>
    )
}

export default Login