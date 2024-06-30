import React, { useContext, useEffect, useState } from 'react'
import Input from '../../components/Input'
import SelectInput from '../../components/SelectInput';
import DateOfBirthInput from '../../../../core/components/DateOfBirthInput';
import Button from '../../../../core/components/Button';
import { ProposalContext } from '../../contexts/ProposalsContext';
import { Proposal } from '../../models/Proposal';

const PersornalInformationStep = () => {

  const { proposal, setProposal} = useContext(ProposalContext);

  const handleChange = (property: keyof Proposal) => (e: React.ChangeEvent<HTMLInputElement>) => {
    const newValue = e.target.value;
    setProposal((prevProposal: Proposal ) => ({
      ...prevProposal,
      [property]: newValue
    }));
  };

  
  const handleDateOfBirthChange = (e: any) => {
    setProposal((prevProposal: Proposal ) => ({
      ...prevProposal,
      ["birthDate"]: e
    }));
  }

  const handleEducationLevelChange = (e: any) => {
    setProposal((prevProposal: Proposal ) => ({
      ...prevProposal,
      ["educationLevel"]: e
    }));
  }

  const setNationality = (e: any) => {
    setProposal((prevProposal: Proposal ) => ({
      ...prevProposal,
      ["nationality"]: e
    }));
  }

  const setGender = (e: any) => {
    setProposal((prevProposal: Proposal ) => ({
      ...prevProposal,
      ["gender"]: e
    }));
  }


  const educationLevels = [
      { value: 'high_school', label: 'High School Diploma' },
      { value: 'associate_degree', label: 'Associate Degree' },
      { value: 'bachelors_degree', label: "Bachelor's Degree" },
      { value: 'masters_degree', label: "Master's Degree" },
      { value: 'doctorate', label: 'Doctorate (Ph.D.)' },
  ];

  const genders = [
    { value: 'male', label: 'Male' },
    { value: 'female', label: 'Female' },
    { value: 'other', label: 'Other' },
    { value: 'prefer_not_to_say', label: 'Prefer not to say' },
  ];

  const nationalities = [
    { value: 'american', label: 'American' },
    { value: 'brazilian', label: 'Brazilian' },
    { value: 'canadian', label: 'Canadian' },
    { value: 'chinese', label: 'Chinese' },
    { value: 'french', label: 'French' },
    { value: 'german', label: 'German' },
    { value: 'indian', label: 'Indian' },
    { value: 'italian', label: 'Italian' },
    { value: 'japanese', label: 'Japanese' },
    { value: 'mexican', label: 'Mexican' },
    { value: 'russian', label: 'Russian' },
    { value: 'spanish', label: 'Spanish' },
    { value: 'british', label: 'British' },
    { value: 'other', label: 'Other' },
  ];

  return (
    <>
      <h2 className='font-poppins_bold text-4xl'>Persornal Information</h2>

      <form action="" className='mt-10 grid grid-cols-2 gap-3' >
        <div>
          <Input label="Full  Name" inputPlaceholder='' onInputChange={handleChange(('fullName'))}/>


          <DateOfBirthInput
            label="Birth date"
            onChange={handleDateOfBirthChange}
          />

          <SelectInput
            label="Nationality"
            options={nationalities}
            onChange={setNationality}
          />

          <Input label="Cellphone" inputPlaceholder='(00) 00000-0000' onInputChange={handleChange(('cellphone'))}/>
        </div>
        <div>
          <Input label="E-mail" inputPlaceholder='example@gmail.com' onInputChange={handleChange(('email'))}/>

          <SelectInput
            label="Gender"
            options={genders}
            onChange={setGender}
          />

          <SelectInput
            label="Education Level"
            options={educationLevels}
            onChange={handleEducationLevelChange}
          /> 

        <Input label="Confirm your cellphone"  inputPlaceholder='(00) 00000-0000' onInputChange={handleChange(('confirmCellphone'))}/>


          
        </div>
        <div>
        <div className='flex gap-2 mt-2'>
          <input type="checkbox" id="scales" name="scales" checked />
          <label htmlFor="scales">Are you a politically exposed person?</label>
        </div>
        </div>
        
      </form>
    </>
  )
}

export default PersornalInformationStep