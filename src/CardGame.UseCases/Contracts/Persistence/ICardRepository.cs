using CardGame.Domain.Entities;

namespace CardGame.Application.Contracts.Persistence
{
    public interface ICardRepository
    {
        Task<List<Card>> GetAllCardsAsync();
    }
}
