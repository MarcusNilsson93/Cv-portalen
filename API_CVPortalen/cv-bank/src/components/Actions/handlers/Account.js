import { login, register, loggedIn } from '../Api'

const actionType = async (type, data) => {
    const actions = {
        login: login,
       // logout: logout, //not in backend yet. 
        register: register,
        loggedIn: loggedIn, // not in backend yet. 
        default: () => {
            return { status: 501, error: "Requested action does not exist." }
        }
    }
    return (actions[type] || actions.default)(data);
}

const authAction = async (type, onSuccess, data) => {
    try {
        const response = await actionType(type, data);
        if (response.status === 200 || response.status === 201) {
            const result = await response.json();
            if (result.error) {
                console.error("AuthAction result error: ",result.error);
                return;
            }
            localStorage.setItem("userData", JSON.stringify(result));
            onSuccess();
        }
        else if(response.status === 400)
        {
            let res = await response.json();
            if (res.error){
                alert(res.error)
            }
        }

        else
            alert(response.status)
            //throw new Error(response.status);
    } catch (error) {
        console.log(error)
    }
}

export default authAction;