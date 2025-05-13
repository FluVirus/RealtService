﻿using MediatR;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Commands.DeleteCommand;

public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOfferCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
    {
        IRepository<Offer> offerRepository = _unitOfWork.Offers;
        var entity = await offerRepository.FindAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Offer), request.Id);
        }

        offerRepository.Delete(entity);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
