import { ref } from "vue"
import { AlignHeader, HeaderDataTable } from "@/models/swag-api-models"

export const setHeadersDataTable = (array: Array<any>, align = AlignHeader.Start, sortable = false) => {
    const headers = ref<HeaderDataTable[]>([]);
    array.forEach((x) => {
        headers.value.push({
            title: x,
            align: align,
            sortable: sortable,
            key: x,
        })
    })

    return headers.value;
}