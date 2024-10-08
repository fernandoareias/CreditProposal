import React, { useContext, useEffect, useState } from 'react'
import Input from '../../components/Input'
import SelectInput from '../../components/SelectInput';
import DateOfBirthInput from '../../../../core/components/DateOfBirthInput';
import Button from '../../../../core/components/Button';
import { ProposalContext } from '../../contexts/ProposalsContext';
import { Proposal } from '../../models/Proposal';
import { maskEmail } from '../../../../core/masks/maskEmail';
import { setMaskCellphone } from '../../../../core/masks/maskCellphone';

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
    <div className='grid grid-cols-2 gap-3'>
        <div>
          <Input 
            label="Full  Name" 
            value={proposal.fullName || ""} 
            inputPlaceholder='Your name' 
            onInputChange={handleChange(('fullName'))}
            isRequired={true}
          />


          <DateOfBirthInput
            label="Birth date"
            onChange={handleDateOfBirthChange}
          />

          <SelectInput
            label="Nationality"
            options={nationalities}
            onChange={setNationality}
          />

          <Input 
            label="Cellphone" 
            value={setMaskCellphone(proposal.cellphone!) || ""} 
            inputPlaceholder='(00) 00000-0000' 
            onInputChange={handleChange(('cellphone'))} 
            isRequired={true}
          />
        </div>
        <div>
          <Input 
            label="E-mail" 
            value={proposal.email || ""} 
            inputPlaceholder='example@gmail.com' 
            onInputChange={handleChange(('email'))}
          />

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

        <Input 
          label="Confirm your cellphone" 
          value={setMaskCellphone(proposal.confirmCellphone!) || ""}  
          inputPlaceholder='(00) 00000-0000' 
          onInputChange={handleChange(('confirmCellphone'))}
          isRequired={true}
        />


          
        </div>
        <div>
        <div className='flex gap-2 mt-2'>
          <input type="checkbox" id="scales" name="scales" defaultChecked={true} />
          <label htmlFor="scales">Are you a politically exposed person?</label>
        </div>
        </div>
    </div>
  )
}

export default PersornalInformationStep