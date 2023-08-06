import { useSelector } from "react-redux/es/exports";
import Table from 'react-bootstrap/Table';
import { useEffect, useState } from "react";
import '../Driver/profile.css'
import { useNavigate } from "react-router-dom";
import { DriverNavbar } from "./driverNavbar";


export const DriverProfile = () => {
    const driver_ = useSelector((state) => state.driverReducer);
    const [driver, setDriver] = useState({});
    const navigate = useNavigate();
    useEffect(() => {
        setDriver(driver_)
    }, [])
    const getCarType = () => {
        switch (driver.carType) {
            case 1:
                return "motorcycle";
            case 2:
                return "truck";
            case 3:
                return "van";
            case 4:
                return "car with 2 seats";
            case 5:
                return "car with 5 seats";
            case 6:
                return "car with 7-8 seats";
        }
    }

    return (

        <>
       
            {driver !== null && <DriverNavbar />}
            {driver != null && <div class="card">
                <div class="card_background_img"></div>
                <div class="card_profile_img">

                </div>
                <div class="user_details">
                    <h3>{driver.firstName} {driver.lastName}</h3>
                </div>
                <div class="card_count">
                    <div class="count">
                        <div class="fans">
                            <h3>{driver.phoneNumber}</h3>
                        </div>
                        <div class="following">
                            <h3>{driver.email}</h3>
                        </div>
                    </div> 
                       <div class="post">
                        <h3>{getCarType()}</h3>
                    </div>
                    <div class="UpdateBtn" onClick={(e) => { navigate(`/driver/${driver.userName}/update-profile`) }}>Update</div>
                </div>
            </div>}
        </>
    );

}



