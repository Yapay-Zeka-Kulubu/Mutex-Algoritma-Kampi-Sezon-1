import { Link } from 'react-router-dom'

function Footer() {
    return (
        <>
            <div className="flex flex-row justify-center px-4 p-2 bg-primary-dark">
                <div className="flex flex-col items-center text-center">
                    <p className="text-sm italic text-text-light my-0">Made for Erciyes University's artifical intelligence club's mutex algorithm bootcamp in 2024</p>
                </div>
            </div>
        </>
    )
}

export default Footer;