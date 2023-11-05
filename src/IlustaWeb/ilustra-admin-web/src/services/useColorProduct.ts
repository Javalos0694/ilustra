import { ColorProductRequest, paramsApi } from "@/models/swag-api-request"
import { api } from "./api"
import { ColorsResponse } from "@/models/swag-api-response"

const actions = () => {
    let params: paramsApi = { token: true }

    const clearParams = () => params = { token: true }

    const initColorProductRequest = () => {
        const request: ColorProductRequest = {
            Colors: [],
            IdProduct: 0
        }
        return request;
    }

    const createColorByProduct = async (request: ColorProductRequest) => {
        params.body = request;
        const result = await api.post("ColorProduct/create", params);
        clearParams();
        return result;
    }

    const getColorsByProduct = async (id: number) => {
        params.id = id;
        const colors = await api.get<ColorsResponse>("ColorProduct", params);
        clearParams();
        return colors;
    }

    return {
        initColorProductRequest,
        createColorByProduct,
        getColorsByProduct
    }
}


const useColorProduct = () => {
    return { ...actions() }
}

export { useColorProduct }