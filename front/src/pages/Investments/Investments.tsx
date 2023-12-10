import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";
import {useEffect, useState} from "react";
import Axios from "axios";
import {Button} from "primereact/button";
import {Image} from "primereact/image";
import {randBrand, randNumber} from "@ngneat/falso";

const urls = ["https://api.polygon.io/v1/open-close/TSLA/2023-01-09?adjusted=true&apiKey=QzxtunT4XD3ZueFNtbKIIvAXM9zOfNbG"]

const requests = urls.map((url) => Axios.get(url));

type Stock = {
    symbol: string;
    open: number | string;
    high: number | string;
    volume: number;
    low: string | number;
}

const stocks: Stock[] = [{
    symbol: randBrand(),
    open: randNumber(),
    high: randNumber(),
    low: randNumber(),
    volume: randNumber()
}, {
    symbol: randBrand(),
    open: randNumber(),
    high: randNumber(),
    low: randNumber(),
    volume: randNumber()
}, {
    symbol: randBrand(),
    open: randNumber(),
    high: randNumber(),
    low: randNumber(),
    volume: randNumber()
}]

const CardStock = (stock: Stock) => <div style={{
    display: "flex",
    flexDirection: "column",
    justifyContent: "center",
    width: "14rem",
    alignItems: "center",
    borderRadius: "4%",
    boxShadow: "rgba(100, 100, 111, 0.2) 0px 7px 29px 0px"
}}>
    <div style={{padding: "1.4rem"}}>
        <h4 style={{marginBottom: "2.3rem"}}>{stock.symbol}</h4>
        <Image src={"https://softwhere.com.co/images/company_logo.png"} width={"120"}/>
        <div>Open: {stock.open}</div>
        <div>Low: {stock.low}</div>
        <div>High: {stock.high}</div>
        <div>Volume: {stock.volume}</div>
        <Button style={{marginTop: "4rem"}}>Buy Stocks</Button>
    </div>
</div>

export const Investments = () => {

    const [teslaStocks, setTeslaStocks] = useState<Stock>();

    useEffect(() => {

        Axios.all(requests).then(responses => responses.forEach(resp => {
            setTeslaStocks(resp.data)
        }))

    }, [])

    return (
        <>
            <NavigationBar/>
            <h2 style={{textAlign: "center"}}> Invest in sustainable business at a reduced commission</h2>

            <h3 style={{textAlign: "center"}}> Best eco-friendly companies</h3>
            <div style={{display: "flex", flexWrap: "wrap", gap: "1.3rem", justifyContent: "space-around"}}>
                <div style={{
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "center",
                    width: "14rem",
                    alignItems: "center",
                    borderRadius: "4%",
                    boxShadow: "rgba(100, 100, 111, 0.2) 0px 7px 29px 0px"
                }}>
                    <div style={{padding: "1.4rem", textAlign: "center"}}>
                        <h4 style={{marginBottom: "2.3rem", textAlign: "center"}}>{teslaStocks?.symbol}</h4>
                        <Image src={"https://upload.wikimedia.org/wikipedia/commons/e/e8/Tesla_logo.png"}
                               width={"120"}/>
                        <div>Open: {teslaStocks?.open}</div>
                        <div>Low: {teslaStocks?.low}</div>
                        <div>High: {teslaStocks?.high}</div>
                        <div>Volume: {teslaStocks?.volume}</div>
                        <Button style={{marginTop: "4rem"}}>Buy Stocks</Button>
                    </div>
                </div>


                {stocks.map(stock => <CardStock {...stock}/>)}
            </div>
        </>
    )
}