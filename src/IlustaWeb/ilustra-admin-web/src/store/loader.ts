import { defineStore } from "pinia";
import { ref } from "vue";

export const useLoaderStore = defineStore('loader', () => {
    const showLoader = ref(false);

    const setLoaderState = (state: boolean) => {
        showLoader.value = state;
    }

    return {
        showLoader,
        setLoaderState
    }
})