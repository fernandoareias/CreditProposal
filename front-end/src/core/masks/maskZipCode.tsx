export function addZipCodeMask(zipCode: string): string {
    const cleanZipCode = removeZipCodeMask(zipCode);

    if (cleanZipCode.length === 5) {
        return cleanZipCode;
    } else if (cleanZipCode.length >= 6) {
        return cleanZipCode.replace(/(\d{5})(\d{3})/, "$1-$2");
    }
    return zipCode; 
}

export function removeZipCodeMask(zipCode: string): string {
    return zipCode.replace(/\D/g, "");
}