using GameOfLive.Lib.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace GameOfLive.Lib.DB.Business
{
    public class SimulationFrameSavingService(DatabaseContext dbc)
    {
        private readonly DatabaseContext dbc = dbc;

        public async Task<int> AddFrameJsonAsync(string frameJson)
        {
            SimulationFrame frame = new SimulationFrame
            {
                FrameJson = frameJson,
            };

            dbc.SimulationFrames.Add(frame);
            await dbc.SaveChangesAsync();

            return frame.Id;
        }

        public async Task<string?> GetFrameJsonByIdAsync(int id)
        {
            var entity = await this.dbc.SimulationFrames
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity?.FrameJson;
        }
    }
}