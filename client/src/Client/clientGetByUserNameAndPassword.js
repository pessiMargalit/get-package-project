import axios from "axios";
import { useState } from "react";
// import { urlClient } from "../endpoints";
import {React, useEffect } from "react";


export const ClientGetByUserNameAndPassword = (props) => {

    const [myResponse, setMyResponse] = useState({});
    useEffect(() => {
    setMyResponse(props.client);
    }, []);

    return (

        <div>
            <h1>Clients:</h1>
            <h2>{myResponse.id}</h2>
            <h2>{myResponse.firstName}</h2>
            <h2>{myResponse.lastName}</h2>

        </div>
    );
}

