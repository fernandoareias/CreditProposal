using CreditCard.Proposals.BFF.CrossCutting.CQRS;
using MediatR;

namespace CreditCard.Proposals.BFF.CrossCutting.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;
    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }
 
 
    public async Task<TCommandView> Send<TCommandView>(Command<TCommandView> command) where TCommandView : View
    {
        return await _mediator.Send(command);

    }
 
    public async Task Publish<TEvent>(TEvent @event) where TEvent : Event
    {
        await _mediator.Publish(@event);
    }
}