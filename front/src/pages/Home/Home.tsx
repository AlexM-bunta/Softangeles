import {useState} from "react";

import ReactCreditCards from "react-credit-cards-2";

import {Carousel} from "primereact/carousel";

import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";

import cardItem from "../../types/generalTypes.ts";

import 'react-credit-cards-2/dist/es/styles-compiled.css';
import "./Home.css"
import {FaChartPie} from "react-icons/fa";
import {Dialog} from "primereact/dialog";
import Transaction from "../../components/Transaction/Transaction.tsx";
import AddCard from "../../components/AddCard/AddCard.tsx";
import AddTransaction from "../../components/AddTransaction/AddTransaction.tsx";


const Home = () => {

    const [visibleBalance, setVisibleBalance] = useState(false)
    const [displayedCartDetails, setDisplayedCardDetails] = useState(false)

    const [visibleHistoryTransaction, setVisibleHistoryTransaction] = useState(false);
    const [visibleAddCard, setVisibleAddCard] = useState(false)
    const [visibleAddTransaction, setVisibleAddTransaction] = useState(false);

    const cards: cardItem[] = [{
        cvc: "123",
        expiry: "05/29",
        name: "John Doe",
        number: "4130 1234 1234 1234",
        balance: "4000 RON"
    }, {cvc: "178", expiry: "03/27", name: "Amalie T", number: "5678 4134 7874 9035", balance: "1400 EUR"}]

    const listOfTransactions = [
        {
            bankAccountSource:
                {
                    type: "credit",
                    iban: "ro123456",
                    userFirstName: "Martin",
                    userLastName: "Albert"
                },
            bankAccountDestination:
                {
                    type: "debit",
                    iban: "ro98765",
                    userFirstName: "John",
                    userLastName: "Doe"
                },
            sum: 5000,
            currency: "RON",
            discountPercentage: "10"
        },
        {
            bankAccountSource:
                {
                    type: "credit",
                    iban: "ro123456",
                    userFirstName: "Martin",
                    userLastName: "Albert"
                },
            bankAccountDestination:
                {
                    type: "debit",
                    iban: "ro98765",
                    userFirstName: "John",
                    userLastName: "Doe"
                },
            sum: 5000,
            currency: "RON",
            discountPercentage: "10"
        },
        {
            bankAccountSource:
                {
                    type: "credit",
                    iban: "ro123456",
                    userFirstName: "Martin",
                    userLastName: "Albert"
                },
            bankAccountDestination:
                {
                    type: "debit",
                    iban: "ro98765",
                    userFirstName: "John",
                    userLastName: "Doe"
                },
            sum: 5000,
            currency: "RON",
            discountPercentage: "10"
        },
        {
            bankAccountSource:
                {
                    type: "credit",
                    iban: "ro123456",
                    userFirstName: "Martin",
                    userLastName: "Albert"
                },
            bankAccountDestination:
                {
                    type: "debit",
                    iban: "ro98765",
                    userFirstName: "John",
                    userLastName: "Doe"
                },
            sum: 5000,
            currency: "RON",
            discountPercentage: "10"
        },
    ]


    const cardTemplate = (card: cardItem) => <div className={"home_card_template"}><ReactCreditCards cvc={card.cvc}
                                                                                                     expiry={displayedCartDetails ? card.expiry : "**/**"}
                                                                                                     name={card.name}
                                                                                                     number={displayedCartDetails ? card.number : card.number.slice(0, 4) + "**** **** ****"}/>
        <span onClick={() => setVisibleBalance(!visibleBalance)}
              style={{cursor: "pointer"}}>  {visibleBalance ? <p>{card.balance || "NaN"}</p> : <p><i
            className={"pi pi-eye"}></i> Display balance </p>} </span>

    </div>

    return <>
        <NavigationBar/>
        <h2 style={{textAlign: "center"}}>Your cards</h2>
        <Carousel style={{marginTop: "2rem"}} value={cards} numVisible={1} numScroll={1}
                  verticalViewPortHeight={"360px"}
                  itemTemplate={cardTemplate}/>
        <div className={"homepage_options"}>
            <div className={"homepage_options_row"}>

                <div style={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}
                     onClick={() => setVisibleAddCard(true)}>
                    <i style={{fontSize: "1.5rem"}}
                       className="pi pi-credit-card"></i> <span>Add Card</span>

                </div>
                <div style={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}
                     onClick={() => setVisibleHistoryTransaction(true)}>
                    <i style={{fontSize: "1.5rem"}}
                       className="pi pi-backward"></i> <span>History Transactions</span>
                </div>
                <div style={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}
                     onClick={() => setVisibleAddTransaction(true)}>
                    <i style={{fontSize: "1.5rem"}}
                       className="pi pi-plus"></i>New Transaction
                </div>
            </div>
            <div className={"homepage_options_row"}>
                <div style={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}
                     onClick={() => setDisplayedCardDetails(!displayedCartDetails)}>
                    <i style={{fontSize: "1.5rem"}}
                       className="pi pi-eye"></i>
                    <span>{displayedCartDetails ? "Hide Card Details" : "Display Card Details"}</span>
                </div>
                <div style={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
                    <FaChartPie style={{fontSize: "1.5rem"}}/>Expenses
                </div>
            </div>
        </div>

        <Dialog header="History of Transactions" visible={visibleHistoryTransaction} style={{minWidth: "40rem"}}
                onHide={() => setVisibleHistoryTransaction(false)}>
            <div>
                {listOfTransactions.map(transaction => <div style={{maxHeight: "800px", overflowY: "auto"}}>
                    <Transaction
                        sum={transaction.sum + transaction.currency}
                        receiver={transaction.bankAccountDestination.userFirstName + " " + transaction.bankAccountDestination.userLastName}
                        sender={transaction.bankAccountSource.userFirstName + " " + transaction.bankAccountSource.userLastName}/>
                </div>)}
            </div>
        </Dialog>
        <Dialog header="Add Card" visible={visibleAddCard} onHide={() => setVisibleAddCard(false)}
                style={{minWidth: "40rem"}}>
            <AddCard/>
        </Dialog>
        <Dialog header="Make Transaction" visible={visibleAddTransaction} style={{minWidth: "40rem"}}
                onHide={() => setVisibleAddTransaction(false)}>
            <AddTransaction/>

        </Dialog>

    </>
}

export default Home