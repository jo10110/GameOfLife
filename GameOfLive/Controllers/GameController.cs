using GameOfLive.Lib.Web.Business;
using GameOfLive.Lib.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GameOfLive.Web.Controllers
{
    public class GameController(GameControllerLogic gameControllerLogic) : Controller
    {
        private readonly GameControllerLogic gameControllerLogic = gameControllerLogic;

        public IActionResult Index()
        {
            return View();
        }

        [Route("Post")]
        [HttpPost]
        public async Task<int?> PostSimulationFrame(SimulationFrameDTO simulationFrameDTO, CancellationToken cancellationToken)
        {
            return await this.gameControllerLogic.SaveSimulationFrame(simulationFrameDTO, cancellationToken);
        }

        [Route("Get")]
        [HttpPost]
        public async Task<SimulationFrameDTO?> GetSimulationFrame(int id, CancellationToken cancellationToken)
        {
            return await this.gameControllerLogic.GetSimulationFrame(id, cancellationToken);
        }
    }
}
