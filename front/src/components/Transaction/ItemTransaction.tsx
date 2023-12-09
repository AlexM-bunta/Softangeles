import "./Transaction.css"

const ItemTransaction = ({receiver, sum, date, description, isAccepted}) => {
    return (
        <div className={"transaction_container"}>
            <div className={"transaction_header_section"}>
                <div>{receiver}</div>
                <div>{sum}</div>
            </div>
            <div className="transaction_date">{date}</div>
            <div>{"description"}</div>
            <div>{"isAccepted"}</div>
        </div>
    )
}

export default ItemTransaction;