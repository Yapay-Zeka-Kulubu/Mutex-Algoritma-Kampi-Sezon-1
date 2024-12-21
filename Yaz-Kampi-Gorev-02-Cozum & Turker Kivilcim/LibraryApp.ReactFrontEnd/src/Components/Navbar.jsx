import { Link } from 'react-router-dom'
import { useUser } from '../AccountOperations/UserContext.jsx';
import { useState } from 'react';

function Navbar() {
    const { user, logout } = useUser();
    const [isDropdownSelected, setIsDropdownSelected] = useState(false);

    const handleLogoutClick = function () {
        setIsDropdownSelected(false);
        logout();
    }

    let topRightLinks = "";

    if (!user) {
        topRightLinks = (
            <>
                <div>
                    <Link className=" hover:bg-primary-light/50 rounded p-3 transition-all duration-100" aria-current="page" to="/Login">Login</Link>
                </div>
                <div>
                    <Link className=" hover:bg-primary-light/50 rounded p-3 transition-all duration-100" aria-current="page" to="/Register">Register</Link>
                </div>
            </>);
    } else {
        topRightLinks = (
            <>
                <div className='hidden lg:flex lg:flex-row'>
                    <div className=''>
                        <Link className='cursor-default py-3 lg:p-3 xl:p-3 text-xs lg:text-base xl:text-base text-text-light' aria-current="page">{user.roleName + " - " + user.name + " " + user.surname}</Link>
                    </div>
                    {(user?.roleName === "manager") && (
                        <div className=''>
                            <Link className='py-3 lg:p-3 xl:p-3 text-text-light lg:text-base xl:text-base hover:bg-primary-light/50 transition-all duration-100 rounded' to="/Reports" aria-current="page">Reports</Link>
                            <Link className='text-text-light py-3 lg:p-3 xl:p-3 lg:text-base xl:text-base hover:bg-primary-light/50 transition-all duration-100 rounded' to="/Settings" aria-current="page">Settings</Link>
                        </div>)}
                    <div className=''>
                        <Link className=' hover:bg-primary-light/50 rounded py-3 lg:p-3 xl:p-3 transition-all duration-100' aria-current="page" to="/" onClick={handleLogoutClick}>Logout</Link>
                    </div>
                </div>
                <div className="relative lg:hidden block">
                    <button id="dropdownButton" className="text-text-light px-4 py-2 bg-primary-light rounded-lg hover:bg-primary-light/60 active:bg-primary focus:outline-none focus:ring-2 focus:ring-blue-500" onClick={() => setIsDropdownSelected(!isDropdownSelected)}>
                        Options
                    </button>

                    <ul className={`absolute top-9 right-0 mt-2 w-48 bg-primary-light rounded-lg shadow-lg ${isDropdownSelected ? "" : "hidden"}`}>
                        {(user?.roleName === "manager") && (
                            <>
                                <li className=''>
                                    <Link className='rounded block px-4 py-2 text-text-light hover:bg-primary' to="/Reports" onClick={() => setIsDropdownSelected(false)} aria-current="page">Reports</Link>
                                </li>
                                <li className=''>

                                    <Link className='block px-4 py-2 text-text-light hover:bg-primary rounded' to="/Settings" onClick={() => setIsDropdownSelected(false)} aria-current="page">Settings</Link>
                                </li>
                            </>
                        )}
                        <li className=''>
                            <Link className=' block px-4 py-2 text-text-light hover:bg-primary rounded' aria-current="page" to="/" onClick={handleLogoutClick}>Logout</Link>
                        </li>
                    </ul>
                </div>
            </>
        )
    }

    return (
        <nav className="bg-primary-dark text-text">
            <div className="mx-auto flex items-center justify-between px-4 py-2 lg:py-4 lg:px-10 ">
                <Link className="text-3xl font-bold" to="/">EruLib</Link>
                <ul className="items-center justify-between space-x-14 lg:space-x-0 xl:space-x-0 px-2 lg:px-5 xl:px-5 pt-1 w-full flex flex-row">
                    <li className=''>
                        <ul className='flex items-center'>
                            <li className="">
                                <Link className="text-text-light hover:bg-primary-light/50 rounded p-3 transition-all duration-100" to="/">Home</Link>
                            </li>
                            <li className="">
                                {
                                    (user?.roleName === "author" && !user?.isPunished) && (<Link className="text-text-light hover:bg-primary-light/50 rounded py-3 lg:p-3 xl:p-3 transition-all duration-100 inline-block" to="/MyBooks">My books</Link>)
                                }
                            </li>
                        </ul>
                    </li>
                    <li>
                        <div className='flex items-center flex-row space-x-3 lg:space-x-0 xl:space-x-0'>
                            {topRightLinks}
                        </div>
                    </li>
                </ul>
            </div>
        </nav>
    )
}

export default Navbar;