import { createContext } from "react";
import { Proposal } from "../models/Proposal";


let proposal = new Proposal();

export const ProposalContext = createContext<{
    proposal: Proposal;
    setProposal: React.Dispatch<React.SetStateAction<Proposal>>;
}>({
    proposal: proposal,
    setProposal: () => {},
})