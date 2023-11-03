import { DimensionRequest, paramsApi } from "@/models/swag-api-request"
import { api } from "./api"
import { DimensionResponse, DimensionsResponse } from "@/models/swag-api-response"

const actions = () => {
    let params: paramsApi = { token: true }

    const clearParams = () => {
        params = { token: true };
    }

    const initDimensionRequest = () => {
        const request: DimensionRequest = {
            BasePrice: 0,
            DimensionCode: '',
            IdDimension: 0,
            DimensionName: '',
            IsAvailable: false
        }
        return request;
    }

    const getAllDimensions = async () => {
        const dimensions = await api.get<DimensionsResponse>("Dimension/dimensions", params)
        return dimensions;
    }

    const getDimensionById = async (id: number) => {
        params.id = id;
        const dimension = await api.get<DimensionResponse>("Dimension/dimension", params)
        clearParams();
        return dimension;
    }

    const createDimension = async (request: DimensionRequest) => {
        params.body = request;
        const result = await api.post("Dimension/create", params);
        clearParams();
        return result;
    }

    const updateDimension = async (id: number, request: DimensionRequest) => {
        params.id = id;
        params.body = request;
        const result = await api.put("Dimension/update", params);
        clearParams();
        return result;
    }

    const toogleAvailableDimension = async (id: number) => {
        params.id = id;
        const result = await api.put("Dimension/toogleAvailable", params);
        clearParams();
        return result;
    }

    const deleteDimension = async (id: number) => {
        params.id = id;
        const result = await api.delete("Dimension", params);
        return result;
    }

    return {
        initDimensionRequest,
        getAllDimensions,
        getDimensionById,
        createDimension,
        updateDimension,
        toogleAvailableDimension,
        deleteDimension
    }
}


const useDimension = () => {
    return { ...actions() }
}

export { useDimension }