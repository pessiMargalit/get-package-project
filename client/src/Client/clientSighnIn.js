import { useSelector, useDispatch } from "react-redux";
import { ClientGetByUserNameAndPassword } from "./clientGetByUserNameAndPassword";
import { clientSighnIn } from "../redux/actions/clientActions";
import { useForm } from "react-hook-form";
import { useState,useRef } from "react";
import axios from "axios";


export function ClientSighnIn() {
    const dispatch = useDispatch();
    const { register, handleSubmit } = useForm({});
    const [myResponse, setMyResponse] = useState({});
    const baseURL = process.env.REACT_APP_API_URL;
    const urlClient = `${baseURL}/Client`;
    const b = useRef(false);

    const onSubmit = async (data) => {
   
      await  axios.post(`${urlClient}/name`,data).then((response) => {
            if(response.status<300){
                 setMyResponse(response.data);
                 b.current  = true
            console.log(response.data); 
            }
           else{
            console.log(`error ${response.status}`);

           }
        }).catch(error => {
            console.log(error);
        });
        
        if(b.current  === true){
        dispatch(clientSighnIn(myResponse));
        b.current  =true
        }
        else{
              console.log("user name or password inncorrect");
            //   debugger
            //   console.log(myResponse);
            b.current  =false
        }
         
    }
    return (
        <div>
            <form onSubmit={handleSubmit(onSubmit)}>
                <input type="text" placeholder="userName" {...register("userName")}></input>
                <br/><br/>
                <input type="password" placeholder="password" {...register("password")}></input>
                <br/><br/>
                <input type="submit"></input>
            </form>{
                b.current === true && <ClientGetByUserNameAndPassword client={myResponse} ></ClientGetByUserNameAndPassword>
            }
                {/* {
                    myResponse === false && <h1>User name or password inncorrect</h1>
                } */}
        </div>
    );
}
