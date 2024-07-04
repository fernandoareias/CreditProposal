import React from 'react'



interface ButtonProps {
  content: string; 
  onClick: (e: any) => void;
}


const Button: React.FC<ButtonProps> = ({ content, onClick }) => {
  return (
    <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"  onClick={(e) => onClick(e)}>
      {content}
    </button>
  )
}

export default Button