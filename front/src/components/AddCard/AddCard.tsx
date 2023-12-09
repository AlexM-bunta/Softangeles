import ReactCreditCards from "react-credit-cards-2";
import {useState} from "react";

const AddCard = () => {

    const [expiry, setExpiry] = useState<string | number>("")
    const [name, setName] = useState("");
    const [cvc, setCVC] = useState("");
    const [number, setNumber] = useState("")

    return <>
        <ReactCreditCards cvc={cvc} expiry={expiry} name={name} number={number}/>

    </>
}

export default AddCard