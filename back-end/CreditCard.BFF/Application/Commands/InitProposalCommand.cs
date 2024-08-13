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

    public InitProposalCommand(
        string document, 
        Guid idempotentId, 
        Guid correlationId,
        InitProposalCommandOrige origem
        ) : base(idempotentId, correlationId)
    {
        Document = document;
        IdempotentId = idempotentId;
        CorrelationId = correlationId;
        Origem = origem;
    }

    [DataMember]
    public string Document { get; init; }

    [DataMember]
    public Guid IdempotentId { get; init; }

    [DataMember]
    public Guid CorrelationId { get; init; }

    [DataMember]
    public InitProposalCommandOrige Origem { get; init; }
    
}

[DataContract]
public class InitProposalCommandOrige
{
    protected InitProposalCommandOrige()
    {
        
    }
    public InitProposalCommandOrige(string ip, double? lat, double? log)
    {
        IP = ip;
        Lat = lat;
        Log = log;
    }

    [DataMember]
    public string IP { get; private set; }
    
    [DataMember]
    public double? Lat { get; private set; }
    
    [DataMember]
    public double? Log { get; private set; }
}