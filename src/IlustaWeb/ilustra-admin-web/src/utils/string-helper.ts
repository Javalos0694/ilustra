export const CapitalizeFirstLetter = (word: string) => {
    return word.charAt(0).toUpperCase() + word.slice(1);
}

export const FormatDateString = (date: string) => {
    if (date.includes("T")) {
        const stringDate = date.slice(0, date.indexOf("T")).toString();
        return stringDate
    }
    return date;
}
