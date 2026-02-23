using GameOfLive.Lib.DB.Business;
using GameOfLive.Lib.Web.DTOs;
using Newtonsoft.Json;

namespace GameOfLive.Lib.Web.Business
{
    public class GameControllerLogic(SimulationFrameSavingService simulationFrameSavingService)
    {
        private readonly SimulationFrameSavingService simulationFrameSavingService = simulationFrameSavingService;

        public async Task<int?> SaveSimulationFrame(SimulationFrameDTO frame, CancellationToken cancellationToken)
        {
            string frameJson = JsonConvert.SerializeObject(frame);

            int id = await simulationFrameSavingService.AddFrameJsonAsync(frameJson);

            return id;
        }

        public async Task<SimulationFrameDTO?> GetSimulationFrame(int id, CancellationToken cancellationToken)
        {
            string? frameJson = await simulationFrameSavingService.GetFrameJsonByIdAsync(id);
            if (frameJson == null)
            {
                return null;
            }

            SimulationFrameDTO? frame = JsonConvert.DeserializeObject<SimulationFrameDTO>(frameJson);

            return frame;
        }
    }
}
