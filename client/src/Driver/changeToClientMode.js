
import { useState } from "react";
import axios from "axios";
import { React, useEffect } from "react";
import { useSelector } from "react-redux/es/exports";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { clientSighnIn } from "../redux/actions/clientActions";



export const ChangeToClientMode = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const url = `${baseURL}/Client`;

    const driver = useSelector((state) => state.driverReducer);
    const client = useSelector((state) => state.clientReducer);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const user = { userName: "", password: "" }

    useEffect(() => {
       const get = async () => {
            user.userName = driver.userName;
            user.password = driver.password;
            console.log("client-mode");

            await axios.post(`${url}/name`, user).then((response) => {
                if (response.status < 300) {
                    console.log(response.data);
                    dispatch(clientSighnIn(response.data));
                }
                else {
                    console.log(`error ${response.status}`);
                }
            }).catch(error => {
                console.log(error);
            });
        }
        
        if (client.userName === undefined) {
            get(); 
        }
          navigate(`/client/${driver.userName}`)
    }, []);

    return (

        <div>

        </div>
    );
}


