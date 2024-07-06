import React from 'react'

interface InputProps {
    label: string; 
    inputPlaceholder: string;
    onInputChange: (date: any) => void;
    value: string;
    labelClassName?: string;
    inputClassName?: string;
  }
  
const Input: React.FC<InputProps> = ({label, inputPlaceholder, onInputChange, value, labelClassName = "", inputClassName = ""}) => {
  return (
    <div className='text-left mt-5'>
        <label htmlFor="text" className={"mb-2 text-sm font-medium " + labelClassName} style={{ color: '#505D63' }}>{label}</label>
        <input type="text" name="text" id="text" value={value} onChange={(e) => onInputChange(e)} placeholder={inputPlaceholder} className={"bg-[#C5D0DA] border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 " + inputClassName} required/>
    </div>
  )
}

export default Input