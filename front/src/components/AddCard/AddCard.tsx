import ReactCreditCards from "react-credit-cards-2";
import {AutoComplete} from "primereact/autocomplete";
import {useState} from "react";

import "./AddCard.css"
import {InputNumber} from "primereact/inputnumber";
import {Button} from "primereact/button";
import {toast, ToastContainer} from "react-toastify";
import Axios from "axios";

const AddCard = () => {

    const [name, setName] = useState("");
    const [cvc, setCVC] = useState<number | null>(null);
    const [number, setNumber] = useState<number | null>(null)

    const insertCardIntoDB = async () => {

        let isInvalid = false;

        if (name.length <= 4) {
            toast.error('Name must have at least 4 characters!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }

        if (number?.toString().length != 16) {
            toast.error('Card must have 16 digits!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }

        if (cvc?.toString().length != 3) {
            toast.error('CVC must have 3 digits!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }

        if (!isInvalid) {
            console.log("TRUE")

            try {

                await Axios.post("http://51.20.81.164/api/Cards/AddCard", {
                    accountId: 1,
                    isPhysical: false,
                    
                })
                toast.success('Card added with success!', {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: true,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: false,
                    progress: undefined,
                    theme: "colored",
                })

            } catch (e) {
                console.log(e)
                toast.error('Card addition has failed!', {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: true,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: false,
                    progress: undefined,
                    theme: "colored",
                });
            }
        }

    }

    return <div className={"addCard_layout"}>
        <div className={"addCard_card_layout"}>
            <ReactCreditCards cvc={cvc || ""}
                              expiry={new Date().getMonth() + "/" + new Date().getFullYear().toString().slice(-2)}
                              name={name} number={number || ""}/>
        </div>
        <div className={"addCard_inputs"}>
        <span className="p-float-label">
        <AutoComplete inputId={"name"} value={name} onChange={(e) => setName(e.value)}></AutoComplete>
        <label htmlFor="name">Name</label>
        </span>
            <span className="p-float-label">
                <InputNumber inputId={"numberCard"} value={number} onChange={(e) => setNumber(e.value)}
                             useGrouping={false}/>
        <label htmlFor="numberCard">Number Card</label>
        </span>
            <span className="p-float-label">
                <InputNumber inputId={"cvc"} value={cvc} onChange={(e) => setCVC(e.value)}
                             useGrouping={false}/>
        <label htmlFor="cvc">CVC</label>
        </span>

        </div>
        <Button onClick={insertCardIntoDB}>Add Card</Button>
        <ToastContainer/>
    </div>
}

export default AddCard