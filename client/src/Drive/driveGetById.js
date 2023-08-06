import axios from "axios";
import {React, useState } from "react";
// import { urlDrive } from  "../endpoints";
import { useForm } from "react-hook-form";

export const DriveGetById = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlDrive = `${baseURL}/Drive`;
    const [id, setId] = useState("");
    const [myResponse, setMyResponse] = useState({});

    const { handleSubmit } = useForm({});
    const onSubmit = async ()  => {
        await  axios.get(`${urlDrive}/${id}`)
            .then(response => {
                console.log(response.data);
                setMyResponse(response.data);

            })
            .catch(error => {
                console.log(error);
            });
    }
    return (

        <div>
            <form onSubmit={handleSubmit(onSubmit)}>
                <input type="text" placeholder="id" onChange={(e) => setId(e.target.value)}></input>
                <input type="submit"></input>
            </form>
            <h1>Drive:</h1>
            <h2>{myResponse._Id}</h2>
            
        </div>
    );
}




