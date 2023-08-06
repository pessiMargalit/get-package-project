import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useSelector } from "react-redux/es/exports";


export function DriverNavbar() {
   const navigate = useNavigate();
   const driver = useSelector((state) => state.driverReducer);

   return (
      <>
         <nav class="navbar" style={{ marginTop: "4vh" ,marginBottom:"0vh"   , position: "relative"}}>
         <svg xmlns="http://www.w3.org/2000/svg" style={{marginLeft:"4vw"}}  onClick={() => { navigate(`/driver/${driver.userName}/profile`) }} width="22" height="22" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                     <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
                     <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z" />
                  </svg>
            <div class="logo" ></div>
            <div class="nav-links">
               <ul class="nav-menu">
                  <li><a onClick={(e) => { navigate(`/driver/${driver.userName}/add-drive`) }} >Add drive</a></li>
                  <li><a onClick={(e) => { navigate(`/driver/${driver.userName}/drives-history`) }} >Drive history</a></li>
                  <li><a  onClick={(e) => { navigate(`/${driver.userName}/client-mode`) }} >Client mode</a></li>
               </ul>
            </div>
            <i class='bx bx-grid-alt menu-hamburger'></i>
         </nav>
      </>
   );
}
