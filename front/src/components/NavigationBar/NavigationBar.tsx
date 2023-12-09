import {TabMenu} from "primereact/tabmenu";
import {MenuItem} from "primereact/menuitem";

import "./NavigationBar.css"

export const NavigationBar = () => {

    const items: MenuItem[] = [{label: 'Home', icon: 'pi pi-fw pi-home', url: "/home"},
        {label: 'Loans', icon: 'pi pi-fw pi-calendar', url: "/loans"},
        {label: 'Deposits', icon: 'pi pi-fw pi-pencil', url: "/deposits"},
        {label: 'Profile', icon: 'pi pi-user', url: "/profile"},
    ]

    return (<div className={"navigation_bar"} style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            borderBottom: "2px solid #e2dfdf"
        }}>
            <div className={"navigation_bar_logo"}>Logo</div>
            <TabMenu model={items}></TabMenu>
        </div>
    )
}