import 'bootstrap/dist/css/bootstrap.min.css'
import { Link } from 'react-router-dom'
import { useUser } from '../AccountOperations/UserContext.jsx';

function Navbar() {
    const { user, logout } = useUser();

    const handleLogoutClick = function () {
        logout();
    }

    let topRightLinks = "";

    if (!user) {
        topRightLinks = (
            <>
                <li>
                    <Link className="nav-link active" aria-current="page" to="/Login">Login</Link>
                </li>
                <li>
                    <Link className="nav-link active" aria-current="page" to="/Register">Register</Link>
                </li>
            </>);
    } else {
        topRightLinks = (
            <>
                <li>
                    <Link className='nav-link active disabled' aria-current="page">{user.roleName + " - " + user.name + " " + user.surname}</Link>
                </li>
                <li>
                    <Link className='nav-link active' aria-current="page" to="/" onClick={handleLogoutClick}>Logout</Link>
                </li>
            </>
        )
    }

    return (
        <nav className="navbar navbar-expand-lg  navbar-dark bg-custom-secondary">
            <div className="container-fluid">
                <Link className="navbar-brand" to="/">Navbar</Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse " id="navbarNav">
                    <ul className="navbar-nav w-100 d-flex flex-row justify-content-between">
                        <li className=''>
                            <ul className='d-flex list-inline'>
                                <li className="">
                                    <Link className="nav-link active" aria-current="page" to="/">Home</Link>
                                </li>
                                <li className="">
                                    {
                                        (user?.roleName === "author") && (<Link className="nav-link active" aria-current="page" to="/MyBooks">My books</Link>)
                                    }
                                </li>
                            </ul>
                        </li>
                        <li>
                            <ul className='list-inline nav-item d-flex flex-row justify-content-evenly'>
                                {topRightLinks}
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}

export default Navbar;