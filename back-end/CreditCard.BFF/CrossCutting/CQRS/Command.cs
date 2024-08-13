using MediatR;

namespace CreditCard.Proposals.BFF.CrossCutting.CQRS;

public abstract class Command<TView> : Message, IRequest<TView> where TView : View
{ 
    public virtual bool IsValid()
        => throw new NotImplementedException();

    protected Command()
    {
        
    }
    
    protected Command(Guid idempotencyKey, Guid correlationId) : base(idempotencyKey, correlationId)
    {
    }
}