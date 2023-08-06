export const addPackage = (package_) => {
    return{
        type: "ADDPACKAGE",
        payload:{package_},
    };
};
