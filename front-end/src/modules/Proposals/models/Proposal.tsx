

export class Proposal
{
    constructor(){
        this.address = new ProposalAddress();
    }

    fullName: string | undefined;
    email: string | undefined;
    gender: string | undefined;
    birthDate: string | undefined;
    nationality: number | undefined;
    educationLevel: number | undefined;
    cellphone: string | undefined;
    confirmCellphone: string | undefined;
    address: ProposalAddress  | undefined;
}


class ProposalAddress {
    firstLine: string | undefined;
    secondLine: string | undefined;
    country: string | undefined;     
    zipCode: string | undefined;
    state: string | undefined;
    city: string | undefined;
}