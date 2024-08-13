using System.Runtime.Serialization;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;

namespace CreditCard.Proposals.BFF.ExternalServices.DTOs.Events;

[DataContract]
public class ProposalStarted : Event
{
    protected ProposalStarted()
    {
        
    }
    public ProposalStarted(Guid proposalId, string document, Guid correlationId) : base(Guid.NewGuid(), correlationId)
    {
        ProposalId = proposalId;
        Document = document;
    }

    [DataMember]
    public Guid ProposalId { get; private set; }
    
    [DataMember]
    public string Document { get; private set; }
}