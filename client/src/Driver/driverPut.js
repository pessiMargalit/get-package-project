import axios from "axios";
// import { urlDriver } from "../endpoints";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useState } from "react";
import * as yup from "yup";
import { useSelector } from "react-redux";
import { Navbar } from "../GetPackage/navbar";
import { DriverNavbar } from "./driverNavbar";

export const DriverPut = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlDriver = `${baseURL}/Driver`;
    const driver = useSelector(state => state.driverReducer);

    const [id, setId] = useState(0);
    const schema = yup.object().shape({
        id: yup.string(),
        driverID: yup.string(),
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
        userName: yup.string(),
        password: yup.string()
    })
    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });
    const carType = {
        motorcycle: {
            str: "motorcycle",
            int: 0
        },
        truck: {
            str: "truck",
            int: 1
        },
        van: {
            str: "van",
            int: 2
        },
        car_with_2_seats: {
            str: "car with 2 seats",
            int: 3
        },
        car_with_5_seats: {
            str: "car with 5 seats",
            int: 4
        },
        car_with_7_8_seats: {
            str: "car with 7-8 seats",
            int: 5
        },
    }


    const onSubmit = async (data) => {
        debugger
        console.log(data);
        data.id = driver.id;
        data.driverID = driver.driverID;
        data.userName = driver.userName;
        data.password = driver.password;
        await axios.put(`${urlDriver}/${id}`, data)
            .then(response => {
                console.log(response.data);

            })
            .catch(error => {
                console.log(error);
            });
    }

    return (
        <div>
            <DriverNavbar />
            <form onSubmit={handleSubmit(onSubmit)} style={{ width: "40vw", margin: "auto", marginTop: "10vh" }}>
                <div class="form-group">
                    <input type="text" class="form-control" defaultValue={driver.firstName}  {...register("firstName")}></input>
                    <p>{errors.firstName?.message}</p>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" defaultValue={driver.lastName} {...register("lastName")}></input>
                    <p>{errors.lastName?.message}</p>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" defaultValue={driver.phoneNumber} {...register("phoneNumber")}></input>
                    <p>{errors.phoneNumber?.message}</p>
                </div>
                <div class="form-group">
                    <input type="email" class="form-control" defaultValue={driver.email} {...register("email")}></input>
                    <p>{errors.email?.message}</p>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" defaultValue={driver.licenseNumber} {...register("licenseNumber")}></input>
                    <p>{errors.licenseNumber?.message}</p>
                </div>
                <div class="form-group">
                    <input type="text" class="form-control" defaultValue={driver.licensePlateNumber} {...register("licensePlateNumber")}></input>
                    <p>{errors.licensePlateNumber?.message}</p>
                </div>
                <div class="form-group">

                    <select class="form-control" {...register("carType")}>
                        <option value={carType.motorcycle.int}>{carType.motorcycle.str}</option>
                        <option value={carType.truck.int}>{carType.truck.str}</option>
                        <option value={carType.van.int}>{carType.van.str}</option>
                        <option value={carType.car_with_2_seats.int}>{carType.car_with_2_seats.str}</option>
                        <option value={carType.car_with_5_seats.int}>{carType.car_with_5_seats.str}</option>
                        <option value={carType.car_with_7_8_seats.int}>{carType.car_with_7_8_seats.str}</option>
                    </select>
                </div>
                <div class="form-group">
                    <button type="submit" class="form-control">Submit</button>
                </div>

            </form>
        </div>
    );
}