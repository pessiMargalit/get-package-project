import axios from "axios";
// import { urlClient } from "../endpoints";
import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useDispatch } from "react-redux";
import { clientSighnUp } from "../redux/actions/clientActions";

import "../Driver/driverPost.css"

export const ClientPost = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlClient = `${baseURL}/Client`;
    const navigate = useNavigate();

    const dispatch = useDispatch();
    const schema = yup.object().shape({
        id: yup.string().length(9).required(),
        firstName: yup.string().required("First name is required"),
        lastName: yup.string().required("Last name is required"),
        phoneNumber: yup
            .string()
            .matches(
                /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/,
                "Enter a valid phone number"
            ).required(),
        email: yup.string().email().required(),
        userName: yup.string().required(),
        password: yup.string().min(5).max(12).required()

    })
    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });
    const onSubmit = async (data) => {
        await axios.post(urlClient, data)
            .then(response => {
                console.log(response.data);
                dispatch(clientSighnUp(data.userName, data.password));
            })
            .catch(error => {
                console.log(error);
            });
        navigate(`/client/${data.userName}`);
    }
    return (
        <div className="container" style={{width:"50vw"}}>
            <div class="contact-box">
                <div class="right">
                    <form onSubmit={handleSubmit(onSubmit)} style={{ width: "30vw", marginLeft: "8vw", marginRight: "8vw"}}>
                        <div class="form-group">
                            <input type="text" placeholder="firstName" class="form-control" {...register("firstName")}></input>
                            <p>{errors.firstName?.message}</p>
                        </div>
                        <div class="form-group">
                            <input type="text" placeholder="lastName" class="form-control" {...register("lastName")}></input>
                            <p>{errors.lastName?.message}</p>
                        </div>
                        <div class="form-group">
                            <input type="text" placeholder="id" class="form-control" {...register("id")}></input>
                            <p>{errors.id?.message}</p>
                        </div>
                        <div class="form-group">
                            <input type="text" placeholder="phoneNumber" class="form-control" {...register("phoneNumber")}></input>
                            <p>{errors.phoneNumber?.message}</p>
                        </div>
                        <div class="form-group">
                            <input type="email" placeholder="email" class="form-control" {...register("email")}></input>
                            <p>{errors.email?.message}</p>
                        </div>
                        <div class="form-group">
                            <input type="text" placeholder="userName" class="form-control" {...register("userName")}></input>
                            <p>{errors.userName?.message}</p>
                        </div>
                        <div class="form-group">
                            <input type="password" placeholder="password" class="form-control" {...register("password")}></input>
                            <p>{errors.password?.message}</p>
                        </div>
                        <div class="form-group">
                            <input type="submit" class="form-control"></input>
                        </div>
                    </form>

                </div>
            </div>
        </div>
    );
}



