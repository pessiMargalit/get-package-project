import axios from "axios";
// import { urlDriver } from "../endpoints";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useSelector, useDispatch } from "react-redux";
import * as yup from "yup";
import { driverSighnUp } from "../redux/actions/driverAction";
import { useNavigate, useLocation } from "react-router-dom";
import { clientSighnUp } from "../redux/actions/clientActions";

import "./driverPost.css"

export const DriverPost = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlDriver = `${baseURL}/Driver`;
    const urlClient = `${baseURL}/Client`;
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const client = {
        id: "",
        firstName: "",
        lastName: "",
        phoneNumber: "",
        email: "",
        userName: "",
        password: ""
    }
    const schema = yup.object().shape({
        id: yup.string(),
        driverID: yup.string().length(9).required(),
        firstName: yup.string().required("First name is required"),
        lastName: yup.string().required("Last name is required"),
        phoneNumber: yup
            .string()
            .matches(
                /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/,
                "Enter a valid phone number"
            ).required(),
        email: yup.string().email().required("Email is required"),
        licenseNumber: yup.string().required("License number is required"),
        licensePlateNumber: yup.string().required("License plate number is required"),
        carType: yup.number().integer().required("Car type is required"),
        userName: yup.string().required(),
        password: yup.string().min(5).max(12).required()

    })

    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });

    const carType = {
        motorcycle: {
            str: "motorcycle",
            int: 1
        },
        truck: {
            str: "truck",
            int: 1
        },
        van: {
            str: "van",
            int: 1
        },
        car_with_2_seats: {
            str: "car with 2 seats",
            int: 1
        },
        car_with_5_seats: {
            str: "car with 5 seats",
            int: 1
        },
        car_with_7_8_seats: {
            str: "car with 7 8 seats",
            int: 1
        },
    }

    const onSubmit = async (data) => {
        console.log(data);
        await axios.post(urlDriver, data)
            .then(response => {
                console.log(response.data);
                dispatch(driverSighnUp(data));
            })
            .catch(error => {
                console.log(error);
            });

        navigate(`/driver/${data.userName}`);

        client.id = data.driverID;
        client.firstName = data.firstName;
        client.lastName = data.lastName;
        client.email = data.email;
        client.phoneNumber = data.phoneNumber;
        client.userName = data.userName;
        client.password = data.password;

        await axios.post(urlClient, client)
            .then(response => {
                console.log(response.data);
                dispatch(clientSighnUp(client));
            })
            .catch(error => {
                console.log(error);
            });
    }

    return (
        <>
            <div className="container" style={{marginTop:"0vh"}}>
                <div class="contact-box" >
                    <div class="right">
                        <form onSubmit={handleSubmit(onSubmit)} style={{ width: "40vw", marginLeft: "5vw", marginRight: "5vw" }}>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="driverID" {...register("driverID")}></input>
                                <p>{errors.driverID?.message}</p>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="firstName" {...register("firstName")}></input>
                                <p>{errors.firstName?.message}</p>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="lastName" {...register("lastName")}></input>
                                <p>{errors.lastName?.message}</p>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="phoneNumber" {...register("phoneNumber")}></input>
                                <p>{errors.phoneNumber?.message}</p>
                            </div>
                            <div class="form-group">
                                <input type="email" class="form-control" placeholder="email" {...register("email")}></input>
                                <p>{errors.email?.message}</p>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="licenseNumber" {...register("licenseNumber")}></input>
                                <p>{errors.licenseNumber?.message}</p>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="licensePlateNumber" {...register("licensePlateNumber")}></input>
                                <p>{errors.licensePlateNumber?.message}</p>
                            </div>
                            <div class="form-group">
                                <select {...register("carType")} class="form-control">
                                    <option value={carType.motorcycle.int}>{carType.motorcycle.str}</option>
                                    <option value={carType.truck.int}>{carType.truck.str}</option>
                                    <option value={carType.van.int}>{carType.van.str}</option>
                                    <option value={carType.car_with_2_seats.int}>{carType.car_with_2_seats.str}</option>
                                    <option value={carType.car_with_5_seats.int}>{carType.car_with_5_seats.str}</option>
                                    <option value={carType.car_with_7_8_seats.int}>{carType.car_with_7_8_seats.str}</option>
                                </select>
                                <p>{errors.carType?.message}</p>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="userName" {...register("userName")}></input>
                                <p>{errors.userName?.message}</p>
                            </div>
                            <div class="form-group">
                                <input type="password" class="form-control" placeholder="password" {...register("password")}></input>
                                <p>{errors.password?.message}</p>
                            </div>
                            <input type="submit"></input>
                        </form>
                    </div>
                </div>
            </div>
        </>
    );
}