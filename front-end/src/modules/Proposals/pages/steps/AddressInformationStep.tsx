import React, { useContext, useState } from 'react'
import Input from '../../components/Input'
import { ProposalContext } from '../../contexts/ProposalsContext'
import SelectInput from '../../components/SelectInput';
import { Proposal } from '../../models/Proposal';

const AddressInformationStep = () => {

  const countries = [
    // { value: 'american', label: 'American' },
    { value: 'brazilian', label: 'Brazilian' }
    // { value: 'canadian', label: 'Canadian' },
    // { value: 'chinese', label: 'Chinese' },
    // { value: 'french', label: 'French' },
    // { value: 'german', label: 'German' },
    // { value: 'indian', label: 'Indian' },
    // { value: 'italian', label: 'Italian' },
    // { value: 'japanese', label: 'Japanese' },
    // { value: 'mexican', label: 'Mexican' },
    // { value: 'portuguese', label: 'Portuguese' },
    // { value: 'russian', label: 'Russian' },
    // { value: 'spanish', label: 'Spanish' },
    // { value: 'british', label: 'British' },
    // { value: 'other', label: 'Other' },
  ];

  const brazilStates = [
    { value: 'ac', label: 'Acre' },
    { value: 'al', label: 'Alagoas' },
    { value: 'ap', label: 'Amapá' },
    { value: 'am', label: 'Amazonas' },
    { value: 'ba', label: 'Bahia' },
    { value: 'ce', label: 'Ceará' },
    { value: 'df', label: 'Distrito Federal' },
    { value: 'es', label: 'Espírito Santo' },
    { value: 'go', label: 'Goiás' },
    { value: 'ma', label: 'Maranhão' },
    { value: 'mt', label: 'Mato Grosso' },
    { value: 'ms', label: 'Mato Grosso do Sul' },
    { value: 'mg', label: 'Minas Gerais' },
    { value: 'pa', label: 'Pará' },
    { value: 'pb', label: 'Paraíba' },
    { value: 'pr', label: 'Paraná' },
    { value: 'pe', label: 'Pernambuco' },
    { value: 'pi', label: 'Piauí' },
    { value: 'rj', label: 'Rio de Janeiro' },
    { value: 'rn', label: 'Rio Grande do Norte' },
    { value: 'rs', label: 'Rio Grande do Sul' },
    { value: 'ro', label: 'Rondônia' },
    { value: 'rr', label: 'Roraima' },
    { value: 'sc', label: 'Santa Catarina' },
    { value: 'sp', label: 'São Paulo' },
    { value: 'se', label: 'Sergipe' },
    { value: 'to', label: 'Tocantins' },
  ];
  

  const {proposal, setProposal} = useContext(ProposalContext);

  const setNestedProperty = (obj: any, path: string, value: any) => {
    const keys = path.split('.');
    let current = obj;
  
    for (let i = 0; i < keys.length - 1; i++) {
      if (!current[keys[i]]) {
        current[keys[i]] = {};
      }
      current = current[keys[i]];
    }
  
    current[keys[keys.length - 1]] = value;
  };

  const updateProposal = (propertyPath: string, newValue: any) => {
    setProposal((prevProposal: Proposal) => {
      const newProposal = { ...prevProposal };
      setNestedProperty(newProposal, propertyPath, newValue);
      return newProposal;
    });
  };
 
  return (
    <>
      <h2 className='font-poppins_bold text-4xl'>Address Informations</h2> 

      <form action="" className='mt-10 mb-10'>
          <Input label="Address Line 1" value={proposal.address?.firstLine || ""} inputPlaceholder='' onInputChange={(e) => updateProposal('address.firstLine', e.target.value)}/>      
          <Input label="Address Line 2" value={proposal.address?.secondLine || ""} inputPlaceholder='' onInputChange={(e) => updateProposal('address.secondLine', e.target.value)} inputClassName="w-full"/>     

        <div className='grid grid-cols-2 gap-3'>
          <div>
            <SelectInput
              label="Country"
              options={countries}
              onChange={(e) => updateProposal('address.country', e)}
            />

            <SelectInput
              label="State/Province"
              options={brazilStates}
              onChange={(e) => updateProposal('address.state', e)}
            />     
          </div>
          <div>
            <Input label="Zip/Postal Code" value={proposal.address?.zipCode || ""} inputPlaceholder='' onInputChange={(e) => updateProposal('address.zipCode', e.target.value)}/> 

            <Input label="City" value={proposal.address?.city || ""} inputPlaceholder='' onInputChange={(e) => updateProposal('address.city', e.target.value)}/>
          </div>
        </div>
      </form>
    </>
  )
}

export default AddressInformationStep