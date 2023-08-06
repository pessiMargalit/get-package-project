import React from 'react';
import { DriverNavbar } from './driverNavbar';

import img from "../Img/3.jpg"
// import img from "../Img/8.webp"


export function DriverHomePage() {
   return (
      <>
         <DriverNavbar/>
         <img src={img} style={{ marginTop: "15vh" }} />
      </>
   );
}
