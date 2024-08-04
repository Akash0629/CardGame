using CardGame.Application.Business;
using CardGame.Application.Contracts;
using CardGame.Domain.Entities;
using FluentAssertions;
using Moq;

namespace CardGame.UnitTests.Application.Services
{
    public class DeckServiceTests
    {
        private readonly Mock<ICardService> _mockCardService;
        private readonly DeckService _deckService;
        public DeckServiceTests()
        {
            _mockCardService = new Mock<ICardService>();
            _deckService = new DeckService(_mockCardService.Object);
        }

        [Fact]
        public async Task GetDeck_ShouldReturnExactCount()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card("Hearts", "2", 2),
                new Card("Diamonds", "3", 3),
                new Card("Clubs", "4", 4),
                new Card("Spades", "5", 5)
            };

            _mockCardService.Setup(service => service.GetCards()).ReturnsAsync(cards);

            // Act
            var result = await _deckService.GetDeck();

            // Assert
            result.Should().HaveCount(4);
        }

        [Fact]
        public async Task DrawCard_ShouldRemoveCardFromDeck()
        {
            // Arrange
            var card = new Card("Hearts", "2", 2);
            var cards = new List<Card> { card };

            _mockCardService.Setup(service => service.GetCards()).ReturnsAsync(cards);

            var deck = await _deckService.GetDeck();

            // Act
            var drawnCard = await _deckService.DrawCard(deck);

            // Assert
            drawnCard.Should().Be(card);
            deck.Should().BeEmpty(); // Ensure the deck is now empty
        }

        [Fact]
        public async Task DrawCard_ShouldThrowExceptionWhenDeckIsEmpty()
        {
            // Arrange
            var emptyDeck = new List<Card>();

            // Act
            Func<Task> act = async () => await _deckService.DrawCard(emptyDeck);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("The deck is empty.");
        }
    }
}
