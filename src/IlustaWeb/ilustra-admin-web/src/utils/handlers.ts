import { AxiosError } from "axios"
import { Error } from "@/models/swag-api-models"

export const handlerError = (error: any): Error => {
    if (error instanceof AxiosError) {
        const data = error.response?.data;
        return { Code: data.Code, Message: data.Message } as Error;
    }
    return {} as Error;
}
