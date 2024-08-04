using CardGame.Application.Contracts;

namespace CardGame.Application.Business
{
    /// <summary>
    /// Implementaion of IPlayCardGameService
    /// </summary>
    public class CardClashGameService : IPlayCardGameService
    {
        private readonly IDeckService _deckService;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="deckService"></param>
        public CardClashGameService(IDeckService deckService)
        {
            _deckService = deckService;
        }

        /// <summary>
        /// ### Card Clash Game####
        /// Card Game where you compete against the computer to see who can draw the higher card
        /// </summary>
        /// <returns>Return a Winner of the Game.</returns>
        public async Task<string> PlayAsync()
        {
            // Draw cards for player and computer
            var cards = await _deckService.GetDeck();
            var playerCard = await _deckService.DrawCard(cards);
            var computerCard = await _deckService.DrawCard(cards);

            // Determine the winner
            string result = playerCard.Value > computerCard.Value
                ? $"You win! You drew {playerCard} and the computer drew {computerCard}."
                : playerCard.Value < computerCard.Value
                    ? $"Computer wins! You drew {playerCard} and the computer drew {computerCard}."
                    : $"It's a tie! Both drew {playerCard}.";

            return await Task.FromResult(result);
        }
    }
}
