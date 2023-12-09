import {Route, Routes} from "react-router-dom";

import Authentication from "./pages/Authentification/Authentication.tsx";
import Deposits from "./pages/Deposits/Deposits.tsx";
import Home from "./pages/Home/Home.tsx";
import Loans from "./pages/Loans/Loans.tsx";

import './App.css'
import "primereact/resources/themes/lara-light-green/theme.css";
import 'primeicons/primeicons.css';


function App() {

    return (
        <div>
            <Routes>
                <Route path="/" element={<Authentication/>}/>
                <Route path="/deposits" element={<Deposits/>}/>
                <Route path="/ecoPoints" element={<></>}/>
                <Route path="/loans" element={<Loans/>}/>
                <Route path="/home" element={<Home/>}/>
                {/*<Route path="*" element={<Page404/>}/>*/}

            </Routes>
        </div>
    )
}

export default App
