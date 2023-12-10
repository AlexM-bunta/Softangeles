import "./GreenPoints.css"
import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";
import {Button} from "primereact/button";
import {useRef} from "react";
import {OverlayPanel} from "primereact/overlaypanel";
import {Image} from "primereact/image";
import {randCompanyName, randNumber, randProductName} from "@ngneat/falso";


const Ticket = ({product, by, points, discount}: { product: string, by: string, points: number, discount: number }) => {

    const disabled = points > (JSON.parse(localStorage.getItem("activeUser") || "")).ecoPoints;

    return <div
        style={{
            width: "17rem",
            borderRadius: "4%",
            boxShadow: "rgba(100, 100, 111, 0.2) 0px 7px 29px 0px",
            height: "22rem",
            marginBottom: "3rem",
            marginTop: "3rem",
            paddingLeft: '1rem',
            paddingRight: "1rem"
        }}>
        <h3>{product}</h3>
        <div>By: + {by}</div>
        <div>
            <p>Price: {points}</p>
            <Button disabled={disabled}>  {disabled ? "Not enough points" : "Buy Ticket"}</Button>
        </div>
        <p>Value: {discount} % off </p>
    </div>
}

export const GreenPoints = () => {

    const WAT = useRef<OverlayPanel>(null);
    const HTG = useRef<OverlayPanel>(null);
    const ER = useRef<OverlayPanel>(null);

    const listOfCompanies = [
        {
            company: 'Patagonia',
            src: "data:image/png;base64,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",
            url: "https://www.patagonia.com"
        }, {
            company: 'Vestas Wind Systems',
            src: "https://images.crunchbase.com/image/upload/c_lpad,h_256,w_256,f_auto,q_auto:eco,dpr_1/v1397191217/0c081d054ccb7bfe9fecd50dffba8e2a.png",
            url: "https://www.vestas.com/en"
        }, {
            company: 'Autodesk',
            src: "https://proptechzone.com/wp-content/uploads/2019/10/AutoDesk-0eb62486-d40d-4f3c-8068-aab229be34d8-1.png",
            url: "https://www.autodesk.com"
        },
        {
            company: 'Evoqua Water Technologies',
            src: "https://s33007.pcdn.co/wp-content/uploads/2020/03/Evoqua.jpg",
            url: "https://www.evoqua.com"
        }]


    const listOfTickets = [{product: 'Vest', by: 'Patagonia', points: 300, discount: 20}, {
        product: randProductName(),
        by: randCompanyName(),
        points: randNumber({min: 100, max: 430}),
        discount: randNumber({min: 1, max: 20})
    },
        {
            product: randProductName(),
            by: randCompanyName(),
            points: randNumber({min: 100, max: 430}),
            discount: randNumber({min: 1, max: 20})
        },
        {
            product: randProductName(),
            by: randCompanyName(),
            points: randNumber({min: 100, max: 430}),
            discount: randNumber({min: 1, max: 20})
        },
        {
            product: randProductName(),
            by: randCompanyName(),
            points: randNumber({min: 100, max: 430}),
            discount: randNumber({min: 1, max: 20})
        },
        {
            product: randProductName(),
            by: randCompanyName(),
            points: randNumber({min: 100, max: 430}),
            discount: randNumber({min: 1, max: 20})
        },
        {
            product: randProductName(),
            by: randCompanyName(),
            points: randNumber({min: 100, max: 430}),
            discount: randNumber({min: 1, max: 20})
        },
        {
            product: randProductName(),
            by: randCompanyName(),
            points: randNumber({min: 100, max: 430}),
            discount: randNumber({min: 1, max: 20})
        }]

    const points: string | null = (JSON.parse(localStorage.getItem("activeUser") || "")).ecoPoints

    console.log(points)

    return (
        <>
            <NavigationBar/>
            <h3 style={{textAlign: "center"}}>Your Green Point: {points || 0} </h3>

            <OverlayPanel ref={WAT}>
                <p>Green Points are a loyalty program that rewards you for using our services.</p>
            </OverlayPanel>

            <OverlayPanel ref={HTG}>
                <p>You can earn Points for
                    things like making card transactions<br/>
                    to eco-friendly companies and referring friend</p>
            </OverlayPanel>

            <OverlayPanel ref={ER}>
                <ul style={{listStyleType: "none"}}>
                    <li>1 RON = 1 Point</li>
                    <li>1 EURO = 5 Points</li>
                    <li>1 GBP = 6 Points</li>
                </ul>
            </OverlayPanel>

            <h3 style={{textAlign: "center"}}>Your Tickets </h3>
            <div style={{textAlign: "center", marginBottom: "2.6rem"}}> You don't have any tickets</div>

            <div className={"greenPoints_container"}>
                <Button onClick={(e) => WAT.current?.toggle(e)}>What are them ?</Button>
                <Button onClick={(e) => HTG.current?.toggle(e)}>How to get ?</Button>
                <Button onClick={(e) => ER.current?.toggle(e)}>Exchange rate</Button>
            </div>

            <h3 style={{textAlign: "center", marginTop: "2rem"}}>Visit sustainable businesses</h3>
            <div className={"greenPoints_stores"}>

                {listOfCompanies.map(item => <div key={item.company} style={{
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "center",
                    alignItems: "center",
                    width: "240px",
                    flexWrap: "wrap",
                    paddingTop: "1.9rem",
                    paddingBottom: "1.9rem",
                    boxShadow: "rgba(100, 100, 111, 0.2) 0px 7px 29px 0px",
                    borderRadius: '4%',
                    marginBottom: '1.2rem'
                }}>
                    <h4 style={{paddingBottom: '1rem'}}>{item.company}</h4>
                    <Image
                        src={item.src}
                        width="220" height="170" style={{marginBottom: "1.4rem"}}/>
                    <a href={item.url} target={"_blank"}><Button>Visit website</Button> </a></div>)}
            </div>
            <h3 style={{textAlign: "center", marginTop: "2rem"}}>Check available tickets</h3>
            <div style={{display: "flex", flexWrap: "wrap", gap: "1.1rem", justifyContent: "center"}}>
                {listOfTickets.map((item) => <Ticket {...item}/>)}
            </div>
        </>
    )
}