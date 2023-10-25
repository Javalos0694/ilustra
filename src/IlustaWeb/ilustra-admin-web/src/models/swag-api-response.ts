//AUTH

export interface LoginResponse {
    Username: string,
    token: string
}

//USERS

export interface UserResponse {
    IdUser: number,
    UserType: number,
    Username: string
}

export interface UsersResponse {
    Users: UserResponse[],
    Total: number
}

//PERSON

export interface PersonResponse {
    IdUser: number,
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