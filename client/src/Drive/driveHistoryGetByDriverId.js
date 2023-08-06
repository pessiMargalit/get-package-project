import { React, useEffect,useRef } from "react";
import { useSelector } from "react-redux/es/exports";
import Table from 'react-bootstrap/Table';
import axios from "axios";
import { useState } from "react";
import { DriverNavbar } from "../Driver/driverNavbar";

export const DriveHistoryGetById = () => {
  const baseURL = process.env.REACT_APP_API_URL;
  const urlDriveHistory = `${baseURL}/DriveHistory`;
  const driver_ = useSelector((state) => state.driverReducer);
  const driver = useRef();
  const [drives,setDrives] = useState([]);
  useEffect(() => {
    debugger
    driver.current =driver_;
    const getAllHistoryDrives = async () => {
      await axios.get(`${urlDriveHistory}/${driver.current.driverID}`)
        .then(response => {
          if (response.status>=200 && response.status < 300) {

          console.log(response.data);
          setDrives(response.data);}
          console.log(drives.length);
        })
        .catch(error => {
          console.log(error);
        });
        
    }
    getAllHistoryDrives();
  }, [],driver_)

  return (
    <>
    <DriverNavbar/>
<h1 style={{margin:"5vh"}}>Drives history </h1>  
  {driver.current != null &&<div>
      {drives.length > 0 &&
        <Table striped bordered hover size="sm">
          <thead>
            <tr>
              <th>Source</th>
              <th>Destination</th>
              <th>Date Time</th>
            </tr>
          </thead>
          <tbody>
            {drives.map((drive, index) => (
              <tr key={index}>
                <td>{drive.source.city}</td>
                <td>{drive.destination.city}</td>
                <td>{drive.dateTime}</td>
              </tr>
            ))}
          </tbody>
        </Table>}
      {drives.length === 0 &&
        <p>no drives in history</p>
      }
      </div>}
    </>
  );
}




