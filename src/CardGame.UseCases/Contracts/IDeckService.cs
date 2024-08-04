using System;
using CardGame.Domain.Entities;

namespace CardGame.Application.Contracts
{
    public interface IDeckService
    {
        Task<List<Card>> GetDeck();
        Task<Card> DrawCard(List<Card> cards);
    }
}
