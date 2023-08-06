import { Navbar } from "./navbar"
import img from "../Img/homePage.jpg"
import { Footer } from "./Footer"
// import img from "../Img/1.webp"

export const HomePage = () => {
    return(
        <>
        
        <Navbar/>

        <img src={img} style={{width:"100vw",height:"100vh"}}/>
        {/* <Footer/> */}
        </>
    )
}