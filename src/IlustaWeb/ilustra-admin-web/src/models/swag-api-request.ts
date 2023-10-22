//Base
export interface paramsApi {
    id?: number,
    body?: unknown,
    token?: string
}

//Auth
export interface LoginRequest {
    Username: string,
    Password: string
}
