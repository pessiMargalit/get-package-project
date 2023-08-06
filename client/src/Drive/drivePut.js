import axios from "axios";
// import { urlDrive } from "../endpoints";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

export const DrivePut = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlDrive = `${baseURL}/Drive`;
    // const dispatch = useDispatch();

    const [id, setId] = useState(0);
    const schema = yup.object().shape({
        _Id: yup.string(),
        driverId: yup.string().required()/*.length(9)*/,
        source: yup.object().shape({
            city: yup.string().required(),
            street: yup.string().required(),
            houseNumber: yup.number().integer().required()
        }),
        destination: yup.object().shape({
            city: yup.string().required(),
            street: yup.string().required(),
            houseNumber: yup.number().integer().required()
        }),
    })
    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });


    const onSubmit = async (data) => {
        console.log(schema);
        await axios.put(`${urlDrive}/${id}`, data)
            .then(response => {
                console.log(response.data);
                // dispatch(clientSighnUp(data.userName,data.password));
                console.log(data);
            })
            .catch(error => {
                console.log(error);
            });
    }
    return (

        <form onSubmit={handleSubmit(onSubmit)}>
            <input type="text" placeholder="_Id" onChange={(e) => { console.log(id); setId(e.target.value) }} {...register("_Id")}></input>
            <input type="text" placeholder="driverId" {...register("driverId")}></input>

            <p>Source:</p>
            <br />
            <input type="text" placeholder="city" {...register("source.city")}></input>
            <p>{errors.source?.city && errors.source.city?.message}</p>
            <input type="text" placeholder="street" {...register("source.street")}></input>
            <p>{errors.source?.street && errors.source.street?.message}</p>
            <input type="text" placeholder="houseNumber" {...register("source.houseNumber")}></input>
            <p>{errors.source?.houseNumber && errors.source.houseNumber?.message}</p>
            <p>Destination:</p>
            <br />
            <input type="text" placeholder="city" {...register("destination.city")}></input>
            <p>{errors.destination?.city && errors.destination.city?.message}</p>
            <input type="text" placeholder="street" {...register("destination.street")}></input>
            <p>{errors.destination?.street && errors.destination.street?.message}</p>
            <input type="text" placeholder="houseNumber" {...register("destination.houseNumber")}></input>
            <p>{errors.destination?.houseNumber && errors.destination.houseNumber?.message}</p>

            <input type="submit"></input>
        </form>
    );
}
