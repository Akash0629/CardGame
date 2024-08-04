using CardGame.Application.Contracts.Persistence;
using CardGame.Domain.Entities;
using CardGame.Domain.Enums;

namespace CardGame.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of ICardRepository
    /// </summary>
    public class CardRepository : ICardRepository
    {
        /// <summary>
        /// Get All Cards
        /// </summary>
        /// <returns>List of generated cards.</returns>
        public async Task<List<Card>> GetAllCardsAsync()
        {
            var cards = new List<Card>();

            string[] suits = { CardEnum.Hearts.ToString(),
                               CardEnum.Diamonds.ToString(),
                               CardEnum.Clubs.ToString(),
                               CardEnum.Spades.ToString() };

            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string suit in suits)
            {
                for (int i = 0; i < ranks.Length; i++)
                {
                    cards.Add(new Card(suit, ranks[i], i + 2));
                }
            }
            return await Task.FromResult(cards);
        }
    }
}
