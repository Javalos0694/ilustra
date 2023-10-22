import { LoginRequest, paramsApi } from '@/models/swag-api-request'
import { api } from './api'
import { LoginResponse } from '@/models/swag-api-response'

const actions = () => {
    const login = async (body: LoginRequest) => {
        const params: paramsApi = {
            body
        };
        const user = await api.post<LoginResponse>("auth/login", params);
        return user;
    }

    return {
        login
    }
}


const useAuth = () => {
    return { ...actions() };
}

export { useAuth }