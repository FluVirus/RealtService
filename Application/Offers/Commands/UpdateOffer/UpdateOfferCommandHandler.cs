using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Interfaces;
using RealtService.Application.Offers.Commands.DeleteCommand;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Commands.UpdateOffer
{
    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, Unit>
    {
        private readonly IOfferDbContext _dbContext;

        public UpdateOfferCommandHandler(IOfferDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Offers.FirstOrDefaultAsync(offer => offer.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

           // entity.Description = request.Description;
            entity.Title = request.Title;
            entity.Address = request.Address;
            entity.EditTime = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class UpdateOfferProductCommandValidator : AbstractValidator<UpdateOfferCommand>
    {
        public UpdateOfferProductCommandValidator()
        {
            //Rules might be changed
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();            
        }
    }
}


