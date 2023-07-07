using AutoMapper;
using MediatR;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Commands.CreateFlat
{
    public class CreateFlatCommandHandler : IRequestHandler<CreateFlatCommand, Flat>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateFlatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Flat> Handle(CreateFlatCommand request, CancellationToken cancellationToken)
        {
           Flat flat = _mapper.Map<Flat>(request);
           IRepository<Flat> repository = _unitOfWork.Flats;
           flat = repository.Insert(flat);
           await _unitOfWork.SaveChangesAsync();
           return flat;
        }
    }
}
