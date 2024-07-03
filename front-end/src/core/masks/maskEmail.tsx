export function maskEmail(email: string): string {
    const [localPart, domain] = email.split('@');
    if (!localPart || !domain) return email; // Verifica se o e-mail está no formato correto
  
    const maskedLocalPart = localPart
      .split('')
      .map((char, index) => (index < 3 || index >= localPart.length - 2 ? char : '*'))
      .join('');
  
    return `${maskedLocalPart}@${domain}`;
  }
  