import { ProductRequest, paramsApi } from "@/models/swag-api-request"
import { api } from "./api";
import { ProductResponse, ProductsResponse } from "@/models/swag-api-response";

const actions = () => {
    let params: paramsApi = { token: true };

    const initProductRequest = () => {
        const request: ProductRequest = {
            IdProduct: 0,
            BasePrice: 0,
            IsAvailable: false,
            IdProductCategory: 0,
            ProductName: '',
            Description: ''
        }
        return request;
    }

    const clearParams = () => {
        params = { token: true }
    }

    const getProducts = async () => {
        const products = await api.get<ProductsResponse>("Product/products", params);
        return products;
    }

    const getProductById = async (id: number) => {
        params.id = id;
        const product = await api.get<ProductResponse>("Product", params);
        clearParams();
        return product;
    }

    const createProduct = async (request: ProductRequest) => {
        params.body = request;
        const product = await api.post<any>("Product/create", params);
        clearParams();
        return product;
    }

    const updateProductById = async (id: number, request: ProductRequest) => {
        params.id = id;
        params.body = request;

        const product = await api.put("Product/update", params);
        clearParams();
        return product;
    }

    const toogleAvailable = async (id: number) => {
        params.id = id;
        const product = await api.put("Product/update/available", params);
        clearParams();
        return product;
    }

    const deleteProduct = async (id: number) => {
        params.id = id;
        const product = await api.delete("Product", params);
        clearParams();
        return product;
    }

    return {
        initProductRequest,
        getProducts,
        getProductById,
        createProduct,
        updateProductById,
        toogleAvailable,
        deleteProduct
    }
}


const useProduct = () => {
    return { ...actions() }
}

export { useProduct }
