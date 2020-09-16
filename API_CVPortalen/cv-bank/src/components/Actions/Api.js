
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

export const login = async user => fetch(apiUrl+"api/user/authenticate", {
    headers: baseHeaders(),
    method: 'post',
    credentials: 'include',
    body: JSON.stringify(user)
});
export const register = async user => fetch(apiUrl+"api/account/register", {
    headers: baseHeaders(),
    method: 'post',
    credentials: 'include',
    body: JSON.stringify(user)
});

export const logout = async () => fetch(apiUrl+"api/account/logout", {
    headers: baseHeaders(),
    method: 'post',
    credentials: 'include'
});

//For all items
export const get = async (controller) => fetch(apiUrl+"api/" + controller, {
    headers: baseHeaders(),
    method: 'get',
    credentials: 'include'
});

export const put = async (controller, id, obj) => fetch(apiUrl+"api/" + controller + '/' + id, {
    headers: baseHeaders(),
    method: 'put',
    credentials: 'include',
    body: JSON.stringify(obj)
});

export const remove = async (controller, obj) => fetch(apiUrl+"api/" + controller + obj.id, {
    headers: baseHeaders(),
    method: 'delete',
    credentials: 'include'
});

export const post = async (controller, obj) => fetch(apiUrl+"api/" + controller, {
    headers: baseHeaders(),
    method: 'post',
    credentials: 'include',
    body: JSON.stringify(obj)
});



//not implemented in backend.
export const loggedIn = async () => {
    const response = await fetch(apiUrl +"api/user/loggedin", {
        headers: baseHeaders(),
        method: 'get',
        credentials: 'include'
    })
    switch (response.status) {
        case 200:
            return true;
        default:
            return false;
    }
};