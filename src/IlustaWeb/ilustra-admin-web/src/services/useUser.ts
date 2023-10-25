import { paramsApi } from "@/models/swag-api-request";
import { api } from "./api";
import { UpdatePersonRequest } from "@/models/swag-api-request";
import { PersonResponse, UsersResponse } from "@/models/swag-api-response";

const actions = () => {
    let params: paramsApi = { token: true }

    const initUpdateUserRequest = () => {
        const initUserRequest: UpdatePersonRequest = {
            Address: "",
            BornDate: "",
            DocumentNumber: "",
            DocumentType: 0,
            Email: "",
            FirstName: "",
            LastName: "",
            PhoneNumber: "",
            Username: "",
            UserType: 0
        }
        return initUserRequest;
    }

    const getUsers = async () => {
        const users = await api.get<UsersResponse>("User/users", params)
        return users;
    }

    const getUserAccount = async () => {
        const user = await api.get<PersonResponse>("User/account", params);
        return user;
    }

    const getUserById = async (id: number) => {
        params.id = id;
        const user = await api.get<PersonResponse>("User", params);
        return user;
    }

    const putUserById = async (id: number, request: UpdatePersonRequest) => {
        params.id = id;
        params.body = request;
        const result = await api.put("User/update", params);
        return result;
    }

    return {
        initUpdateUserRequest,
        getUsers,
        getUserAccount,
        getUserById,
        putUserById
    }
}

const useUser = () => {
    return { ...actions() }
}

export { useUser };


