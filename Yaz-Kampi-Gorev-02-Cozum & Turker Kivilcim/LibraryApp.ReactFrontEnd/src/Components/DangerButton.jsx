
function DangerButton({ text, callback }) {
    return (<button onClick={callback} className = "border border-transparent inline-block rounded px-4 py-2 bg-danger hover:bg-danger-dark hover:ring-2 hover:ring-danger transition-all duration-100 text-text font-medium active:bg-danger-dark/60  hover:outline-none active:outline-none focus:outline-none focus:ring-2 focus:ring-danger-dark" > { text }</button >);
}

export default DangerButton;