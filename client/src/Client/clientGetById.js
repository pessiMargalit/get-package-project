import axios from "axios";
import {React, useState } from "react";
// import { urlClient } from  "../endpoints";
import { useForm } from "react-hook-form";

export const ClientGetById = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlClient = `${baseURL}/Client`;
    const [id, setId] = useState("");
    const [myResponse, setMyResponse] = useState({});

    const { handleSubmit } = useForm({});
    const onSubmit = async ()  => {
        await  axios.get(`${urlClient}/${id}`)
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
            <h1>Clients:</h1>
            <h2>{myResponse.id}</h2>
            <h2>{myResponse.firstName}</h2>
            <h2>{myResponse.lastName}</h2>

        </div>
    );
}

