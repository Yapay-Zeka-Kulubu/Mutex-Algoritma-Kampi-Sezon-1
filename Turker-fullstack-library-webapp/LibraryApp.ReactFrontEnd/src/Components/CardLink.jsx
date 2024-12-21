import { Link } from "react-router-dom";


function CardLink(props) {
    return (<Link className="rounded bg-accent border border-transparent inline-block px-6 py-4  hover:bg-accent-dark transition-all duration-100 text-text font-semibold hover:ring-accent hover:ring-2 ease-in-out active:bg-accent-dark/50" to={props.url}>{props.text}</Link>);
}

export default CardLink