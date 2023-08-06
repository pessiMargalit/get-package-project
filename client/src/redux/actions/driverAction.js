export const driverSighnUp = (driver) => {
    return{
        type: "DRIVERSIGHNUP",
        payload:{driver},
    };
};
export const driverSighnIn = (driver) => {
    return{
        type: "SIGHNINASDRIVER",
        payload:{driver},
    };
};
