using System.Runtime.Serialization;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;
using CreditCard.Proposals.BFF.Domain.Enums;

namespace CreditCard.Proposals.BFF.Commands.Views;

[DataContract]
public class InitProposalCommandViews : View
{
    [DataMember]
    public Guid ProposalId { get; private set; }

    [DataMember]
    public EProposalStep CurrentStep { get; private set; }
}