using CardGame.Application.Business;
using CardGame.Application.Features.Card.Queries;
using CardGame.Domain.Entities;
using CardGame.Domain.Enums;

using FluentAssertions;
using MediatR;
using Moq;

namespace CardGame.UnitTests.Application.Services
{
    public class CardServiceTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly CardService _cardService;

        public CardServiceTests()
        {
            _mockMediator = new Mock<IMediator>();
            _cardService = new CardService(_mockMediator.Object);
        }

        [Fact]
        public async Task GetCards_ShouldReturnListOfCards()
        {
            // Arrange
            var cards = new List<Card>
            {
                new Card(CardEnum.Hearts.ToString() , "2", 2),
                new Card(CardEnum.Diamonds.ToString(), "3", 3),
                new Card(CardEnum.Clubs.ToString(), "4", 4),
                new Card(CardEnum.Spades.ToString(), "5", 5)
            };

            _mockMediator.Setup(mediator => mediator.Send(It.IsAny<GetCardQuery>(), default))
                .ReturnsAsync(cards);

            // Act
            var result = await _cardService.GetCards();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(4);
            result.Should().ContainEquivalentOf(cards[0]);
            result.Should().ContainEquivalentOf(cards[1]);
            result.Should().ContainEquivalentOf(cards[2]);
            result.Should().ContainEquivalentOf(cards[3]);
        }
    
    }
}
