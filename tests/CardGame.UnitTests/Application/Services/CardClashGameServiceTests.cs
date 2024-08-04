using CardGame.Application.Business;
using CardGame.Application.Contracts;
using FluentAssertions;
using CardGame.Domain.Entities;
using Moq;
using CardGame.Domain.Enums;

namespace CardGame.UnitTests.Application.Services
{
    public class CardClashGameServiceTests
    {
        private readonly Mock<IDeckService> _mockDeckService;
        private readonly CardClashGameService _gameService;

        public CardClashGameServiceTests()
        {
            _mockDeckService = new Mock<IDeckService>();
            _gameService = new CardClashGameService(_mockDeckService.Object);
        }

        [Fact]
        public async Task PlayAsync_ShouldReturnPlayerWinMessage_WhenPlayerCardIsHigher()
        {
            // Arrange
            var playerCard = new Card(CardEnum.Hearts.ToString(), "10", 10);
            var computerCard = new Card(CardEnum.Diamonds.ToString(), "5", 5);
            var cards = new List<Card> { playerCard, computerCard };

            _mockDeckService.Setup(service => service.GetDeck()).ReturnsAsync(cards);
            _mockDeckService.Setup(service => service.DrawCard(It.IsAny<List<Card>>())).ReturnsAsync((List<Card> cardList) =>
            {
                // Draw the top card from the deck
                var card = cardList[0];
                cardList.RemoveAt(0);
                return card;
            });

            // Act
            var result = await _gameService.PlayAsync();

            // Assert
            result.Should().Be($"You win! You drew {playerCard} and the computer drew {computerCard}.");
        }

        [Fact]
        public async Task PlayAsync_ShouldReturnComputerWinMessage_WhenComputerCardIsHigher()
        {
            // Arrange
            var playerCard = new Card(CardEnum.Hearts.ToString(), "4", 4);
            var computerCard = new Card(CardEnum.Spades.ToString(), "9", 9);
            var cards = new List<Card> { playerCard, computerCard };

            _mockDeckService.Setup(service => service.GetDeck()).ReturnsAsync(cards);
            _mockDeckService.Setup(service => service.DrawCard(It.IsAny<List<Card>>())).ReturnsAsync((List<Card> cardList) =>
            {
                // Draw the top card from the deck
                var card = cardList[0];
                cardList.RemoveAt(0);
                return card;
            });

            // Act
            var result = await _gameService.PlayAsync();

            // Assert
            result.Should().Be($"Computer wins! You drew {playerCard} and the computer drew {computerCard}.");
        }

        [Fact]
        public async Task PlayAsync_ShouldReturnTieMessage_WhenCardsAreEqual()
        {
            // Arrange
            var card = new Card(CardEnum.Hearts.ToString(), "7", 7);
            var cards = new List<Card> { card, card }; // Both cards are the same

            _mockDeckService.Setup(service => service.GetDeck()).ReturnsAsync(cards);
            _mockDeckService.Setup(service => service.DrawCard(It.IsAny<List<Card>>())).ReturnsAsync((List<Card> cardList) =>
            {
                // Draw the top card from the deck
                var drawnCard = cardList[0];
                cardList.RemoveAt(0);
                return drawnCard;
            });

            // Act
            var result = await _gameService.PlayAsync();

            // Assert
            result.Should().Be($"It's a tie! Both drew {card}.");
        }
    }
}
