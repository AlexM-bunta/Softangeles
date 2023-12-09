import {AutoComplete} from "primereact/autocomplete";
import {InputNumber} from "primereact/inputnumber";
import {Dropdown} from "primereact/dropdown";
import {Button} from "primereact/button";
import {useState} from "react";

const AddTransaction = () => {
    const [IBAN, setIBAN] = useState("")
    const [details, setDetails] = useState("")
    const [amount, setAmount] = useState(0)
    const [currency, setCurrency] = useState("")
    const [receiver, setReceiver] = useState("")

    return (
        <div className={"dialogAddTransaction"}>
                <span className="p-float-label">
                <AutoComplete value={IBAN} onChange={(e) => setIBAN(e.value)} inputId={"IBAN"}></AutoComplete>
                <label htmlFor="IBAN">IBAN</label>
                </span>
            <span className="p-float-label">
                <AutoComplete value={details} onChange={(e) => setDetails(e.value)} inputId={"Details"}></AutoComplete>
                <label htmlFor="Details">Details</label>
                </span>
            <span className="p-float-label">
                <InputNumber value={amount} inputId={"Amount"} onChange={(e) => setAmount(e.value)}
                             useGrouping={false}/>
                <label htmlFor="Amount">Amount</label>
                </span>
            <span className="p-float-label">
                < Dropdown value={currency} onChange={(e) => setCurrency(e.value)} inputId="Currency"
                           options={[{label: 'EUR', value: 'EUR'}, {label: 'RON', value: 'RON'}, {
                               label: 'DOL',
                               value: 'DOL'
                           }]}/>
                <label htmlFor="Currency">Select currency</label>
                </span>
            <span className="p-float-label">
                <AutoComplete value={receiver} onChange={(e) => setReceiver(e.value)} inputId={"Receiver"}/>
                <label htmlFor="Receiver">Receiver</label>
                </span>
            <Button> Transfer</Button>
        </div>
    )
}

export default AddTransaction