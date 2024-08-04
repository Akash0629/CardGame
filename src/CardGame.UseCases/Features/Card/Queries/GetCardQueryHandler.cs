using CardGame.Application.Contracts.Persistence;
using MediatR;

namespace CardGame.Application.Features.Card.Queries
{
    public class GetCardQueryHandler : IRequestHandler<GetCardQuery, List<Domain.Entities.Card>>
    {
        private readonly ICardRepository _cardRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cardRepository"></param>
        public GetCardQueryHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        /// <summary>
        /// MediateR Handle function to get the Card List 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        public async Task<List<Domain.Entities.Card>> Handle(GetCardQuery request, CancellationToken cancellationToken)
        {
            // calling repository to get the cards
            var cards = await _cardRepository.GetAllCardsAsync();
            return cards;
        }
    }
}
