import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";


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

        if(password !== confirmPassword)
        {
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
                headers: { "Content-Type": "application/json",Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}` },
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
        <div className="text-black flex-fill d-flex justify-content-center align-items-center my-5">
            <div className="w-25 bg-custom-fourth p-3 rounded">
                <form action="">
                    <div className="mb-3 d-flex justify-content-between">
                        <div className="me-1">
                            <label className="form-label" htmlFor="name">Name </label>
                            <input id="name" className="form-control d-inline" type="text" onChange={(e) => setName(e.target.value)} />
                        </div>
                        <div className="ms-1">
                            <label className="form-label" htmlFor="surname">Surname</label>
                            <input id="surname" className="form-control d-inline" type="text" onChange={(e) => setSurname(e.target.value)} />
                        </div>
                    </div>
                    <div className="mb-3">
                        <label className="form-label" htmlFor="username">Username</label>
                        <input id="username" className="form-control" type="text" onChange={(e) => setUsername(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="form-label" htmlFor="password">Password</label>
                        <input id="password" className="form-control" type="password" onChange={(e) => setPassword(e.target.value)} />
                    </div>

                    <div className="mb-3">
                        <label className="form-label" htmlFor="confirmPassword">Confirm password</label>
                        <input id="confirmPassword" className="form-control" type="password" onChange={(e) => setConfirmPassword(e.target.value)} />
                    </div>

                    <div className="mb-3 d-flex justify-content-between">
                        <div className="me-1">
                            <label className="form-label" htmlFor="birthDate">Birth date</label>
                            <input id="birthDate" className="form-control" type="date" onChange={(e) => setBirthDate(e.target.value)} />
                        </div>
                        <div className="ms-1">
                            <label className="form-label" htmlFor="gender">Gender</label>
                            <select id="gender" className="form-select" aria-label="Gender selection" onChange={(e) => setGender(e.target.value)} >
                                <option value="">Select</option>
                                <option value="M">Male</option>
                                <option value="F">Female</option>
                            </select>
                        </div>
                    </div>
                    <button type="submit" className="text-white btn bg-custom-secondary" onClick={handleRegisterClick}>Register</button>
                </form>
            </div>
        </div>)
}

export default Register