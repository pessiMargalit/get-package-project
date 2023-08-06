import axios from "axios";
import { React, useState, useEffect } from "react";
// import { urlPackage } from  "../endpoints";
import { useDispatch } from "react-redux";
import { addPackage } from "../redux/actions/packageActions";
import Table from "react-bootstrap/esm/Table";

export const PackageGetById = (props) => {
    const baseURL = process.env.REACT_APP_API_URL;
    const urlPackage = `${baseURL}/Package`;

    const dispatch = useDispatch();
    const [id, setId] = useState("");
    const [myResponse, setMyResponse] = useState(null);
    useEffect(() => {
        debugger
        const get = async () => {
            setId(props.package);
            debugger
            await axios.get(`${urlPackage}/${props.package}`).then((response) => {
                if (response.status < 300) {
                    setMyResponse(response.data[0]);
                    dispatch(addPackage(myResponse))
                }
                else {
                    console.log(`error ${response.status}`);
                }
            }).catch(error => {
                console.log(error);
            });
        }
        get()
    }, []);

    return (
        <>
            {myResponse !== null && <Table striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>Package details</th>
                    </tr>
                </thead>
                <tbody>
                    <th>Source</th>
                    <tr>
                        <td>City: {myResponse.source.city}</td>
                    </tr>
                    <tr>
                        <td>Street: {myResponse.source.street}</td>
                    </tr>
                    <tr>
                        <td>House number: {myResponse.source.houseNumber}</td>
                    </tr>
                    <th>Destination</th>
                    <tr>
                        <td>City: {myResponse.destination.city}</td>
                    </tr>
                    <tr>
                        <td>Street: {myResponse.destination.street}</td>
                    </tr>
                    <tr>
                        <td>House number: {myResponse.destination.houseNumber}</td>
                    </tr>

                    <th>Size</th>
                    <tr > <td>Width: {myResponse.size.width} cm, Hight: {myResponse.size.hight} cm,
                    Weight: {myResponse.size.weight} kg</td></tr>
                    {/* <tr> <td>Hight: {myResponse.size.hight} cm</td></tr> */}

                    {/* <tr><td>{myResponse.size.weight} kg</td></tr> */}
                    
                    <tr >

                        <td>Price: {myResponse.price}</td>
                    </tr>
                </tbody>
            </Table>}

        </>
        // <div>
        //      {JSON.stringify(myResponse)}
        // </div>
    );
}
