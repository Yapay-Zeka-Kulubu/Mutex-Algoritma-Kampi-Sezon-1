function GeneralOperationsPage(props) {
    return (
        <div className="flex grow">
            <div className="hidden lg:block xl:block lg:w-1/6 xl:w-1/6">
                {props.leftPanel}
            </div>
            <div className="flex grow">
                {props.rightPanel}
            </div>
        </div>
    )
}

export default GeneralOperationsPage