import {TabMenu} from "primereact/tabmenu";
import {MenuItem} from "primereact/menuitem";

export const NavigationBar = () => {

    const items: MenuItem[] = [{label: 'Home', icon: 'pi pi-fw pi-home'},
        {label: 'Loans', icon: 'pi pi-fw pi-calendar'},
        {label: 'Deposits', icon: 'pi pi-fw pi-pencil'}]

    return (
        <TabMenu model={items}></TabMenu>
    )
}