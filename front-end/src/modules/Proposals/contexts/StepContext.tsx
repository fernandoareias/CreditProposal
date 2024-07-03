import React, { createContext } from 'react'
import { EProposalStep } from '../models/EProposalStep';


let step = EProposalStep.PersonalInformation;

export const ProposalStepContext = createContext<{
    step: EProposalStep;
    setStep: React.Dispatch<React.SetStateAction<EProposalStep>>;
}>({
    step: step,
    setStep: () => {},
})

