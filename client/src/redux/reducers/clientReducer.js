
const initialstate = {}

export const ClientReducer = (state = initialstate, action) => {
    switch (action.type) {
        case "CLIENTSIGHNUP": {
            state = action.payload.client;
            console.log(state);
            return { ...state}

        }
        case "SIGHNIN": {
            state = action.payload.client;
            console.log("state client");
            console.log(state);
            return { ...state}
        }
        case "ADDPACKAGE": {
            debugger
            console.log("state");
            console.log(state);
            state.packages.push(action.payload.package_);
        }
       
    }
    return state
};