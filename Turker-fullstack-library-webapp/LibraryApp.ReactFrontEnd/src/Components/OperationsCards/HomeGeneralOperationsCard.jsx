
function HomeGeneralOperationsCard(props) {

    return (
        <div className="text-center h-full flex flex-col bg-primary-dark p-8 px-4 pb-16">
            <div className="text-text border-b mb-6">
                <h3 className="text-2xl mb-2">{props.title}</h3>
            </div>
            <div className="grow flex flex-col">
                <ul className="grow flex flex-col items-center space-y-2">
                    {props.items}
                </ul>
            </div>
        </div>
    );
}

export default HomeGeneralOperationsCard;