export const formatNumberWithComma = (number: number | undefined) => {
    return number ? number.toLocaleString() : 0;
}

export const formatInputNumber = (number?: string) => {
    if(number){
        let value = number;
    
        value = value.replace(/[^0-9.]/g, '');
        value = value.replace(/,/g, '');
    
        return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }
    return '';
}
