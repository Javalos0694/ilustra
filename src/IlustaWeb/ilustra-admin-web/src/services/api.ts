import { paramsApi } from "@/models/swag-api-request"
import { config } from "@/config"
import axios, { AxiosRequestConfig, AxiosResponse } from 'axios'
import router from "@/router"
import { useAuthStore } from "@/store/auth"
import { storeToRefs } from "pinia"

const authStore = useAuthStore();
const { tokenStored } = storeToRefs(authStore);


const handleResponse = async (response: AxiosResponse) => {
    const data = await response.data;
    if (response.status === 401) {
        router.push({ name: "Login" })
        throw new Error("Unauthorized")
    }

    if (response.status !== 401 && response.status !== 200) {
        const error = (data && data.Message) || response.statusText;
        throw new Error(error);
    }
    return data;
}

const handleHeadersParams = (params: paramsApi) => {
    if (!params.token) return {}

    const headers = {
        "Authorization": `Bearer ${tokenStored}`
    }

    return headers;
}


const api = {
    async get<T>(endpoint: string, params: paramsApi = {}) {
        const url = `${config.ApiUrl}${endpoint}${!params.id ? '0' : `/${params.id}`}`
        const headers = handleHeadersParams(params);
        const axiosConfig: AxiosRequestConfig = {
            url,
            headers
        }

        const response = await axios(axiosConfig);
        const data = await handleResponse(response);
        return data as T;
    },

    async post<T>(endpoint: string, params: paramsApi = {}) {
        const url = `${config.ApiUrl}${endpoint}`;
        const headers = handleHeadersParams(params);
        const data = params.body ?? {};
        const axiosConfig: AxiosRequestConfig = {
            url,
            data,
            method: "post",
            headers
        };

        const response = await axios(axiosConfig);
        const dataResponse = await handleResponse(response);
        return dataResponse as T;
    },

    async put<T>(endpoint: string, params: paramsApi = {}) {
        const url = `${config.ApiUrl}${endpoint}${!params.id ? '0' : `/${params.id}`}`
        const data = params.body ?? {};
        const headers = handleHeadersParams(params);

        const axiosConfig: AxiosRequestConfig = {
            url,
            data,
            method: "put",
            headers
        }

        const response = await axios(axiosConfig);
        const dataResponse = await handleResponse(response);
        return dataResponse as T;
    },
    async delete<T>(endpoint: string, params: paramsApi = {}) {
        const url = `${config.ApiUrl}${endpoint}/${params.id ?? 0}`;
        const headers = handleHeadersParams(params);
        const axiosConfig: AxiosRequestConfig = {
            url,
            method: "delete",
            headers
        }

        const response = await axios(axiosConfig);
        const data = await handleResponse(response);
        return data as T;
    }
}

export { api };