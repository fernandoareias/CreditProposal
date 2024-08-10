using System.Text.Json.Serialization;
using MediatR;

namespace CreditCard.Proposals.BFF.CrossCutting.CQRS;

public abstract class Event : Message, INotification
{
    protected Event()
    {
        
    }
}