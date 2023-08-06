import { combineReducers } from "redux";
import { ClientReducer } from "./clientReducer";
import { DriverReducer } from "./driverReducer";

export const allReducers = combineReducers(
    {
        clientReducer:ClientReducer,
        driverReducer:DriverReducer,
    }
);