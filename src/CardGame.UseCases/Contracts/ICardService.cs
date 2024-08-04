using CardGame.Domain.Entities;

namespace CardGame.Application.Contracts
{
    public interface ICardService
    {
        Task<List<Card>> GetCards();
    }
}
