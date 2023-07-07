using MediatR;

namespace RealtService.Application.Offers.Commands.DeleteCommand;

public class DeleteOfferCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
