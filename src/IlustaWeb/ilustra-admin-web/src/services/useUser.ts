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

    const clearParams = () => {
        params = { token: true }
    }

    const getUsers = async () => {
        const users = await api.get<UsersResponse>("User/users", params)
        clearParams();
        return users;
    }

    const getUserAccount = async () => {
        const user = await api.get<PersonResponse>("User/account", params);
        clearParams();
        return user;
    }

    const getUserById = async (id: number) => {
        params.id = id;
        const user = await api.get<PersonResponse>("User", params);
        clearParams();
        return user;
    }

    const putUserById = async (id: number, request: UpdatePersonRequest) => {
        params.id = id;
        params.body = request;
        const result = await api.put("User/update", params);
        clearParams();
        return result;
    }

    const deleteUser = async (id: number) => {
        params.id = id;
        const result = await api.delete("User/delete", params);
        clearParams();
        return result;
    }

    return {
        initUpdateUserRequest,
        getUsers,
        getUserAccount,
        getUserById,
        putUserById,
        deleteUser
    }
}

const useUser = () => {
    return { ...actions() }
}

export { useUser };


