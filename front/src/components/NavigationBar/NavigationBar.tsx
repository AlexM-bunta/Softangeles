import {useState} from "react";
import {useNavigate} from "react-router-dom";

import {MenuItem} from "primereact/menuitem";

import {Sidebar} from "primereact/sidebar";
import {Button} from "primereact/button";

import "./NavigationBar.css"
import Axios from "axios";


export const NavigationBar = () => {

    const items: MenuItem[] = [{label: 'Home', icon: 'pi pi-fw pi-home', url: "/home"},
        {label: 'Loans', icon: 'pi pi-fw pi-calendar', url: "/loans"},
        // {label: 'Deposits', icon: 'pi pi-fw pi-pencil', url: "/deposits"},
        {label: 'Green Points', icon: 'pi pi-money-bill', url: '/green-points'},
        {label: 'Investments', icon: 'pi pi-chart-line', url: '/investments'},
        {label: 'Profile', icon: 'pi pi-user', url: "/profile"},
        {label: 'Logout', icon: 'pi pi-sign-out', url: "/"},
    ]

    const navigate = useNavigate();

    const [visible, setVisible] = useState(false);
    const logout = async () => {
        await Axios.post("http://51.20.81.164/api/Users/Logout", {session: localStorage.getItem("UID")});
        localStorage.clear();
        navigate("/")
    }

    return (<div className={"navigation_bar"} style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            borderBottom: "2px solid #e2dfdf",
            height: "70px",
            paddingRight: "1rem",
        }}>
            <div className={"navigation_bar_logo"}>Logo</div>

            <Button onClick={() => setVisible(true)}> <i className={"pi pi-bars "}></i> </Button>
            <Sidebar visible={visible} onHide={() => setVisible(false)}>
                <h2>Logo</h2>
                <ul style={{listStyleType: "none"}}>
                    {items.map(item => <li
                        key={item.label}
                        style={{cursor: "pointer", width: "fit-content", fontSize: "1.2rem", marginBottom: "1.5rem"}}
                        onClick={() => {
                            item.label != "Logout" ? navigate(item.url || "/") : logout()
                        }}><i
                        className={item.icon}></i>{item.label}
                    </li>)}
                </ul>
            </Sidebar>
        </div>
    )
}