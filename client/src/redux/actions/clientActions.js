export const clientSighnUp = (client) => {
    return{
        type: "CLIENTSIGHNUP",
        payload:{client},
    };
};

export const clientSighnIn = (client) => {
    return{
        type: "SIGHNIN",
        payload:{client},
    };
};
export const clientAddPackage = (package_) => {
    return{
        type: "ADDPACKAGE",
        payload:{package_},
    };
};