
const initialstate = {}

export const DriverReducer = (state = initialstate, action) => {
    switch (action.type) {
        case "DRIVERSIGHNUP": {
            state = action.payload.driver;
            console.log("Driver ");
            console.log(state);
            return { ...state}

        }
        case "SIGHNINASDRIVER": {
                state = action.payload.driver;
                console.log("state driver");
                console.log(action.payload.driver);
                return { ...state}
            }
      
        }
    return state
};