using FluentValidation;
using MediatR;
using RealtService.Application.Interfaces;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.Commands.CreateOffer
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, Guid>
    {
        private readonly IOfferDbContext _dbContext;
        public async Task<Guid> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = new CommercialOffer
            {
              /*  UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                Address = request.Address,
                CommercialOfferDatailsId = request.CommercialOfferDatailsId,
                ResidentialOfferDatailsId = request.ResidentialOfferDatailsId,
                OfferTypeId = request.OfferTypeId,
                Id = Guid.NewGuid(),
                PublicationTime = DateTime.Now,
                EditTime = null*/
            };

            await _dbContext.Offers.AddAsync(offer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return offer.Id;
        }
    }

    public class CreateProductCommandValidator : AbstractValidator<CreateOfferCommand>
    {
        public CreateProductCommandValidator()
        {
            //Rules might be changed
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.CommercialOfferDatailsId).NotEmpty();
            RuleFor(c => c.ResidentialOfferDatailsId).NotEmpty();
            RuleFor(c => c.OfferTypeId).NotEmpty();                                   
        }
    }
}
