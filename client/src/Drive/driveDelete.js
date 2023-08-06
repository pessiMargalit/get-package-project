import axios from "axios";
import {React,useState } from "react";
// import { urlDrive } from "../endpoints";
import {useForm} from "react-hook-form";

export const DriveDelete = ()=>{
    const baseURL = process.env.REACT_APP_API_URL;
    const urlDrive = `${baseURL}/Drive`;
    const [id,setId] = useState("");;
    const {handleSubmit} = useForm({});
    const onSubmit= async()=>{

       await axios.delete(`${urlDrive}/${id}`)
                    .then(response => {
                        console.log(response.data);
                    })
                    .catch(error => {
                        console.log(error);
                    });
    }
    return(
<form onSubmit={handleSubmit(onSubmit)}>
<input type="text" placeholder="id"  onChange={(e)=>setId(e.target.value)}></input>
<input type="submit"></input>
</form>
    );
}
