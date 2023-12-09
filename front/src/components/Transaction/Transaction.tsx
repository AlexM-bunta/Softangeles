import "./Transaction.css"
import {MdInput, MdOutput} from "react-icons/md";

const Transaction = ({sender, receiver, sum, date}) => {
    return (
        <div className={"transaction_container"}>
            <div>
                <span style={{display: "flex"}}><MdOutput style={{fontSize: "1.5rem", color: "red"}}/> {sender} </span>
                <span style={{display: "flex"}}><MdInput
                    style={{fontSize: "1.5rem", color: "green"}}/> {receiver} </span>
                <div className="transaction_date">{date}</div>
            </div>
            <div><b>{sum}</b></div>
        </div>
    )
}

export default Transaction;