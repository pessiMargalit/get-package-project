import { React, useEffect, useRef, useState } from "react";
import { useSelector } from "react-redux";
import Table from 'react-bootstrap/Table';
import axios from "axios";
import { ClientNavbar } from "./clientNavbar";

export const PackageHistoryGetByClientId = () => {
  const baseURL = process.env.REACT_APP_API_URL;
  const urlPackagHistry = `${baseURL}/PackageHistory`;
  const client = useSelector((state) => state.clientReducer);
  const [packages,setPackages] = useState({});

  useEffect(() => {
    const getAllHistoryPackages = async () => {
      await axios.get(`${urlPackagHistry}/${client.id}`)
        .then(response => {
          if (response.status>=200 && response.status < 300) {
          console.log(response.data);
          setPackages(response.data);
        }        
        })
        .catch(error => {
          console.log(error);
        });
    }
    getAllHistoryPackages();
  },[],client)

  return (
    <>
    <ClientNavbar/>
    <h1 style={{margin:"5vh"}}>Packages history </h1>  

      {packages.length > 0 &&
        <Table striped bordered hover size="sm">
          <thead>
            <tr>
              <th>Source</th>
              <th>Destination</th>
              <th>Date Time</th>
            </tr>
          </thead>
          <tbody>
            {packages.map((p, index) => (
              <tr key={index}>
                <td>{p.source.city}</td>
                <td>{p.destination.city}</td>
                <td>{p.dateTime}</td>
              </tr>
            ))}
          </tbody>
        </Table>}
      {packages.length === 0 &&
        <h4>no packages in history</h4>
      }
    </>
  );
}




