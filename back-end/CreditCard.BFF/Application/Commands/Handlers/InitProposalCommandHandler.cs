using System.Text.Json;
using CreditCard.Proposals.BFF.Commands;
using CreditCard.Proposals.BFF.Commands.Views;
using CreditCard.Proposals.BFF.ExternalServices.DTOs;
using CreditCard.Proposals.BFF.ExternalServices.DTOs.Enums;
using CreditCard.Proposals.BFF.Infrastructure.Repositories;
using CreditCard.Proposals.BFF.Meters;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace CreditCard.Proposals.BFF.Services.Interfaces;

public class InitProposalCommandHandler : IRequestHandler<InitProposalCommand, InitProposalCommandViews>
{
    private readonly IDistributedCache _cache;
    private readonly ISketchProposalRepository _repository;
    private readonly APIMetrics _metrics;
    public InitProposalCommandHandler(IDistributedCache cache, ISketchProposalRepository repository, APIMetrics metrics)
    {
        _cache = cache;
        _repository = repository;
        _metrics = metrics;
    }

    public async Task<InitProposalCommandViews> Handle(InitProposalCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.Get(request.Document);

        if (response is not null) return new InitProposalCommandViews(response.ProposalId);

        var origem = new SendProposalRequestOrigem(request.Origem.IP, ESystemOrigem.VentureBank, request.Origem.Lat,
            request.Origem.Log);
        
        var proposal = new SketchProposal(request.CorrelationId, request.Document, origem);

        await _repository.Save(request.Document, proposal);
        _metrics.IncrementProposalStarted("started", proposal.ProposalId);
        return new InitProposalCommandViews(proposal.ProposalId); 
    }

   
    
    
}