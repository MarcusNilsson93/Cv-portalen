import { login, register, loggedIn } from '../Api'

const actionType = async (type, data) => {
    const actions = {
        login: login,
       // logout: logout, //not in backend yet. 
        register: register,
        loggedin: loggedIn, // not in backend yet. 
        default: () => {
            return { status: 501, error: "Requested action does not exist." }
        }
    }
    return (actions[type] || actions.default)(data);
}

const authAction = async (type, onSuccess, data) => {
    console.log(data);
    console.log(type);
    try {
        const response = await actionType(type, data);
        if (response.status === 200 || response.status === 201) {
            const result = await response.json();
            if (result.error) {
                alert(result.error);
                return;
            }
            console.log("old", localStorage["userData"], "new", result);
            localStorage.setItem("userData", JSON.stringify(result));
            onSuccess();
        }
        else
            throw new Error(response.status);
    } catch (error) {
        alert(error);
    }
}

export default authAction;