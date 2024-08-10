using CreditCard.Proposals.BFF.Commands;
using CreditCard.Proposals.BFF.Commands.Views;
using MediatR;

namespace CreditCard.Proposals.BFF.Services.Interfaces;

public class InitProposalCommandHandler : IRequestHandler<InitProposalCommand, InitProposalCommandViews>
{
    public Task<InitProposalCommandViews> Handle(InitProposalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}