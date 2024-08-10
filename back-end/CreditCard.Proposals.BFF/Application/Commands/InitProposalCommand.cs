using System.Runtime.Serialization;
using CreditCard.Proposals.BFF.Commands.Views;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;

namespace CreditCard.Proposals.BFF.Commands;

[DataContract]
public class InitProposalCommand : Command<InitProposalCommandViews>
{
    protected InitProposalCommand()
    {
        
    }

    public InitProposalCommand(string document, Guid idempotentId, Guid correlationId)
    {
        Document = document;
        IdempotentId = idempotentId;
        CorrelationId = correlationId;
    }

    [DataMember]
    public string Document { get; init; }

    [DataMember]
    public Guid IdempotentId { get; init; }

    [DataMember]
    public Guid CorrelationId { get; init; }
    
}