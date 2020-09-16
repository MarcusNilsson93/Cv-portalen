import axios from 'axios'

const baseHeaders = () => {
    let headers = {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }
    if (localStorage["userData"]) {
        headers.Authorization = 'Bearer ' + JSON.parse(localStorage["userData"]).token;
    }
    console.log("authheaders: ", headers);
    return headers;
}
const apiUrl = "https://localhost:5001/"

export const login = async user => axios.post(apiUrl +"api/user/authenticate", user,{
    headers: baseHeaders(),
    credentials: 'include',
    //body: JSON.stringify(user)
});
export const register = async user => axios.post(apiUrl +"api/user/register", user,{
    headers: baseHeaders(),
    credentials: 'include',
});

// export const logout = async () => fetch("api/account/logout", {
//     headers: baseHeaders(),
//     method: 'post',
//     credentials: 'include'
// });

//For all items
export const get = async (controller) => axios.get(apiUrl +"api/" + controller, {
    headers: baseHeaders(),
    credentials: 'include'
});

export const put = async (controller, id, data) => axios.put(apiUrl +"api/" + controller + '/' + id, data,{
    headers: baseHeaders(),
    credentials: 'include',
});

export const remove = async (controller, obj) => axios.delete(apiUrl +"api/" + controller + obj.id, {
    headers: baseHeaders(),
    credentials: 'include'
});

export const post = async (controller, obj) => axios.post(apiUrl +"api/" + controller,obj, {
    headers: baseHeaders(),
    credentials: 'include',
});


//not implemented in backend.
export const loggedIn = async () => {
    const response = await fetch(apiUrl +"api/account/loggedin", {
        headers: baseHeaders(),
        method: 'get',
        credentials: 'include'
    })
        .catch(error => error.status);
    switch (response.status) {
        case 200:
            console.log();
            return true;
        default:
            console.log(response);
            return false;
    }
};