import {useState} from "react";

import ReactCreditCards from "react-credit-cards-2";

import {Carousel} from "primereact/carousel";

import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";

import cardItem from "../../types/generalTypes.ts";

import 'react-credit-cards-2/dist/es/styles-compiled.css';
import "./Home.css"


const Home = () => {

    const [visibleBalance, setVisibleBalance] = useState(false)

    const cards: cardItem[] = [{
        cvc: "123",
        expiry: "05/29",
        name: "John Doe",
        number: "4130 1234 1234 1234"
    }, {cvc: "178", expiry: "03/27", name: "Amalie T", number: "5678 4134 7874 9035"}]

    const cardTemplate = (card: cardItem) => <div className={"home_card_template"}><ReactCreditCards cvc={card.cvc}
                                                                                                     expiry={card.expiry}
                                                                                                     name={card.name}
                                                                                                     number={card.number}/>
        <span onClick={() => setVisibleBalance(!visibleBalance)}
              style={{cursor: "pointer"}}>  {visibleBalance ? <p>{card.balance || NaN}</p> : <p><i
            className={"pi pi-eye"}></i> Display balance </p>} </span>

    </div>

    return <>
        <NavigationBar/>
        <Carousel style={{marginTop: "2rem"}} value={cards} numVisible={1} numScroll={1}
                  verticalViewPortHeight={"360px"}
                  itemTemplate={cardTemplate}/>
    </>
}

export default Home