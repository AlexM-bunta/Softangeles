import {NavigationBar} from "../../components/NavigationBar/NavigationBar.tsx";
import {Avatar} from "primereact/avatar";

import "./Profile.css"
import {useState} from "react";
import {Dropdown} from "primereact/dropdown";
import {Button} from "primereact/button";
import {Tooltip} from "primereact/tooltip";

const Profile = ({name, ecoPoints}: {
    name?: string
    ecoPoints?: number
}) => {

    const languageOptions = [{
        label: "English", value: 'EN'
    }, {
        label: "Spanish", value: 'ES'
    }, {
        label: "Romanian", value: 'RO'
    }
    ]

    const [language, setLanguage] = useState("EN")

    return (
        <>
            <NavigationBar/>
            <div className="profile_container">
                <div className="profile_card">
                    <Avatar icon="pi pi-user" size="xlarge"></Avatar>
                    <p> Hello, <b>{name || "John Doe!"}</b></p>
                    <Tooltip target=".profile_ecopoints" mouseTrack mouseTrackLeft={10}/>
                    <h4 className={"profile_ecopoints"} data-pr-tooltip="Green Points are gained after each transaction
                    with a eco-friendly company. Check for more details
                    on the dedicated page !">Your Green
                        Points: {ecoPoints || 0} <i
                            className="pi pi-question-circle"></i></h4>

                    <span style={{marginTop: "1rem"}} className="p-float-label">
                    <Dropdown options={languageOptions} inputId="language" value={language}
                              onChange={(e) => setLanguage(e.value)}/>
                    <label htmlFor="language">Select Language</label>
                    </span>
                    <div>
                        <Button style={{marginTop: '1.2rem', marginBottom: '1.2rem'}}>Save changes</Button>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Profile