using CardGame.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IPlayCardGameService _playCardGameService;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="playCardGameService"></param>
        public GameController(IPlayCardGameService playCardGameService)
        {
            _playCardGameService = playCardGameService;
        }

        /// <summary>
        /// this function will be used to play card clash game 
        /// </summary>
        /// <returns>Returns a Winner of the Game.</returns>
        [HttpGet]
        [Route("CardClash")]
        public async Task<ActionResult<string>> PlayCardClashGameAsync()
        {
            return await _playCardGameService.PlayAsync();
        }
    }
}
