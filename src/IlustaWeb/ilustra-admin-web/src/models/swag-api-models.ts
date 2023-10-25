//Toast
export enum ToastType {
    Success = "success",
    Warning = "warning",
    Info = "info",
    Error = "error"
}

export enum ToastIconType {
    Success = "$success",
    Warning = "$warning",
    Info = "$info",
    Error = "$error"
}

export enum ToastTitle {
    Success = "Success",
    Saved = "Saved",
    Error = "Error"
}

export enum ToastMessage {
    Success = "Success",
    Saved = "Changes saved"
}

//Error

export interface Error {
    Code: number,
    Message: string,
}

//Data-table

export enum AlignHeader {
    Start = "start",
    End = "end",
    Center = "center"
}

export interface HeaderDataTable {
    title: string,
    align: AlignHeader,
    sortable: boolean,
    key: string
}
