import React from 'react'



interface ButtonProps {
  content: string; 
}


const Button: React.FC<ButtonProps> = ({ content }) => {
  return (
    <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" >
      {content}
    </button>
  )
}

export default Button