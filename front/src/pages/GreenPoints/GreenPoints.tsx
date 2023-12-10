import "./GreenPoints.css"
import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";
import {Button} from "primereact/button";
import {useRef} from "react";
import {OverlayPanel} from "primereact/overlaypanel";
import {randBrand} from "@ngneat/falso";


export const GreenPoints = ({points}: { points?: number }) => {

    const WAT = useRef<OverlayPanel>(null);
    const HTG = useRef<OverlayPanel>(null);
    const ER = useRef<OverlayPanel>(null);

    const listOfCompanies: string[] = [randBrand(), randBrand(), randBrand(), randBrand()]


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

            <div className={"greenPoints_container"}>
                <Button onClick={(e) => WAT.current?.toggle(e)}>What are them ?</Button>
                <Button onClick={(e) => HTG.current?.toggle(e)}>How to get ?</Button>
                <Button onClick={(e) => ER.current?.toggle(e)}>Exchange rate</Button>
            </div>

            <h3 style={{textAlign: "center", marginTop: "2rem"}}>Visit sustainable businesses</h3>
            <div className={"greenPoints_stores"}>

                {listOfCompanies.map(company => <div key={company} style={{
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "center",
                    alignItems: "center",
                    width: "290px",
                    flexWrap: "wrap"
                }}>
                    <h4>{company}</h4> <Button>Visit website</Button></div>)}
            </div>
        </>
    )
}