import { CategoryRequest, paramsApi } from "@/models/swag-api-request"
import { api } from "./api"
import { CategoriesResponse, CategoryResponse } from "@/models/swag-api-response"

const actions = () => {
    let params: paramsApi = { token: true }

    const clearParams = () => {
        params = { token: true }
    }

    const initCategoryRequest = () => {
        const request: CategoryRequest = {
            IdProductCategory: 0,
            Category: '',
            Description: ''
        }
        return request;
    }

    const getAllCategories = async () => {
        const categories = await api.get<CategoriesResponse>("ProductCategory/categories", params)
        return categories;
    }

    const getCategoryById = async (id: number) => {
        params.id = id;
        const category = await api.get<CategoryResponse>("ProductCategory", params);
        clearParams();
        return category;
    }

    const createCategory = async (request: CategoryRequest) => {
        params.body = request;
        const result = await api.post("ProductCategory/create", params);
        clearParams();
        return result;
    }

    const updateCategory = async (id: number, request: CategoryRequest) => {
        params.id = id;
        params.body = request;
        const result = await api.put("ProductCategory/update", params);
        clearParams();
        return result;
    }

    const deleteCategory = async (id: number) => {
        params.id = id;
        const result = await api.delete("ProductCategory", params);
        clearParams();
        return result;
    }

    return {
        initCategoryRequest,
        getAllCategories,
        getCategoryById,
        createCategory,
        updateCategory,
        deleteCategory
    }
}

const useCategory = () => {
    return { ...actions() }
}

export { useCategory };