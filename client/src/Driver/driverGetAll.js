import axios from "axios";
import { useEffect, useState } from "react";
// import { urlDriver } from "../endpoints";

export function DriverGetAll() {

    const baseURL = process.env.REACT_APP_API_URL;
    const urlDriver = `${baseURL}/Driver`;
    const [myResponse, setMyResponse] = useState();
    useEffect(() => {
        const getAll = async () => {
            await axios.get(urlDriver).then((response) => {
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
            <h1>Drivers:</h1>
            <div>{myResponse.map(e =>
                <>
                    <div>
                        <p>driver</p>
                        {e.id},
                        <br></br>
                        {e.firstName},
                        {e.lastName},
                        <br></br>
                         <p>Drives:</p>
                         
                        {e.drives.map(d =>
                            <>
                           <p>drive:  {d._Id}</p> 
                                
                                <br></br>
                                <p>Packages:</p>
                                {d.packages.map(p =>
                                    <>
                                    {p._Id}
                                    </>
                                    )}
                            </>
                            )}
                         
                    </div>

                    <br></br>
                </>
            )}
            </div>
        </div>
    );
  
}