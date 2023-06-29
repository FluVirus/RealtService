﻿using MediatR;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.Commands.CreateOffer
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, ResidentialOffer>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateOfferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResidentialOffer> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = new ResidentialOffer
            {
                //User = request.User,
                Name = request.Title,
                Description = request.Description,
                Address = request.Address,
                PublicationDate = DateTime.Now,
                EditDate = null
            };

            IRepository<Offer> offerRepository = _unitOfWork.GetRepository<Offer>()!;
            offer = (ResidentialOffer)offerRepository.Insert(offer);
            await _unitOfWork.SaveChangesAsync();
            return offer;
        }
    }
}
