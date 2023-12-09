import {Route, Routes} from "react-router-dom";

import Authentication from "./pages/Authentification/Authentication.tsx";
import Deposits from "./pages/Deposits/Deposits.tsx";
import Home from "./pages/Home/Home.tsx";
import Page404 from "./pages/Page404/Page404.tsx";
import Loans from "./pages/Loans/Loans.tsx";

import './App.css'
import "primereact/resources/themes/lara-light-green/theme.css";
import 'primeicons/primeicons.css';
import Transactions from "./pages/Transactions/Transactions.tsx";


function App() {

    return (
        <div>
            <Routes>
                <Route path="/" element={<Authentication/>}/>
                <Route path="/deposits" element={<Deposits/>}/>
                <Route path="/transactions" element={<Transactions/>}/>
                <Route path="/loans" element={<Loans/>}/>
                <Route path="/home" element={<Home/>}/>
                <Route path="*" element={<Page404/>}/>

            </Routes>
        </div>
    )
}

export default App
