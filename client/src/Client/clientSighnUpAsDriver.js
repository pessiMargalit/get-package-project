import axios from "axios";
// import { urlDriver } from "../endpoints";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useSelector, useDispatch } from "react-redux";
import * as yup from "yup";
import { driverSighnUp } from "../redux/actions/driverAction";
import { useNavigate, useLocation } from "react-router-dom";
import { clientSighnUp } from "../redux/actions/clientActions";

import "../Driver/driverPost.css"

export const ClientSighnUpAsDriver = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlDriver = `${baseURL}/Driver`;
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const schema = yup.object().shape({
        id: yup.string(),
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
    }

    return (
        <>
            <div className="container" style={{marginTop:"0vh"}}>
                <div class="contact-box" >
                    <div class="right">
                        <form onSubmit={handleSubmit(onSubmit)} style={{ width: "40vw", marginLeft: "5vw", marginRight: "5vw" }}>
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
                            <input type="submit"></input>
                        </form>
                    </div>
                </div>
            </div>
        </>
    );
}