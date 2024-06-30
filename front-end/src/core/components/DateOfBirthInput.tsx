import React, { useEffect, useState } from 'react';

interface DateOfBirthProps {
    label: string;
    onChange: (date: string) => void;
}

const DateOfBirthInput: React.FC<DateOfBirthProps> = ({ label, onChange }) => {
    const [day, setDay] = useState<string>('');
    const [month, setMonth] = useState<string>('');
    const [year, setYear] = useState<string>('');

    const handleInputChange = () => {
        onChange(`${year}-${month}-${day}`);
    };

    useEffect(() => {
        handleInputChange()
    }, [day, month, year]);

    return (
        <div className='text-left mt-5'>
            <label htmlFor="dob" className="mb-2 text-sm font-medium" style={{ color: '#505D63' }}>
                {label}
            </label>
            <div className="flex space-x-2">
                <input
                    type="text"
                    name="day"
                    id="day"
                    placeholder="DD"
                    value={day}
                    onChange={(e) => setDay(e.target.value)}
                    className="bg-[#C5D0DA] border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-1/4 p-2.5"
                />
                <input
                    type="text"
                    name="month"
                    id="month"
                    placeholder="MM"
                    value={month}
                    onChange={(e) => setMonth(e.target.value)}
                    className="bg-[#C5D0DA] border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-1/4 p-2.5"
                />
                <input
                    type="text"
                    name="year"
                    id="year"
                    placeholder="YYYY"
                    value={year}
                    onChange={(e) => setYear(e.target.value)}
                    className="bg-[#C5D0DA] border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-1/4 p-2.5"
                />
            </div>
        </div>
    );
};

export default DateOfBirthInput;
