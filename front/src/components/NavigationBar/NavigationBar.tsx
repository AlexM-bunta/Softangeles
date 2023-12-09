import {useState} from "react";
import {useNavigate} from "react-router-dom";

import {MenuItem} from "primereact/menuitem";

import {Sidebar} from "primereact/sidebar";
import {Button} from "primereact/button";

import "./NavigationBar.css"


export const NavigationBar = () => {

    const items: MenuItem[] = [{label: 'Home', icon: 'pi pi-fw pi-home', url: "/home"},
        {label: 'Loans', icon: 'pi pi-fw pi-calendar', url: "/loans"},
        {label: 'Deposits', icon: 'pi pi-fw pi-pencil', url: "/deposits"},
        {label: 'Profile', icon: 'pi pi-user', url: "/profile"},
    ]

    const navigate = useNavigate();

    const [visible, setVisible] = useState(false);

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
                        onClick={() => navigate(item.url)}><i
                        className={item.icon}></i>{item.label}
                    </li>)}
                </ul>
            </Sidebar>
        </div>
    )
}