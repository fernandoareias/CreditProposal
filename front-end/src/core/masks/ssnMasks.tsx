export const applySSNMask = (value: string): string => {
  const digits = value.replace(/\D/g, ''); // Remove caracteres não numéricos
  const length = digits.length;

  if (length <= 3) return digits;
  if (length <= 5) return `${digits.slice(0, 3)}-${digits.slice(3)}`;
  return `${digits.slice(0, 3)}-${digits.slice(3, 5)}-${digits.slice(5, 9)}`;
};
  /**
   * Remove a máscara de SSN de uma string formatada como SSN.
   * @param maskedSSN - String formatada como SSN (XXX-XX-XXXX).
   * @returns String de 9 dígitos.
   */
export const removeSSNMask = (maskedSSN: string): string => {
    return maskedSSN.replace(/-/g, '');
  };

