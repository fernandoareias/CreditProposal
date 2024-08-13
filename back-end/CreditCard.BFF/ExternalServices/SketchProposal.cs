using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;
using CreditCard.Proposals.BFF.ExternalServices.DTOs.Enums;
using CreditCard.Proposals.BFF.ExternalServices.DTOs.Events;

namespace CreditCard.Proposals.BFF.ExternalServices.DTOs;

[DataContract]
public class SketchProposal
{

    protected SketchProposal()
    {
        
    }

    [JsonIgnore]
    private List<Event> _events = new List<Event>();
    [JsonIgnore]
    public IReadOnlyCollection<Event> Events => _events;

    // REDIS
    public SketchProposal(Guid correlationId, string document, SendProposalRequestOrigem origem)
    {
        CorrelationId = correlationId;
        Document = document;
        Origem = origem;
        
        _events.Add(new ProposalStarted(ProposalId, Document, correlationId));
    }

    [DataMember]
    public Guid CorrelationId { get; private set; }

    [DataMember] 
    public Guid ProposalId { get; private set; } = Guid.NewGuid();
    
    [DataMember]
    public string Document { get; private set; }
    
    [DataMember]
    public SendProposalRequestOrigem Origem { get; private set; } 
    
}


[DataContract]
public class SendProposalRequestOrigem
{
    protected SendProposalRequestOrigem()
    {
        
    }

    public SendProposalRequestOrigem(string ip, ESystemOrigem system, double? lat = null, double? log = null)
    {
        IP = ip;
        Lat = lat;
        Log = log;
        System = system;
    }

    [DataMember]
    public string IP { get; set; }
    
    [DataMember]
    public double? Lat { get; set; }
    
    [DataMember]
    public double? Log { get; set; }
    
    [DataMember]
    public ESystemOrigem System { get; set; }
}
