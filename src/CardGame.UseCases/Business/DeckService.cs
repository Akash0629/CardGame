using CardGame.Application.Contracts;
using CardGame.Domain.Entities;

namespace CardGame.Application.Business
{
    /// <summary>
    /// Implementaion of IDeckService
    /// </summary>
    public class DeckService : IDeckService
    {
        private static readonly Random _random = new Random();
        private readonly ICardService _cardService;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="cardService"></param>
        public DeckService(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// Generate Shuffled Deck 
        /// </summary>
        /// <returns>List of cards.</returns>
        public async Task<List<Card>> GetDeck()
        {
            var cards = await _cardService.GetCards();
            ShuffleCards(cards);
            return cards;
        }

        /// <summary>
        /// Draw a single random card
        /// </summary>
        /// <returns>return a random card.</returns>
        public async Task<Card> DrawCard(List<Card> cards)
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("The deck is empty.");

            var card = cards[0];
            cards.RemoveAt(0);
            return await Task.FromResult(card);
        }

        #region Private Method
        private void ShuffleCards(List<Card> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        #endregion
    }
}
