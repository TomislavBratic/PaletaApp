export interface RegistrationRequest {
    UserName:string,
    FirstName:string,
    LastName:string,
    Email:string,
    Password:string
}

export interface LoginRequest {
    UserName:string,
    Password:string
}