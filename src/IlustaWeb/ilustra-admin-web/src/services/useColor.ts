import { ColorRequest, paramsApi } from "@/models/swag-api-request"
import { api } from "./api"
import { ColorResponse, ColorsResponse } from "@/models/swag-api-response"

const actions = () => {
    let params: paramsApi = { token: true }

    const initColorRequest = () => {
        const request: ColorRequest = {
            IdColor: 0,
            BasePrice: 0,
            ColorName: '',
            IsAvailable: false,
            ColorCode: ''
        }
        return request;
    }

    const clearParams = () => {
        params = { token: true }
    }

    const getColors = async () => {
        const colors = await api.get<ColorsResponse>("Color", params);
        clearParams();
        return colors;
    }

    const getColorById = async (id: number) => {
        params.id = id;
        const color = await api.get<ColorResponse>("Color/color", params);
        clearParams();
        return color;
    }

    const createColor = async (request: ColorRequest) => {
        params.body = request;
        const color = await api.post("Color/create", params);
        clearParams();
        return color;
    }

    const updateColor = async (id: number, request: ColorRequest) => {
        params.id = id;
        params.body = request;

        const color = await api.put("Color/update", params);
        clearParams();
        return color;
    }

    const toogleAvailable = async (id: number) => {
        params.id = id;
        const color = await api.put("Color/color", params);
        clearParams();
        return color;
    }

    const deleteColor = async (id: number) => {
        params.id = id;
        const color = await api.delete("Color/color", params);
        clearParams();
        return color;
    }

    return {
        initColorRequest,
        getColors,
        getColorById,
        createColor,
        updateColor,
        toogleAvailable,
        deleteColor
    }
}


const useColor = () => {
    return { ...actions() }
}

export { useColor }