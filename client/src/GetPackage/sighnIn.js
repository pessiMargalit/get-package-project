import { useDispatch } from "react-redux";
import { driverSighnIn } from "../redux/actions/driverAction";
import { set, useForm } from "react-hook-form";
import { useRef, useState } from "react";
import axios from "axios";
import { useNavigate, useLocation } from "react-router-dom";
import { clientSighnIn } from "../redux/actions/clientActions";

import "./sighnIn.css";

export function SighnIn() {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const location = useLocation();
    const user_ = location.state.user || {};
    const { register, handleSubmit } = useForm({});
    const myResponse = useRef({})
    const baseURL = process.env.REACT_APP_API_URL;
    const url = `${baseURL}/${user_}`;
    const user = user_ === "Driver" ? "driver" : "client";
    const b = useRef(false);
    const [inCorrect,setInCorrect] = useState(true);

    const onSubmit = async (data) => {

        await axios.post(`${url}/name`, data).then((response) => {
            if (response.status < 300) {
                console.log("data");
                console.log(response.data);
                myResponse.current = response.data;
                console.log(myResponse.current);
                setInCorrect(response.data === true?true:false);
                b.current = true
            }
            else {
                console.log(`error ${response.status}`);

            }
        }).catch(error => {
            console.log(error);
        });

        if (b.current === true) {
            user === "driver" ? dispatch(driverSighnIn(myResponse.current)) : dispatch(clientSighnIn(myResponse.current));
            b.current = true
            navigate(`/${user}/${myResponse.current.userName}`)
        }
        else {
            console.log("user name or password inncorrect");
            console.log(myResponse);
            setInCorrect(false);
            b.current = false
        }
        console.log("b:");
        console.log(b.current);
        console.log("res:");
        console.log(myResponse.current);
    }
    return (
        <>
            <div className="container">
                <div class="contact-box">
                    <div class="left"></div>
                    <div class="right">
                        <form onSubmit={handleSubmit(onSubmit)} >
                            <div class="form-outline mb-4" >
                                <input type="text" id="form2Example1" class="form-control" placeholder="userName" {...register("userName")} />
                            </div>
                            <div class="form-outline mb-4">
                                <input type="password" id="form2Example2" class="form-control" placeholder="password" {...register("password")} />
                            </div>
                            {inCorrect===false&&<p>User name or password inncorrect</p>}

                           
                            <div class="row mb-4">
                                <div class="col d-flex justify-content-center">

                                    <div class="form-check">
                                        <input class="form-check-input" type="checkbox" value="" id="form2Example31" checked />
                                        <label class="form-check-label" for="form2Example31"> Remember me </label>
                                    </div>
                                </div>
                                <div class="col">

                                    <a >Forgot password?</a>
                                </div>
                            </div>
                            <button type="submit" class="btn btn-primary btn-block mb-4" >Sighn in</button>
                        </form>
                        <div class="text-center">
                            <p style={{ cursor: "pointer" }} onClick={(e) => { navigate(`/${user}-sighn-up`); }}>Not a member?  Shign Up</p>
                        </div >

                    </div>
                </div>
            </div>
        </>
    );
}

