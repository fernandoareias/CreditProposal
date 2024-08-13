using CreditCard.Proposals.BFF.ExternalServices.DTOs;

namespace CreditCard.Proposals.BFF.Infrastructure.Repositories;

public interface ISketchProposalRepository
{
    Task<SketchProposal> Get(string document);
    Task Save(string document, SketchProposal proposal);
}