import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";
import "./Deposits.css"

const Deposits = ({balance}: { balance?: string | number }) => {

    const listOfDeposits = [{sum: 5000, currency: "RON", period: "6"}, {sum: "230", currency: "EUR", period: "12"}]


    return <div className={"deposit_container"}>
        <NavigationBar/>
        <div className={"deposit_container_balance"}>
            <h2>Your balance in deposits:</h2>
            <h3>{balance || "0 RON"}</h3>
        </div>
        <div className={"deposit_container_listOfDeposits"}>
            {/*<div className={"deposit_central_container"}>*/}
            {listOfDeposits.map(deposit => <div className={"deposit_container_item"}>
                <h5 style={{color: "teal"}}> Classic Deposit</h5>
                {deposit.sum}
            </div>)}
            {/*</div>*/}
        </div>
    </div>
}

export default Deposits