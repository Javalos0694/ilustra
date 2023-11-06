import { DimensionProductRequest, paramsApi } from "@/models/swag-api-request"
import { api } from "./api"
import { DimensionsResponse } from "@/models/swag-api-response"

const actions = () => {
    let params: paramsApi = { token: true }
    const clearParams = () => {
        params = { token: true }
    }

    const initDimensionProductRequest = () => {
        const request: DimensionProductRequest = {
            Dimensions: [],
            IdProduct: 0
        }
        return request;
    }

    const getDimensionsByProduct = async (idProduct: number) => {
        params.id = idProduct;
        const dimensions = await api.get<DimensionsResponse>("DimensionProduct", params);
        clearParams();
        return dimensions;
    }

    const associateDimensionsByProduct = async (request: DimensionProductRequest) => {
        params.body = request;
        const result = await api.post("DimensionProduct/create", params);
        clearParams();
        return result;
    }

    return {
        initDimensionProductRequest,
        getDimensionsByProduct,
        associateDimensionsByProduct
    }
}

const useDimensionProduct = () => {
    return { ...actions() }
}

export { useDimensionProduct }