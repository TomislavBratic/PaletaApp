export interface RegistrationRequest {
    username:string,
    firstname:string,
    lastname:string,
    email:string,
    password:string
}

export interface LoginRequest {
    username:string,
    password:string
}

export interface User {
    username:string,
    token:string
}