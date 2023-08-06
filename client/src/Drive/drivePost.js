import axios from "axios";
import "../GetPackage/sighnIn.css"
// import { urlDrive } from "../endpoints";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useSelector, useDispatch } from "react-redux/es/exports";
import { driverSighnIn } from "../redux/actions/driverAction";
import { DriverNavbar } from "../Driver/driverNavbar";

import "../Drive/drivePost.css"
export const DrivePost = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlDrive = `${baseURL}/Drive`;
    const dispatch = useDispatch();
    const driver = useSelector(state => state.driverReducer);
    const schema = yup.object().shape({
        _Id: yup.string(),
        driverId: yup.string(),
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
        dateTime: yup.date()
    })
    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = async (data) => {
        data._Id = "";
        data.driverId = driver.driverID;
        // data.dateTime = new Date().toLocaleString();
        console.log(data);
        await axios.post(urlDrive, data)
            .then(response => {
                if (response.status >= 200 && response.status < 300) {
                    // driver.drives.push(data);
                    // console.log(driver);
                    // dispatch(driverSighnIn(driver))
                    console.log(response.data);
                    console.log(data);
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    return (
        <>
            <DriverNavbar />
            <div className="container-driver" style={{ marginTop: "0vh" }}>
                <div class="contact-box">
                    <div class="left_" ></div>
                    <div class="right" >
                        <form onSubmit={handleSubmit(onSubmit)} style={{ width: "20vw", margin: "auto" }}>
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
                            </div>
                            <br />
                            <input class="form-control" type="submit"></input>
                        </form>

                    </div>
                </div>
            </div>
        </>
    );
}
