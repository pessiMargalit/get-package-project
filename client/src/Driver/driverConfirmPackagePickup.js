import { useSearchParams } from "react-router-dom";
import axios from "axios";
import { useState, useRef, useEffect } from "react";
import { PackagePut } from "../Package/packagePut";
import { PackageGetById } from "../Package/packageGetById";
import { useSelector, useDispatch } from "react-redux";
import { addPackage } from "../redux/actions/packageActions";
import { DriverModelSighnIn } from "./DriverModelsighnIn";


export const DriverConfirmPackagePickup = () => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlPackage = `${baseURL}/Package`;

    const dispatch = useDispatch();
    const [searchParams, setSearchParams] = useSearchParams();
    const myResponse = useRef({});
    // const package_ = useSelector((state) => state.packageReducer);
    const driver = useSelector((state) => state.driverReducer);
    const [b, setB] = useState();
    const [showPackageDetails, setShowPackageDetails] = useState(false);
    let packageId;
    packageId = searchParams.get("subject");
    
    useEffect(() => {
        console.log(driver); 
        const get = async () => {
            await axios.get(`${urlPackage}/${packageId}`).then((response) => {
                if (response.status < 300) {
                    debugger
                    myResponse.current = response.data[0];
                     console.log("myResponse",myResponse.current);
                    setShowPackageDetails(true);
                    // dispatch(addPackage(myResponse.current))
                }
                else {
                    console.log(`error ${response.status}`);
                }
            }).catch(error => {
                console.log(error);
            });
        }
         get();
    }, driver);



    const handleClick = () => {
        debugger
        if (!myResponse.current.onTheWay) {
            myResponse.current.onTheWay = true;
            myResponse.current.driverId = driver.driverID;
            myResponse.current.driveId = driver.drives
                .filter((d) => d.source.city === myResponse.current.source.city && d.destination.city === myResponse.current.destination.city)[0]._Id;
            // dispatch(addPackage(myResponse.current))
            setB(true);
        }
        else {
            setB(false);
        }
    };

    return (
        <>
            <DriverModelSighnIn />
            {showPackageDetails === true &&
                <PackageGetById package={myResponse.current._Id}></PackageGetById>
            }
            {b === true &&
                <PackagePut package={myResponse.current}></PackagePut>
            }
            {b === true && <p>The package detailes were sent to your email.....</p>}
            {b === false && <p>Sorry...<br /> The package was taken by another driver.</p>}
            <button onClick={handleClick}>Confirm package pickup</button>
        </>
    );
}