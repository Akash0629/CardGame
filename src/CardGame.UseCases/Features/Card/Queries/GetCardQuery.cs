using MediatR;

namespace CardGame.Application.Features.Card.Queries
{
    public class GetCardQuery : IRequest<List<Domain.Entities.Card>>
    {
    }
}
