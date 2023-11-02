import { ProductRequest, paramsApi } from "@/models/swag-api-request"
import { api } from "./api";
import { ProductResponse, ProductsResponse } from "@/models/swag-api-response";

const actions = () => {
    let params: paramsApi = { token: true };

    const initProductRequest = () => {
        const request: ProductRequest = {
            BasePrice: 0,
            IsAvailable: false,
            ProductCategory: 0,
            ProductName: '',
            Description: ''
        }
        return request;
    }

    const getProducts = async () => {
        const products = await api.get<ProductsResponse>("Product/products", params);
        return products;
    }

    const getProductById = async (id: number) => {
        params.id = id;
        const product = await api.get<ProductResponse>("Product", params);
        return product;
    }

    const createProduct = async (request: ProductRequest) => {
        params.body = request;
        const product = await api.post("Product/create", params);
        return product;
    }

    const updateProductById = async (id: number, request: ProductRequest) => {
        params.id = id;
        params.body = request;

        const product = await api.put("Product/update", params);
        return product;
    }

    const toogleAvailable = async (id: number) => {
        params.id = id;

        const product = await api.put("Product/update/available", params);
        return product;
    }

    const deleteProduct = async (id: number) => {
        params.id = id;

        const product = await api.delete("Product", params);
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
