import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";
import {CardLoan} from "../../components/CardLoan/CardLoan.tsx";

import "./Loans.css"
import {Dialog} from "primereact/dialog";
import {useState} from "react";

const Loans = () => {

    const [visibleLoan, setVisibleLoan] = useState(false)
    const [visibleGreenLoan, setVisibleGreenLoan] = useState(false)

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
        </Dialog>
    </>
}

export default Loans