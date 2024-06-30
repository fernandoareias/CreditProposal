import React, { useEffect, useState } from 'react'

interface CreditCardProps {
  placeholder: string; 
}

const CreditCard: React.FC<CreditCardProps> =  ({placeholder}) => {

  const [label, setLabel] = useState<string>();

  function abbreviateName(name: string): string {
    const maxLength = 20;
    const particles = ["de", "da", "dos", "e"];
  
    // Remover partículas
    let nameParts = name.split(' ').filter(part => !particles.includes(part.toLowerCase()));
  
    // Abreviar até que o comprimento seja menor ou igual a maxLength
    while (nameParts.join(' ').length > maxLength) {
      for (let i = nameParts.length - 2; i > 0; i--) {
        if (nameParts[i].length > 1) {
          nameParts[i] = nameParts[i].charAt(0) + '.';
          break;
        }
      }
    }
  
    return nameParts.join(' ');
  }

  useEffect( () => {
    setLabel(abbreviateName(placeholder.toUpperCase()));
  }, [placeholder]);

  return (
    <>
       <div className='' style={{ backgroundImage: `url(/assets/creditcard-bg.svg)`, width: '360px', height: '224px' }}>
            <p className='pl-6 text-white' style={{ paddingTop: '170px'}}>{label}</p>
        </div>
    </>
  )
}

export default CreditCard