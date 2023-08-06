import {  useDispatch } from "react-redux";
import { driverSighnIn } from "../redux/actions/driverAction";
import { useForm } from "react-hook-form";
import { useEffect, useRef } from "react";
import axios from "axios";
import { useState } from "react";
import Modal from 'react-bootstrap/Modal';


export function DriverModelSighnIn() {
    const baseURL = process.env.REACT_APP_API_URL;
    const url = `${baseURL}/driver`;

    const [show, setShow] = useState(false);
    const handeClose = () => setShow(false);
    const handeShow = () => setShow(true);
    const dispatch = useDispatch();
    const { register, handleSubmit } = useForm({});
    const myResponse = useRef({})

    const b = useRef(false);
    useEffect (()=>{
        handeShow();
        debugger
    },[])
    const onSubmit = async (data) => {

        await axios.post(`${url}/name`, data).then((response) => {
            if (response.status < 300) {
                console.log("data");
                console.log(response.data);
                myResponse.current = response.data;
                console.log(myResponse.current);
                debugger
                b.current = true
            }
            else {
                console.log(`error ${response.status}`);

            }
        }).catch(error => {
            console.log(error);
        });
        debugger
        if (b.current === true) {
            dispatch(driverSighnIn(myResponse.current));
            b.current = true
        }
        else {
            console.log("user name or password inncorrect");
            b.current = false
        }
        // data.preventDefault();
        setShow(false);

    }
    return (
        <>

            <Modal id="modal" show={show} onHide={handeClose}>

            <div style={{ margin: "auto", marginTop: "8vh" }}>
            <form onSubmit={handleSubmit(onSubmit)}>


                <div class="form-outline mb-4">
                    <input type="text" id="form2Example1" class="form-control" placeholder="userName" {...register("userName")} />
                </div>

                <div class="form-outline mb-4">
                    <input type="password" id="form2Example2" class="form-control" placeholder="password" {...register("password")} />
                </div>

                <div class="row mb-4">
                    <div class="col">
                        <a >Forgot password?</a>
                    </div>
                </div>

                
                <button type="submit" class="btn btn-primary btn-block mb-4" 
                        >Sign in</button>
            </form>
        </div>
            </Modal>


        </>
    )

}