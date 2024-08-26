import 'bootstrap/dist/css/bootstrap.min.css'
import { Link } from 'react-router-dom'

function Footer() {
    return (
        <>
            <div className="d-flex flex-row justify-content-center p-2 bg-custom-third">
                <div className="d-flex flex-column align-items-center">
                    <p className="fs-8 fst-italic my-0 text-white text-opacity-75">Made by black group for Erciyes University's artifical intelligence club's mutex algorithm bootcamp in 2024</p>
                    <footer className="fs-8 fst-italic text-white text-opacity-50 my-0">Black group members: Turker [LinkedIn], Feyza [LinkedIn], Fatih [LinkedIn], Necati [LinkedIn]</footer>
                </div>
            </div>
        </>
    )
}

export default Footer;