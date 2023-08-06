import axios from "axios";
import { React, useEffect, useState } from "react";
// import { urlDrive } from "../endpoints"
export function DriveGetAll() {

    const baseURL = process.env.REACT_APP_API_URL;
    const urlDrive = `${baseURL}/Drive`;

    const [myResponse, setMyResponse] = useState();
    useEffect(() => {
        const getAll = async () => {
            await axios.get(urlDrive).then((response) => {
                if (response.status < 300) {
                    setMyResponse(response.data);
                    console.log(response.data);
                }
                else {
                    console.log(`error ${response.status}`);
                }
            }).catch(error => {
                console.log(error);
            });
        }
        getAll()
    }, []);

    if (!myResponse) return null;

    return (
        <div>
            <h1>Drives:</h1>
            <div>{myResponse.map(e =>
                <>
                    <div>
                        {e._Id},
                        <br></br>
                        {e.source.city},
                        {e.destination.city},
                        <br></br>
                       
                    </div>

                    <br></br>
                </>
            )}
            </div>
        </div>
    );
}