import axios from "axios";
import {React,useState } from "react";
// import { urlDriver } from "../endpoints";
import {useForm} from "react-hook-form";

export const DriverDelete = ()=>{
    const baseURL = process.env.REACT_APP_API_URL;
    const urlDriver = `${baseURL}/Driver`;
    const [userName,setUserName] = useState("");
    const [password,setPassword] = useState("");
    const [user, setUser] = useState({
        userName: userName,
        password: password
    });
    const {handleSubmit} = useForm({});
    const onSubmit= async()=>{
        setUser({userName,password})
       await axios.delete(`${urlDriver}/delete`,{data:user})
                    .then(response => {
                        console.log(response.data);
                    })
                    .catch(error => {
                        console.log(error);
                    });
    }
    return(
<form onSubmit={handleSubmit(onSubmit)}>
<input type="text" placeholder="userName"  onChange={(e)=>setUserName(e.target.value)}></input>
<input type="password" placeholder="password"  onChange={(e)=>setPassword(e.target.value)}></input>
<input type="submit"></input>
</form>
    );
}


