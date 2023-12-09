import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";
import {CardLoan} from "../../components/CardLoan/CardLoan.tsx";

import "./Loans.css"
import {Dialog} from "primereact/dialog";
import {useState} from "react";
import {InputNumber} from "primereact/inputnumber";
import ReactSignatureCanvas from "react-signature-canvas";
import {Button} from "primereact/button";

const Loans = () => {

    const [visibleLoan, setVisibleLoan] = useState(false)
    const [visibleGreenLoan, setVisibleGreenLoan] = useState(false)

    const [amount, setAmount] = useState<number | null>(null);
    const [duration, setDuration] = useState<number | null>(null);
    const [signature, setSignature] = useState<ReactSignatureCanvas | null>();


    const listOfLoans = [{}]

    return <>
        <NavigationBar/>

        <div className={"loans_container_listOfLoans"}>
            {listOfLoans.length > 1 ? listOfLoans.map((loan) => <p>{JSON.stringify(loan)}</p>) :
                <p style={{textAlign: "center"}}> You don't have any loans!</p>}
        </div>

        <div className={"loans_container_cards"}>
            <CardLoan
                description={"We understand that life is filled with unexpected challenges and opportunities. " +
                    "Whether you're looking to purchase a new home, fund your child's education, " +
                    "start a business, or simply manage unforeseen expenses, our comprehensive " +
                    "loan solutions are designed to empower you on your financial journey."}
                title={"Classic Loan"}
                urlImage={"https://png.pngtree.com/png-vector/20220910/ourmid/pngtree-loan-vector-png-image_6145097.png"}
                onClick={() => setVisibleLoan(true)}
            />
            <CardLoan
                description={"We believe in supporting your commitment to a greener and more sustainable lifestyle. " +
                    "Our Green Loan is designed to empower individuals like you to make environmentally conscious choices by " +
                    "providing affordable financing for eco-friendly products and initiatives."} title={"Green Loan"}
                urlImage={"https://i.pinimg.com/736x/e3/c1/fa/e3c1faf4a6377c38bcc4b7aff4aaba2e.jpg"}
                onClick={() => setVisibleGreenLoan(true)}
            />
        </div>
        <Dialog visible={visibleLoan} header={"Classic Loan"} onHide={() => setVisibleLoan(false)}>
            Classic Loan
        </Dialog>
        <Dialog visible={visibleGreenLoan} header={"Green Loan"} style={{minWidth: "40rem"}}
                onHide={() => setVisibleGreenLoan(false)}>
            <div> Interest rate: <s>14</s> <b style={{color: "green"}}>10%</b></div>
            <div> Max amount:<s>18.000</s> <b style={{color: "green"}}> 30.000 $ </b></div>
            <br/>
            <div> The financial arrangement is an opportunity for individuals or legal entities <br/> who want to
                support sustainable development and sustainable businesses.
            </div>
            <div style={{marginBottom: '2.5rem'}}><b> Terms & conditions </b></div>

            <div className={"loans_green_form"}>
            <span className="p-float-label" style={{marginBottom: '2rem'}}>
                <InputNumber inputId={"Amount"} value={amount} onChange={(e) => setAmount(e.value)}
                             useGrouping={false}/>
            <label htmlFor="Amount">Amount</label>
        </span>
                <span className="p-float-label">
                <InputNumber inputId={"Duration"} value={duration} onChange={(e) => setDuration(e.value)}
                             useGrouping={false}/>
            <label htmlFor="Duration">Duration(months)</label>
            </span>

                <div style={{marginTop: "1.4rem", marginBottom: "1.2rem"}}>
                    Sign Here:
                    <div style={{
                        boxShadow: "rgba(100, 100, 111, 0.2) 0px 7px 29px 0px",
                        width: '250px',
                    }}>
                        <ReactSignatureCanvas canvasProps={{width: "250px"}} ref={data => setSignature(data)}/>
                    </div>
                </div>
                <Button onClick={() => console.log(signature)}>Apply for loan</Button>
            </div>
        </Dialog>
    </>
}

export default Loans