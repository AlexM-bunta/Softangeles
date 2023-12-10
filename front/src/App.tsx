import {Route, Routes} from "react-router-dom";

import Authentication from "./pages/Authentification/Authentication.tsx";
import Deposits from "./pages/Deposits/Deposits.tsx";
import Home from "./pages/Home/Home.tsx";
import Loans from "./pages/Loans/Loans.tsx";
import Profile from "./pages/Profile/Profile.tsx";


import './App.css'
import "primereact/resources/themes/lara-light-green/theme.css";
import 'primeicons/primeicons.css';
import {GreenPoints} from "./pages/GreenPoints/GreenPoints.tsx";
import {Investments} from "./pages/Investments/Investments.tsx";


function App() {

    return (
        <div>
            <Routes>
                <Route path="/" element={<Authentication/>}/>
                <Route path="/deposits" element={<Deposits/>}/>
                <Route path="/ecoPoints" element={<></>}/>
                <Route path="/loans" element={<Loans/>}/>
                <Route path="/home" element={<Home/>}/>
                <Route path="/green-points" element={<GreenPoints/>}/>
                <Route path="/profile" element={<Profile/>}/>
                <Route path="/investments" element={<Investments/>}/>
                {/*<Route path="*" element={<Page404/>}/>*/}

            </Routes>
        </div>
    )
}

export default App
