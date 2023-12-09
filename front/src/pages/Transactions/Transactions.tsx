import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";

const Transactions = () => {

    const listOfTransactions = [{
        receiver: "John Doe",
        sum: "100 EUR",
        date: "14/08/2023",
        description: "Rent",
        isAccepted: false
    }]

    return <>
        <NavigationBar/>
        <div className={"transactions_container"}>

        </div>

    </>
}

export default Transactions