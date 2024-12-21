import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import SuccessButton from "../Components/SuccessButton";


function Register() {

    const [name, setName] = useState("");
    const [surname, setSurname] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [birthDate, setBirthDate] = useState("");
    const [gender, setGender] = useState("");

    const navigate = useNavigate();

    const handleRegisterClick = async function (e) {
        e.preventDefault();

        if (!name || !surname || !username || !password || !confirmPassword || !birthDate || !gender) {
            toast.error("Please fill all the fields.");
            return;
        }

        if (password !== confirmPassword) {
            toast.error("Both password must be same.");
            return;
        }

        const registerDTO = {
            name: name,
            surname: surname,
            username: username,
            password: password,
            birthDate: birthDate,
            gender: gender,
        }

        try {
            const response = await fetch("http://localhost:5109/api/Account/Register", {
                method: "POST",
                headers: { "Content-Type": "application/json", Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
                body: JSON.stringify(registerDTO),
            });
            if (!response.ok) return;
            const data = await response.json();
            toast.success("Registiration request has sent to staffs.");
            toast.info("Directing to login page.");
            navigate("/Login");
        } catch (error) {
            console.log("there was an error", error);
        }
    };

    return (
        <div className="grow flex justify-center items-center p-10  my-5">
            <div className="border p-3 rounded">
                <form className="flex flex-col">
                    <div className="mb-3 flex justify-between">
                        <div className="me-1">
                            <label className="text-text block font-medium mb-1" htmlFor="name">Name </label>
                            <input id="name" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="text" onChange={(e) => setName(e.target.value)} />
                        </div>
                        <div className="ms-1">
                            <label className="text-text block font-medium mb-1" htmlFor="surname">Surname</label>
                            <input id="surname" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="text" onChange={(e) => setSurname(e.target.value)} />
                        </div>
                    </div>
                    <div className="mb-3">
                        <label className="text-text block font-medium mb-1" htmlFor="username">Username</label>
                        <input id="username" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="text" onChange={(e) => setUsername(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="text-text block font-medium mb-1" htmlFor="password">Password</label>
                        <input id="password" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="password" onChange={(e) => setPassword(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="text-text block font-medium mb-1" htmlFor="confirmPassword">Confirm password</label>
                        <input id="confirmPassword" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="password" onChange={(e) => setConfirmPassword(e.target.value)} />
                    </div>

                    <div className="mb-3 flex justify-between ">
                        <div className="me-1 grow">
                            <label className="text-text block font-medium mb-1" htmlFor="birthDate">Birth date</label>
                            <input id="birthDate" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" type="date" onChange={(e) => setBirthDate(e.target.value)} />
                        </div>
                        <div className="ms-1 grow">
                            <label className="text-text block font-medium mb-1" htmlFor="gender">Gender</label>
                            <select id="gender" className="px-4 py-2 w-full bg-primary-light focus:ring-2 focus:bg-primary-light/90 focus:ring-accent-dark outline-none hover:ring-accent hover:ring-2 text-text transition-all duration-100 rounded" aria-label="Gender selection" onChange={(e) => setGender(e.target.value)} >
                                <option value="">Select</option>
                                <option value="M">Male</option>
                                <option value="F">Female</option>
                            </select>
                        </div>
                    </div>
                    <div className="self-end">
                        <SuccessButton callback={handleRegisterClick} text={"Register"} />
                    </div>
                </form>
            </div>
        </div>)
}

export default Register