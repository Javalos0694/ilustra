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

//PRODUCT
export interface ProductResponse {
    IdProduct: number,
    IdProductCategory: number,
    ProductName: string,
    Description: string,
    BasePrice: number,
    IsAvailable: boolean
}

export interface ProductsResponse {
    Products: ProductResponse[],
    Total: number
}

//COLOR
export interface ColorResponse {
    IdColor: number,
    ColorName: string,
    ColorCode: string,
    BasePrice: number,
    IsAvailable: boolean
}

export interface ColorsResponse {
    Colors: ColorResponse[],
    Total: number
}

//CATEGORY

export interface CategoriesResponse {
    Categories: CategoryResponse[],
    Total: number
}

export interface CategoryResponse {
    IdProductCategory: number,
    Category: string,
    Description?: string
}

//DIMENSION

export interface DimensionsResponse {
    Dimensions: DimensionResponse[],
    Total: number
}

export interface DimensionResponse {
    IdDimension: number,
    DimensionName: string,
    DimensionCode: string,
    BasePrice: number,
    IsAvailable: boolean
}