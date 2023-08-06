import axios from "axios";
import { useEffect } from "react";
// import { urlPackage } from "../endpoints";
import { useState,useRef } from "react";
import { useSelector, useDispatch } from "react-redux";


export const PackagePut = (props) => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlPackage = `${baseURL}/Package`;

    // const dispatch = useDispatch();
    const package_  = useSelector((state) => state.packageReducer);
    // debugger
    console.log("package_");
    console.log(package_);
    console.log("props.package");
    console.log(props.package);

    const id = useRef("");
    useEffect(() => {
        // debugger
    const updatePackage = async () => {
        id.current = props.package._Id;

        await axios.put(`${urlPackage}/${id}`, props.package)
            .then(response => {
                debugger
                console.log(response.data);
                // dispatch(clientSighnUp(data.userName,data.password));
                
            })
            .catch(error => {
                console.log(error);
            });
    }
    updatePackage();
}, []);
    return (
        <>
        </>
        
    );
}

