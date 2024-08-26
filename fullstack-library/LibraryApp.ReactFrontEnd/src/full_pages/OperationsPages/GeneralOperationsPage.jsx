import HomeGeneralOperationsCard from "../../Components/OperationsCards/HomeGeneralOperationsCard"


function GeneralOperationsPage(props) {
    return (
        //TODO burası component drilling oluyor sanırım bunu ilerde düzeltebilirim.
        <div className="d-flex flex-fill flex-row justify-content-between">
            <div className="w-25 text-break">
                {props.leftPanel}
            </div>
            <div className="d-flex flex-fill m-5 rounded">
                {props.rightPanel}
            </div>
        </div>
    )
}

export default GeneralOperationsPage