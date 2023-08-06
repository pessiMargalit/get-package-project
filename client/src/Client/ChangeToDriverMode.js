
import { useState } from "react";
import axios from "axios";
import { React, useEffect } from "react";
import { useSelector } from "react-redux/es/exports";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { driverSighnIn } from "../redux/actions/driverAction";


export const ChangeToDriverMode = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const url = `${baseURL}/Driver`;

    const driver = useSelector((state) => state.driverReducer);
    const client = useSelector((state) => state.clientReducer);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const user = { userName: "", password: "" }

    useEffect(() => {

            const get = async () => {
                user.userName = client.userName;
                user.password = client.password;

                await axios.post(`${url}/name`, user).then((response) => {
                    if (response.status < 300) {
                        console.log(response.data);
                        dispatch(driverSighnIn(response.data));
                    }
                    else {
                        console.log(`error ${response.status}`);
                    }
                }).catch(error => {
                    console.log(error);
                });
            }

            if (driver.userName === undefined) {
                get();
            }

            navigate(`/driver/${driver.userName}`);

    }, []);

    return (

        <div>

        </div>
    );
}


