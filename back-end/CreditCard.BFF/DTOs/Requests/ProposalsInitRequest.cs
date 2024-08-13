using System.Runtime.Serialization;

namespace CreditCard.Proposals.BFF.DTOs.Requests;

[DataContract]
public class ProposalsInitRequest
{
    [DataMember]
    public string Document { get; set; }
}