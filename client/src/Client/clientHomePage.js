import React from 'react';

import img from "../Img/delivery.jpg"
import { ClientNavbar } from './clientNavbar';



export function ClientHomePage() {

   return (
      <>
      <ClientNavbar/>
         <img src={img} style={{width:"60vw",height:"90vh",marginTop:"10vh"}}/>

      </>
   );
}
