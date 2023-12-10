import {useState} from "react";
import {toast, ToastContainer} from "react-toastify";

import {Button} from "primereact/button";
import {AutoComplete} from "primereact/autocomplete";
import {Password} from "primereact/password";

import "./Authentification.css"
import 'react-toastify/dist/ReactToastify.css';
import Axios from "axios";
import {useNavigate} from "react-router-dom";


const Authentication = () => {

    const [registerMode, setRegisterMode] = useState(false)

    const [username, setUsername] = useState("")
    const [firstName, setFirstName] = useState("")
    const [lastName, setLastName] = useState("")
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [confirmPassword, setConfirmPassword] = useState("")

    const navigate = useNavigate();

    const footer = () => {
        return <>
            <ul className="pl-2 ml-2 mt-0 line-height-3">
                <li>At least one lowercase</li>
                <li>At least one uppercase</li>
                <li>At least one numeric</li>
                <li>Minimum 8 characters</li>
            </ul>
        </>
    }

    const login = async () => {

        const isInvalid = false;

        // if (username.length < 6) {
        //     toast.error('Username must have at least 6 characters!', {
        //         position: "top-right",
        //         autoClose: 5000,
        //         hideProgressBar: true,
        //         closeOnClick: true,
        //         pauseOnHover: true,
        //         draggable: false,
        //         progress: undefined,
        //         theme: "colored",
        //     });
        //     isInvalid = true;
        // }
        // if (password.length < 8 && !/^(?=\S+$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,}$/.test(password)) {
        //     toast.error('Invalid password!', {
        //         position: "top-right",
        //         autoClose: 5000,
        //         hideProgressBar: true,
        //         closeOnClick: true,
        //         pauseOnHover: true,
        //         draggable: false,
        //         progress: undefined,
        //         theme: "colored",
        //     });
        //     isInvalid = true;
        // }

        if (!isInvalid) {
            try {
                const response = await Axios.post("http://51.20.81.164/api/Users/Login", {
                    username: username,
                    password: password
                })
                localStorage.setItem("UID", response.data)
                Axios.get("http://51.20.81.164/api/users/GetUserDetails/" + response.data).then(res => localStorage.setItem("activeUser", JSON.stringify(res.data)));

                navigate("/home")
            } catch (e) {
                console.log(e);
                toast.error('Invalid credentials!', {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: true,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: false,
                    progress: undefined,
                    theme: "colored",
                });

            }

        }

    }

    const register = async () => {

        let isInvalid = false;

        if (firstName.length == 0) {
            toast.error('First name must have completed!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }

        if (lastName.length == 0) {
            toast.error('Last name must have completed!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }

        if (username.length < 6) {
            toast.error('Username must have at least 6 characters!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }
        if (email.length < 4 && !/^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email)) {
            toast.error('Invalid email!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }
        if (password.length < 8 && !/^(?=\S+$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,}$/.test(password)) {
            toast.error('Invalid password!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }
        if (password !== confirmPassword) {
            toast.error('Password and confirmed Password must be the same!', {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: true,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: false,
                progress: undefined,
                theme: "colored",
            });
            isInvalid = true;
        }

        if (!isInvalid) {
            try {
                await Axios.post("http://51.20.81.164/api/Users/Register", {
                    username: username,
                    password: password,
                    email: email
                })

                toast.success('Register with success! You can login', {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: true,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: false,
                    progress: undefined,
                    theme: "colored",
                })
            } catch (e) {
                console.log(e)
                toast.error('Register failed!', {
                    position: "top-right",
                    autoClose: 5000,
                    hideProgressBar: true,
                    closeOnClick: true,
                    pauseOnHover: true,
                    draggable: false,
                    progress: undefined,
                    theme: "colored",
                });
            }


        }

    }

    return (
        <div className={"authentication_container"}>
            <div className={"authentication_card"}>
                <h1>Authentication</h1>
                <div className={"authentication_card_login"}>

                    {registerMode && <>
                                        <span className="p-float-label">
                    <AutoComplete inputId="firstName" value={firstName} onChange={(e) => setFirstName(e.value)}/>
                    <label htmlFor="firstName">First Name</label>
                    </span>

                        <span className="p-float-label">
                    <AutoComplete inputId="lastName" value={lastName} onChange={(e) => setLastName(e.value)}/>
                    <label htmlFor="lastName">Last Name</label>
                    </span>
                    </>}

                    <span className="p-float-label">
                    <AutoComplete inputId="username" value={username} onChange={(e) => setUsername(e.value)}/>
                    <label htmlFor="username">Username</label>
                    </span>
                    {
                        registerMode && <span className="p-float-label">
                    <AutoComplete inputId="email" value={email} onChange={(e) => setEmail(e.value)}/>
                            <label htmlFor="email">Email</label>
                        </span>
                    }
                    <span className="p-float-label">
                    <Password inputId="password" value={password} feedback={registerMode} toggleMask={true}
                              footer={footer}
                              onChange={(e) => setPassword(e.target.value)}/>
                    <label htmlFor="password">Password</label>
                    </span>
                    {registerMode &&
                        <span className="p-float-label">
                    <Password inputId="confirmPassword" value={confirmPassword} toggleMask={true} feedback={false}
                              onChange={(e) => setConfirmPassword(e.target.value)}/>
                    <label htmlFor="confirmPassword">Confirm Password</label>
                    </span>
                    }
                </div>


                <Button onClick={registerMode ? register : login}> {registerMode ? "Register" : "Login"}</Button>
                <Button link
                        onClick={() => setRegisterMode(!registerMode)}>{registerMode ? "Already have an account?" : "New user? Create an account"} </Button>

            </div>
            <ToastContainer/>
        </div>)
}


export default Authentication