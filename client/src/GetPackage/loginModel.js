
import { useState } from "react";
import Modal from 'react-bootstrap/Modal';
import { useNavigate } from 'react-router-dom';
import "../GetPackage/loginModel.css"

export function LoginModel() {
    const navigate = useNavigate();
    const [show, setShow] = useState(false);
    const handeClose = () => setShow(false);
    const handeShow = () => setShow(true);

    return (
        <>

            <button id="loginBtn" onClick={handeShow}> Login</button>
            <Modal id="modal" show={show} onHide={handeClose}>

                <div id="modalStyle" style={{ width: "30vw", height: "30vh" }}>
                    <div id="innerModal">

                        <button className="button" onClick={(e) => {
                            e.preventDefault();
                            setShow(false);
                            { navigate(`/sighn-in`, { state: { user: "Driver" } }) }
                        }} >Login as driver</button>
                        <button className="button" onClick={(e) => {
                            e.preventDefault();
                            setShow(false);
                            { navigate(`/sighn-in`, { state: { user: "Client" } }) }
                        }} >Login as client</button>


                    </div>

                </div>
                {/* <br /><br /><br />
            <i class="fa-solid fa-car"></i>
            <br />
            <i class="fa-solid fa-truck"></i>
            <br />
            <i class="fa-solid fa-motorcycle"></i>
            <br />
            <i class="fa-solid fa-person"></i>
            <br />
            <i class="fa-solid fa-location-dot"></i>
            <br />
            <i class="fa-solid fa-globe"></i>
            <br />
            <i class="fa-solid fa-road"></i><br />
            <i class="fa-solid fa-user-group"></i><br />
            <i class="fa-solid fa-house" /><br />
            <i class="fa-solid fa-truck-fast"></i><br />
            <i class="fa-solid fa-route"></i><br/>
            <i class="fa-brands fa-waze"></i><br/>
            <i class="fa-solid fa-user-vneck-hair-long"></i><br/>
            <i class="fa-solid fa-user-vneck-hair"></i><br/> */}

            </Modal>
           
        </>
    )

}