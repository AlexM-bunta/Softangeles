import ReactCreditCards from "react-credit-cards-2";
import {AutoComplete} from "primereact/autocomplete";
import {useState} from "react";

import "./AddCard.css"
import {InputNumber} from "primereact/inputnumber";
import {Button} from "primereact/button";

const AddCard = () => {

    const [expiry, setExpiry] = useState<null | number>(null)
    const [name, setName] = useState("");
    const [cvc, setCVC] = useState<number | null>(null);
    const [number, setNumber] = useState<number | null>(null)

    return <div className={"addCard_layout"}>
        <div className={"addCard_card_layout"}>
            <ReactCreditCards cvc={cvc || ""} expiry={expiry || ""} name={name} number={number || ""}/>
        </div>
        <div className={"addCard_inputs"}>
        <span className="p-float-label">
        <AutoComplete inputId={"name"} value={name} onChange={(e) => setName(e.value)}></AutoComplete>
        <label htmlFor="name">Name</label>
        </span>
            <span className="p-float-label">
        <InputNumber inputId={"expiry"} value={expiry} onChange={(e) => setExpiry(e.value)}></InputNumber>
        <label htmlFor="expiryDate">Expiration Date</label>
        </span>
            <span className="p-float-label">
                <InputNumber inputId={"numberCard"} value={number} onChange={(e) => setNumber(e.value)}
                             useGrouping={false}/>
        <label htmlFor="numberCard">Number Card</label>
        </span>
            <span className="p-float-label">
                <InputNumber inputId={"cvc"} value={number} onChange={(e) => setCVC(e.value)}
                             useGrouping={false}/>
        <label htmlFor="cvc">CVC</label>
        </span>

        </div>
        <Button>Add Card</Button>
    </div>
}

export default AddCard