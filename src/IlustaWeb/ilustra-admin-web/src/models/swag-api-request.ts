//Base
export interface paramsApi {
    id?: number,
    body?: unknown,
    token?: boolean
}

//Auth
export interface LoginRequest {
    Username: string,
    Password: string
}

//User
export interface UpdatePersonRequest {
    UserType: number,
    Username: string,
    FirstName: string,
    LastName: string,
    DocumentType: number,
    DocumentNumber: string,
    Email: string,
    Address: string,
    BornDate: string,
    PhoneNumber: string,
}
