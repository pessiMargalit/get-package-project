import axios from "axios";
import {useState } from "react";
// import { urlClient } from  "../endpoints";
import {useForm} from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useSelector } from "react-redux";
import { ClientNavbar } from "./clientNavbar";

export const ClientPut = ()=>{
    const baseURL = process.env.REACT_APP_API_URL;
    const urlClient = `${baseURL}/Client`;
//לטפל בID הוא לא משתנה
    const [id,setId] = useState(0);
    const client = useSelector(state=>state.clientReducer)
    const schema = yup.object().shape({
        id:yup.string(),
        firstName:yup.string().required("First name is required"),
        lastName:yup.string().required("Last name is required"),
        phoneNumber:yup //check the validation..
        .string()
        .matches(
          /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/,
          "Enter a valid phone number"
        ).required(),
        email:yup.string().email().required(),
        userName:yup.string(),
        password:yup.string()


    })
    const { register, handleSubmit,formState:{errors} } = useForm({
        resolver:yupResolver(schema),
    });
    const onSubmit= async(data)=>{
        console.log(id);
        data.id = client.id;
        data.userName = client.userName;
        data.password = client.password;
       await axios.put(`${urlClient}/${id}`, data)
                    .then(response => {
                        console.log(response.data);
                        console.log(data);
                    })
                    .catch(error => {
                        console.log(error);
                    });
    }
    return(
        <>
        <ClientNavbar/>
        <form onSubmit={handleSubmit(onSubmit)} style={{ width: "40vw", margin: "auto", marginTop: "10vh" }}>
        <div class="form-group" >
            <input type="text" class="form-control" defaultValue={client.firstName}  {...register("firstName")}></input>
            <p>{errors.firstName?.message}</p>
        </div>
        <div class="form-group">
            <input type="text" class="form-control" defaultValue={client.lastName} {...register("lastName")}></input>
            <p>{errors.lastName?.message}</p>
        </div>
        <div class="form-group">
            <input type="text" class="form-control" defaultValue={client.phoneNumber} {...register("phoneNumber")}></input>
            <p>{errors.phoneNumber?.message}</p>
        </div>
        <div class="form-group">
            <input type="email" class="form-control" defaultValue={client.email} {...register("email")}></input>
            <p>{errors.email?.message}</p>
        </div>
        <div class="form-group">
        <button type="submit" class="form-control">Submit</button>
        </div>

    </form>
    </>
    );
}


