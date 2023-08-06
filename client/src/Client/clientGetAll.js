import axios from "axios";
import { React, useEffect, useState } from "react";
// import { urlClient } from "../endpoints"
export function ClientGetAll() {

    const baseURL = process.env.REACT_APP_API_URL;
    const urlClient = `${baseURL}/Client`;

    const [myResponse, setMyResponse] = useState();
    useEffect(() => {
        const getAll = async () => {
            await axios.get(urlClient).then((response) => {
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
            <h1>Clients:</h1>
            <div>{myResponse.map(e =>
                <>
                    <div>
                        {e.id},
                        <br></br>
                        {e.firstName},
                        {e.lastName},
                        <br></br>
                        <p>packages:</p>
                        {e.packages.map(p =>
                            <p>{p._Id}</p>
                        )}
                    </div>

                    <br></br>
                </>
            )}
            </div>
        </div>
    );
}