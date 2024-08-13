using System.Runtime.Serialization;
using CreditCard.Proposals.BFF.CrossCutting.CQRS; 

namespace CreditCard.Proposals.BFF.Commands.Views;

[DataContract]
public class InitProposalCommandViews : View
{
    protected InitProposalCommandViews()
    {
        
    }
    
    public InitProposalCommandViews(Guid proposalId)
    {
        ProposalId = proposalId;
    }
    
    [DataMember]
    public Guid ProposalId { get; private set; }

   
}