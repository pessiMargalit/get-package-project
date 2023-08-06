import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useSelector } from "react-redux/es/exports";
import { useState } from 'react';


export function ClientNavbar() {
   const navigate = useNavigate();
   const client = useSelector((state) => state.clientReducer);
   const driver = useSelector((state) => state.driverReducer);
   const [isDriver,setIsDriver] = useState();

   return (
      <>
         <nav class="navbar" style={{ marginTop: "4vh", position: "relative" }}>
            <svg xmlns="http://www.w3.org/2000/svg" style={{ marginLeft: "4vw" }} onClick={() => { navigate(`/client/${client.userName}/profile`) }} width="22" height="22" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
               <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
               <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z" />
            </svg>
            <div class="logo" ></div>
            <div class="nav-links">
               <ul class="nav-menu">
                  <li><a id='about' onClick={(e) => { navigate(`/client/${client.userName}/add-package`) }} >Add package</a></li>
                  <li><a id='rooms' onClick={(e) => { navigate(`/client/${client.userName}/packages-history`) }} >packages history</a></li>
                  <li><a id='suites' onClick={(e) => {
                     console.log(driver.userName === undefined);
                     if (driver.userName !== undefined) {navigate(`/driver-mode`);setIsDriver(true)}
                    else{setIsDriver(false)} 
                  }} >Driver mode</a></li>
               </ul>
            </div>
            <i class='bx bx-grid-alt menu-hamburger'></i>
         </nav>
         <div>
            {
            isDriver === false &&
            <div style={{width:"8vw",marginLeft:"90.5%",borderStyle:"groove"}}>
               <a style={{fontSize:"12px"}}
               onClick={(e) => { navigate("/sighn-up-as-driver") }}>
                  You do not exist in the system as a driver to register now click here.</a>        
                </div>
            }
        </div>
      </>
   );
}
