export const getCurrentUser = () => {
    try {
        let userData = JSON.parse(localStorage["userData"])
        if (userData.token){
            return userData
        }
    }
    catch{
        return null
    }
}