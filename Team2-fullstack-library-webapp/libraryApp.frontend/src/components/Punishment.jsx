import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

const PunishmentPage = () => {
    const [users, setUsers] = useState([]);
    const [cezaUsers, setCezaUsers] = useState([]);
    const [selectedUserId, setSelectedUserId] = useState('');
    const [selectedUser, setSelectedUser] = useState('');
    const [punishmentType, setPunishmentType] = useState('');
    const [punishmentDescription, setPunishmentDescription] = useState('');
    const [punishmentDays, setPunishmentDays] = useState('');
    const nav = useNavigate();
    const [user, setUser] = useState({});
    const handleLogoutClick = () => {
        localStorage.removeItem("userData");
        nav("/");
    };
    const handleHomePageClick = () => {
        nav("/HomePage");
    };

    useEffect(() => {
        const user = JSON.parse(localStorage.getItem("userData"));
        if (user === null) {
            nav("/login");
        }
        else if (user.rolIsmi !== "gorevli" && user.rolIsmi !== "yonetici") {
            nav("/HomePage");
        }
        else {
            setUser(user);
        }


        const fetchCezaUsers = async () => {
            const response = await fetch("http://localhost:5075/api/User/cezaVerilebilecekUserlariGetir/" + user.rolId, {
                method: "GET",
            });
            if (response.ok) {
                const dummyUsers = await response.json();
                setCezaUsers(dummyUsers);
            }
        };
        fetchCezaUsers();

    }, []);

    useEffect(() => {
        console.log(selectedUserId);
        const foundUser = cezaUsers.find(cu => cu.userId == selectedUserId);
        setSelectedUser(foundUser);
        console.log(foundUser)

    }, [selectedUserId]);
    //selecteduserıd değişince bu useeffect içibndeki fonksiyon calışır 

          const ApplyPunishment = async () => {
                    console.log(selectedUser);
                    const response = await fetch("http://localhost:5075/api/User/cezaVer", {
                              method: "POST",
                              headers: {
                                        "Content-Type": "application/json",
                              },
                              body: JSON.stringify({
                                userId: selectedUserId,
                                cezaVerenId: user.id,
                                mesajBaslik: punishmentType,
                                mesajIcerik: punishmentDescription
                            }),
                    });
                    if (response.ok) {
                              toast.success("Ceza verildi", {
                                        onClose: () => nav(0)
                              });
                    } else {
                              toast.error("Ceza verilemedi");
                    }


          };

          const RemovePunishment = async () => {
                    const response = await fetch("http://localhost:5075/api/User/cezaKaldir", {
                              method: "PUT",
                              headers: {
                                        "Content-Type": "application/json",
                              },
                              body: JSON.stringify(selectedUserId),
                    });
                    if (response.ok) {
                              toast.success("Ceza kaldırıldı", {
                                        onClose: () => nav(0)
                              });
                    } else {
                              toast.error("Ceza verilemedi");
                    }
          };

    return (

        <div className=" flex flex-col h-screen bg-white">
            <div className="flex justify-between items-center bg-violet-500 text-white p-4 rounded-md shadow-lg mb-6 ">
                <h1 className="text-3xl font-bold">Punishment Page</h1>
                <div className="flex">
                    <button onClick={handleHomePageClick} className="hover:text-gray-300 p-2 ">Home Page</button>
                    <button onClick={handleLogoutClick} className="hover:text-gray-300 p-2">Logout</button>
                </div>
            </div>


            <div className="fixed inset-0 flex items-center justify-center bg-blue-50 bg-opacity-50">

                <div className="bg-white p-6 rounded shadow-md w-1/3">

                    <h2 className="text-xl mb-4">Set Punishment</h2>

                    <label className="block mb-2">Select User</label>
                    <select
                        value={selectedUserId}
                        onChange={(e) => setSelectedUserId(e.target.value)}
                        className="w-full p-2 bg-blue-50 border rounded mb-4"
                    >
                        <option value="">Select user</option>
                        {cezaUsers.map(user => (
                            <option key={user.userId} value={user.userId}>{user.isım + " " + user.soyisim + " - " + user.rolIsmi}</option>
                        ))}
                    </select>

                    <label className="block mb-2">Punishment Title</label>
                    <input
                        type="text"
                        className="w-full p-2 bg-blue-50 border rounded mb-4"
                        value={punishmentType}
                        onChange={(e) => setPunishmentType(e.target.value)}
                    />

                    <label className="block mb-2">Punishment Description</label>
                    <textarea
                        className="w-full p-2 bg-blue-50 border rounded mb-4"
                        value={punishmentDescription}
                        onChange={(e) => setPunishmentDescription(e.target.value)}
                        placeholder="Describe the punishment..."
                    ></textarea>

                    <div className="flex justify-between">
                        {(selectedUser?.cezaliMi) && (<button
                            className="bg-yellow-600 hover:bg-yellow-700 text-white py-2 px-4 rounded"
                            onClick={RemovePunishment}
                        >
                            Remove Punishment
                        </button>)}
                        {(!selectedUser?.cezaliMi) && (<button
                            className="bg-green-600 hover:bg-green-700 text-white py-2 px-4 rounded"
                            onClick={ApplyPunishment}
                        >
                            Apply Punishment
                        </button>)}
                    </div>
                </div>
            </div>

        </div >
    );
};

export default PunishmentPage;
