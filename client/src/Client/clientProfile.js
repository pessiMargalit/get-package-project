import { useSelector } from "react-redux/es/exports";
import Table from 'react-bootstrap/Table';
import { useEffect, useState } from "react";
import "../Driver/profile.css"
import { useNavigate } from "react-router-dom";
import { ClientNavbar } from "./clientNavbar";

export const ClientProfile = () => {
    const client_ = useSelector((state) => state.clientReducer);
    const [client, setClient] = useState({});
    const navigate = useNavigate();
    useEffect(() => {
        setClient(client_)
    }, [])
    return (
  
        <>
         {client != null &&<ClientNavbar/>}
         {client != null && <div class="card">
                <div class="card_background_img"></div>
                <div class="card_profile_img">

                </div>
                <div class="user_details">
                    <h3>{client.firstName} {client.lastName}</h3>
                </div>
                <div class="card_count">
                    <div class="count">
                        <div class="fans">
                            <h3>{client.phoneNumber}</h3>
                        </div>
                        <div class="following">
                            <h3>{client.email}</h3>

                        </div>

                    </div>   
                    <div class="UpdateBtn" onClick={(e) => { navigate(`/client/${client.userName}/update-profile`) }} >Update</div>
                </div>
            </div>}
    </>

);

}



