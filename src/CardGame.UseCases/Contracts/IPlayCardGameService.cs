namespace CardGame.Application.Contracts
{
    /// <summary>
    /// Generic Interface which multiple card games can inherit and implement there logic
    /// </summary>
    public interface IPlayCardGameService
    {
        /// <summary>
        /// This Function can be integrate by multiple card games
        /// </summary>
        /// <returns>Return a Winner of the Game.</returns>
        Task<string> PlayAsync();
    }
}
