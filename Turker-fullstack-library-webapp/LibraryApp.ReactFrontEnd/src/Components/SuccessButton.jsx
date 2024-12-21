
function SuccessButton({ text, callback }) {
    return (<button onClick={callback} className="border border-transparent inline-block rounded px-4 py-2 bg-success hover:bg-success-dark hover:ring-2 hover:ring-success transition-all duration-100 text-text font-medium focus:outline-none focus:ring-2 focus:ring-success-dark  hover:outline-none active:outline-none active:bg-success-dark/60" > {text}</button >);
}

export default SuccessButton;