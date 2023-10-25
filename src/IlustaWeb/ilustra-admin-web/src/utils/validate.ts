const validateEmailFormat = (email: string) => {
    const pattern = "^[\w\.-]+@[\w\.-]+\.\w+$";
    const regx = new RegExp(pattern);
    return regx.test(email)
}

export const ValidateInput = (v?: string, label?: string, len?: number) => {
    if (!v) return `${label ? `${label}` : 'This camp'} is required`
    if (len && v.length != len) return `${label} must be ${len} characters`
    if (label && label.toLowerCase() == 'email') {
        if (!validateEmailFormat(v)) return 'Invalid format for email'
    }
    return ""
}

