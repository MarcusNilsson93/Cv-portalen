import {get, post, put, remove} from "@/components/Actions/Api";

const controller= "programme/"
export async function getAll(){
    const json = await get(controller).then(res => res.json())
    let result = []
    for (var entry in json){
        result.push(new Programme(json[entry]))
    }
    return result
}
export async function getById(id){
    let response = await get(controller + id).then(res => res.json());
    return new Programme(response)
}
export async function Remove(id =Number){
    await remove("programme", id).then(response => {
        handleResponse(response)
        }
    ).catch(err => handleResponse(err))
}
export async function Add(programme){
    await post("programme", programme).then(response => handleResponse(response))
}
export async function Update(id, programme){
    await put("programme", id, programme)
}
function handleResponse(response){
    if (response.status === 200 || response.status === 201)
        return response.json()
    else if (response.status === 404)
        alert("No programme with that id was found.")
    else if(response.status === 401)
        alert("You're not allowed to preform this action.");
    else
        alert("Server responded: " + response.status)
}
class Programme{
    name;
    id;
    category;
    start;
    end;
    enrolled;
    students;
    constructor(data) {
        Object.assign(this, data);
    }
    async loadStudents(){
        this.students = await get(controller + this.id).then(res => res.json());
        return this.students;
    }
    // static fromJson(obj) {
    //     return  $.extend(new Programme, obj);   
    // }
}