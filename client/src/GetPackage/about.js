import { Navbar } from "./navbar"

import img from "../Img/page2.JPG"
export const About = () => {
    return(
        <>
        
        <Navbar/>
        <img src={img} style={{width:"50vw",height:"70vh",marginTop:"10vh"}}/>
        <h1>This page is still under construction....</h1>
        </>
    )
}