import axios from "axios";
// import { urlPackage } from "../endpoints";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useSelector, useDispatch } from "react-redux";
import * as yup from "yup";
import { clientAddPackage } from "../redux/actions/clientActions";
import { useRef, useState } from "react";
import { ClientNavbar } from "../Client/clientNavbar";
import "./packagePost.css"

export const PackagePost = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlPackage = `${baseURL}/Package`;
    const client = useSelector((state) => state.clientReducer);
    const dispatch = useDispatch();
    // const isCreated = useRef(false);
    const [isCreated,setIsCreated] = useState(false);
    const schema = yup.object().shape({
        _Id: yup.string(),
        // driverId: yup.string().required()/*.length(9)*/,
        // driveId: yup.string().required(),
        hostId: yup.string(),
        phoneOfdestination: yup.string().required("Phone of destination is required"),
        //         .matches(
        //             /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/,
        //             "Enter a valid phone number"
        // )
        //         .required(),
        source: yup.object().shape({
            city: yup.string().required("Source city is required"),
            street: yup.string().required("Source street is required"),
            houseNumber: yup.number().integer().required("Source house number is required")
        }),
        destination: yup.object().shape({
            city: yup.string().required("Destination city is required"),
            street: yup.string().required("Destination street is required"),
            houseNumber: yup.number().integer().required("Destination house number is required")
        }),
        size: yup.object().shape({
            hight: yup.number().required("Hight number is required"),
            width: yup.number().required("Width house number is required"),
            weight: yup.number().required("Weight house number is required")
        }),

        isMatch: yup.bool(),
        isTaken: yup.bool(),
    })
    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });


    const onSubmit = async (data) => {
        debugger
        console.log(schema);
        data._Id = ""
        data.hostId = client.id;
        await axios.post(urlPackage, data)
            .then(response => {
                console.log(response.data);
                dispatch(clientAddPackage(data));
                setIsCreated(true);
                console.log(data);
            })
            .catch(error => {
                console.log(error);
            });
    }

    return (
        <>
            <ClientNavbar />
            <div className="container-package" style={{marginTop:"0vh"}}>
                <div class="contact-box">
                    <div class="leftDiv"></div>
                    <div class="right">
                        <form onSubmit={handleSubmit(onSubmit)} style={{ width: "20vw", margin: "auto"}}>
                            <div class="form-group">
                                <h3>Source:</h3>
                                <br />
                                <input type="text" class="form-control" placeholder="city" {...register("source.city")}></input>
                                <p>{errors.source?.city && errors.source.city?.message}</p>
                                <input type="text" class="form-control" placeholder="street" {...register("source.street")}></input>
                                <p>{errors.source?.street && errors.source.street?.message}</p>
                                <input type="text" class="form-control" placeholder="houseNumber" {...register("source.houseNumber")}></input>
                                <p>{errors.source?.houseNumber && errors.source.houseNumber?.message}</p>
                            </div>
                            <div class="form-group">
                                <h3>Destination:</h3>
                                <br />
                                <input type="text" class="form-control" placeholder="city" {...register("destination.city")}></input>
                                <p>{errors.destination?.city && errors.destination.city?.message}</p>
                                <input type="text" class="form-control" placeholder="street" {...register("destination.street")}></input>
                                <p>{errors.destination?.street && errors.destination.street?.message}</p>
                                <input type="text" class="form-control" placeholder="houseNumber" {...register("destination.houseNumber")}></input>
                                <p>{errors.destination?.houseNumber && errors.destination.houseNumber?.message}</p>
                                <input type="text" class="form-control" placeholder="phoneOfdestination" {...register("phoneOfdestination")}></input>
                                <p>{errors.phoneOfdestination && errors.phoneOfdestination?.message}</p>
                            </div>
                            <div class="form-group">
                                <h3>Size:</h3>
                                <br />
                                <input type="text" class="form-control" placeholder="hight" {...register("size.hight")}></input>
                                <p>{errors.size?.hight && errors.size.hight?.message}</p>
                                <input type="text" class="form-control" placeholder="width" {...register("size.width")}></input>
                                <p>{errors.size?.width && errors.size.width?.message}</p>
                                <input type="text" class="form-control" placeholder="weight" {...register("size.weight")}></input>
                                <p>{errors.size?.weight && errors.size.weight?.message}</p>
                            </div>
                            <input class="form-control" type="submit"></input>
                        </form>

                    </div>
                </div>
            </div>
            {isCreated === true &&
                <h1>The package has been successfully added</h1>}
        </>
    );
}


