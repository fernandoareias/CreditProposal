using CreditCard.Proposals.BFF.CrossCutting.CQRS;

namespace CreditCard.Proposals.BFF.CrossCutting.Mediator;

public interface IMediatorHandler
{
    Task Publish<TEvent>(TEvent @event) where TEvent : Event;
    Task<TCommandView> Send<TCommandView>(Command<TCommandView> command) where TCommandView : View;

}