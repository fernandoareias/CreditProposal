export const setMaskCellphone = (value: string): string => {
    if (!value) return value;
  
    const phoneNumber = value.replace(/[^\d]/g, ''); // Remove todos os caracteres não numéricos
    const phoneNumberLength = phoneNumber.length;
  
    if (phoneNumberLength <= 2) {
      return `(${phoneNumber}`;
    }
  
    if (phoneNumberLength <= 7) {
      return `(${phoneNumber.slice(0, 2)}) ${phoneNumber.slice(2)}`;
    }
  
    if (phoneNumberLength <= 11) {
      return `(${phoneNumber.slice(0, 2)}) ${phoneNumber.slice(2, 7)}-${phoneNumber.slice(7)}`;
    }
  
    return `(${phoneNumber.slice(0, 2)}) ${phoneNumber.slice(2, 7)}-${phoneNumber.slice(7, 11)}`;
  };


export const removeMaskCellphone = (value: string): string => {
    return value.replace(/[^\d]/g, ''); // Remove todos os caracteres não numéricos
};
  