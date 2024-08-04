using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardGame.Application.Contracts.Persistence;
using CardGame.Application.Features.Card.Queries;
using CardGame.Domain.Enums;

using FluentAssertions;

using Moq;

namespace CardGame.UnitTests.Application.Features
{
    public class GetCardQueryHandlerTests
    {
        private readonly Mock<ICardRepository> _mockCardRepository;
        private readonly GetCardQueryHandler _handler;

        public GetCardQueryHandlerTests()
        {
            _mockCardRepository = new Mock<ICardRepository>();
            _handler = new GetCardQueryHandler(_mockCardRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfCards_WhenCardsAreAvailable()
        {
            // Arrange
            var expectedCards = new List<Domain.Entities.Card>
            {
                new Domain.Entities.Card(CardEnum.Hearts.ToString(), "2", 2),
                new Domain.Entities.Card(CardEnum.Diamonds.ToString(), "3", 3)
            };

            _mockCardRepository.Setup(repo => repo.GetAllCardsAsync())
                .ReturnsAsync(expectedCards);

            var query = new GetCardQuery();
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(expectedCards.Count);
            result.Should().BeEquivalentTo(expectedCards);
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenNoCardsAvailable()
        {
            // Arrange
            var expectedCards = new List<Domain.Entities.Card>();

            _mockCardRepository.Setup(repo => repo.GetAllCardsAsync())
                .ReturnsAsync(expectedCards);

            var query = new GetCardQuery();
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _handler.Handle(query, cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }
    }
}
