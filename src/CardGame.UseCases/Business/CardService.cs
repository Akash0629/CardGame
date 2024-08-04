using CardGame.Application.Contracts;
using CardGame.Application.Features.Card.Queries;
using CardGame.Domain.Entities;
using MediatR;

namespace CardGame.Application.Business
{

    /// <summary>
    /// Implementation of ICardService
    /// </summary>
    public class CardService : ICardService
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="mediator"></param>
        public CardService(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Cards 
        /// </summary>
        /// <returns>List of generated cards.</returns>
        public async Task<List<Card>> GetCards()
        {
            var query = new GetCardQuery();
            return await _mediator.Send(query);
        }
    }
}
