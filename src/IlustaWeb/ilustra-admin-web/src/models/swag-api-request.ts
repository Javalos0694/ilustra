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

//PRODUCT
export interface ProductRequest {
    ProductCategory: number,
    ProductName: string,
    Description?: string,
    BasePrice: number,
    IsAvailable: boolean
}

//COLOR
export interface ColorRequest {
    IdColor: number,
    ColorName: string,
    ColorCode?: string,
    BasePrice: number,
    IsAvailable: boolean
}

//CATEGORY

export interface CategoryRequest {
    IdProductCategory: number,
    Category: string,
    Description: string
}

//DIMENSION

export interface DimensionRequest {
    IdDimension: number,
    DimensionName: string,
    DimensionCode: string,
    BasePrice: number,
    IsAvailable: boolean
}