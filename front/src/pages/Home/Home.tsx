import {useState} from "react";

import ReactCreditCards from "react-credit-cards-2";

import {Carousel} from "primereact/carousel";

import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";

import cardItem from "../../types/generalTypes.ts";

import 'react-credit-cards-2/dist/es/styles-compiled.css';
import "./Home.css"


const Home = () => {

    const [visibleBalance, setVisibleBalance] = useState(false)
    const [displayedCartDetails, setDisplayedCardDetails] = useState(false)

    const cards: cardItem[] = [{
        cvc: "123",
        expiry: "05/29",
        name: "John Doe",
        number: "4130 1234 1234 1234"
    }, {cvc: "178", expiry: "03/27", name: "Amalie T", number: "5678 4134 7874 9035"}]

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

                <div style={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
                    <i style={{fontSize: "1.5rem"}}
                       className="pi pi-credit-card"></i> <span>Add Card</span>

                </div>
                <div style={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
                    <i style={{fontSize: "1.5rem"}}
                       className="pi pi-backward"></i> <span>History Transactions</span>
                </div>
                <div style={{display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
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
                    <i style={{fontSize: "1.5rem"}}
                       className="pi pi-shield"></i>Expenses
                </div>
            </div>
        </div>
    </>
}

export default Home