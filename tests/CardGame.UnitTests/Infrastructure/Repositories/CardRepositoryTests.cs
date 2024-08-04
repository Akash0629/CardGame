using CardGame.Domain.Enums;
using CardGame.Infrastructure.Repositories;
using FluentAssertions;

namespace CardGame.UnitTests.Infrastructure.Repositories
{
    public class CardRepositoryTests
    {
        private readonly CardRepository _cardRepository;

        public CardRepositoryTests()
        {
            _cardRepository = new CardRepository();
        }

        [Fact]
        public async Task GetAllCardsAsync_ShouldReturnListOfCards()
        {
            // Act
            var result = await _cardRepository.GetAllCardsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(52); // 4 suits * 13 ranks = 52 cards

            var suits = new[] { CardEnum.Hearts.ToString(), CardEnum.Diamonds.ToString(), CardEnum.Clubs.ToString(), CardEnum.Spades.ToString() };
            var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    result.Should().Contain(card => card.Suit == suit && card.Rank == rank);
                }
            }
        }
    }
}
