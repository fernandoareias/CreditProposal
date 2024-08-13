using System.Runtime.Serialization;

namespace CreditCard.Proposals.BFF.CrossCutting.CQRS;

[DataContract]
public abstract class Message
{
    protected Message()
    {
        
    }
    
    protected Message(Guid idempotencyKey, Guid correlationId)
    {
        IdempotencyKey = idempotencyKey;
        CorrelationId = correlationId;
    }

    [DataMember]
    public Guid IdempotencyKey { get; protected set; } 
    
    [DataMember]
    public Guid CorrelationId { get; protected set; } 

    [DataMember]
    public string Type { get; private set; } = typeof(Message).Name;
    
    [DataMember] 
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}