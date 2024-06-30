import React from 'react';

interface SelectProps {
    label: string;
    options: { value: string; label: string }[];
    onChange: (date: any) => void;
}

const SelectInput: React.FC<SelectProps> = ({ label, options, onChange }) => {
    return (
        <div className='text-left mt-5'>
            <label htmlFor="select" className="mb-2 text-sm font-medium" style={{ color: '#505D63' }}>
                {label}
            </label>
            <select
                name="select"
                id="select"
                onChange={(e) => onChange(e.target.value)}
                className="bg-[#C5D0DA] border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                required
            >
                <option value="">Select...</option>
                {options.map((option) => (
                    <option key={option.value} value={option.value}>
                        {option.label}
                    </option>
                ))}
            </select>
        </div>
    );
};

export default SelectInput;
