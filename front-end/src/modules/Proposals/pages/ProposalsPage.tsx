import React, { useEffect, useState } from 'react'
import CreditCard from '../../../core/components/CreditCard'
import { Outlet, useNavigate } from 'react-router-dom'
import { Proposal } from '../models/Proposal'
import { ProposalContext } from '../contexts/ProposalsContext'
import Button from '../../../core/components/Button'
import { EProposalStep } from '../models/EProposalStep'
import PersornalInformationStep from './steps/PersornalInformationStep'
import AddressInformationStep from './steps/AddressInformationStep'
import BiometryStep from './steps/BiometryStep'

const ProposalsPage = () => {

  const [proposal, setProposal] = useState<Proposal>(new Proposal());
  const [currentStep, setCurrentStep] = useState<EProposalStep>(EProposalStep.PersonalInformation + 1);

  const navigate = useNavigate();

  const steps: { [id in EProposalStep]: string } = {
    [EProposalStep.PersonalInformation]: "persornal-informations",
    [EProposalStep.AddressInformation]: "address-informations",
    [EProposalStep.Biometry]: "biometry"
  };
  
  const nextStep = () => {
    console.log(proposal);
    if(currentStep == EProposalStep.Biometry)
    {
      return;
    }

    setCurrentStep((prevStep) => {
      return prevStep + 1;
    });

    navigate("/proposals/" + steps[currentStep]);
  };
 
  return (
    <ProposalContext.Provider value={{ proposal, setProposal }}>
      <div className="w-screen h-screen flex flex-col" style={{ backgroundImage: `url(/assets/header-bg.svg)`, backgroundSize: 'cover', backgroundPosition: 'center', backgroundRepeat: 'no-repeat' }}>
        <div className='container-xl px-32 pt-8 flex  w-full'>
          <h1 className='font-playfair text-3xl text-white'>Venture Bank</h1>
        </div>
        <main className='mt-12 h-5/6 bg-[#E6E6E8] container-xl px-32 pt-8 flex w-full h-full justify-between'>
            <section className='mr-44'>
                <div>
                <Outlet/> 
                </div>
                <div className='flex justify-end'>
                  <Button content='NEXT' onClick={nextStep}></Button>
                </div>
            </section>
            <section className='flex items-center'>
              <CreditCard placeholder={proposal.fullName ?? 'Your name'}/>
            </section>
        </main>
        <footer className='bg-[#5352B7] container-xl px-32 p-6 mt-20 flex w-full justify-center'>
          <span className='text-white'>Copyright © 2024 Venture Bank.</span>
        </footer>
    </div>
  </ProposalContext.Provider>
  
  )
}

export default ProposalsPage