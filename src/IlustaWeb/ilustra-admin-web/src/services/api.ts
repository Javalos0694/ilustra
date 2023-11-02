import { paramsApi } from "@/models/swag-api-request"
import { config } from "@/config"
import axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from 'axios'
import router from "@/router"
import { useAuthStore } from "@/store/auth"
import { storeToRefs } from "pinia"
import { useToastStore } from "@/store/toast"
import { ToastMessage, ToastTitle, ToastType } from "@/models/swag-api-models"
import { useLoaderStore } from "@/store/loader"

const authStore = useAuthStore();
const { setStoredValues } = authStore;
const { tokenStored } = storeToRefs(authStore);

const { setToastProperties } = useToastStore();

const { setLoaderState } = useLoaderStore();

const handleToastEvent = (toastType: ToastType, message: string = "") => {
    if (toastType == ToastType.Success) setToastProperties({ message: ToastTitle.Success, type: toastType, show: true })
    if (toastType == ToastType.Info) setToastProperties({ title: ToastTitle.Success, type: ToastType.Success, message: ToastMessage.Saved, show: true })
    if (toastType == ToastType.Error) setToastProperties({ title: ToastTitle.Error, type: toastType, message, show: true })
}

const handlerAxiosEvent = async (axiosConfig: AxiosRequestConfig): Promise<any> => {
    try {
        setLoaderState(true);
        const response = await axios(axiosConfig);
        const data = await response.data;

        if (data.Code && !data.Message) handleToastEvent(ToastType.Success);
        if (data.Code) handleToastEvent(ToastType.Info, data.Message || ToastMessage.Saved);

        return data;
    } catch (error) {
        handleErrorResponse(error);
    } finally {
        setLoaderState(false);
    }
}

const handleErrorResponse = (errorResponse: any) => {
    if (errorResponse instanceof AxiosError) {
        const { response } = errorResponse;
        const data = response?.data;
        if (response?.status === 401) {
            setStoredValues({});
            handleToastEvent(ToastType.Error, data.length > 0 ? data.Message : data)
            router.push({ name: "Login" })
            return;
        }
        if (response?.status === 404 && !data.Message) {
            handleToastEvent(ToastType.Error, "No service found")
            return;
        }
        handleToastEvent(ToastType.Error, data.Message)
        return;
    } else {
        handleToastEvent(ToastType.Error, "Contact with admin");
    }
}

const handleHeadersParams = (params: paramsApi) => {
    if (!params.token) return {}

    const headers = {
        "Authorization": `bearer ${tokenStored.value}`
    }

    return headers;
}


const api = {
    async get<T>(endpoint: string, params: paramsApi = {}) {
        const url = `${config.ApiUrl}${endpoint}${!params.id ? '' : `/${params.id}`}`
        const headers = handleHeadersParams(params);
        const axiosConfig: AxiosRequestConfig = {
            url,
            headers
        }

        const data = await handlerAxiosEvent(axiosConfig);
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

        const dataResponse = await handlerAxiosEvent(axiosConfig);
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

        const dataResponse = await handlerAxiosEvent(axiosConfig);
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

        const data = await handlerAxiosEvent(axiosConfig);
        return data as T;
    }
}

export { api };