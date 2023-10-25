import { ToastType } from "@/models/swag-api-models";
import { defineStore } from "pinia";
import { ref } from "vue";

export const useToastStore = defineStore('toast', () => {
    const titleStored = ref("");
    const messageStored = ref("");
    const showToast = ref(false);
    const typeToast = ref(ToastType.Success);

    const setToastProperties = ({ title = "", message = "", show = false, type = ToastType.Success }) => {
        titleStored.value = title;
        messageStored.value = message;
        showToast.value = show;
        typeToast.value = type;
    }

    const hideToast = () => {
        showToast.value = false;
    }

    return {
        titleStored,
        messageStored,
        showToast,
        typeToast,
        setToastProperties,
        hideToast
    }
})