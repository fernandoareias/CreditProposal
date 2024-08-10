namespace CreditCard.Proposals.BFF.Services.Interfaces;

public interface IProposalServices
{
    Task<object> Init(Guid idempotentId, Guid correlationId, string document);
}