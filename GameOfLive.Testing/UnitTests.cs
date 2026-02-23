namespace GameOfLive.Testing
{
    using GameOfLive.Lib.DB.Business;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class UnitTests
    {
        [Fact]
        public async Task AddFrameJsonAsync_Should_Return_Id_Greater_Than_Zero()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await using var context = new DatabaseContext(options);
            var service = new SimulationFrameSavingService(context);

            string testJson = "[[1,0],[0,1]]";

            // Act
            int id = await service.AddFrameJsonAsync(testJson);

            // Assert
            Assert.True(id > 0);
        }

        [Fact]
        public async Task GetFrameJsonByIdAsync_Should_Return_not_null()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await using var context = new DatabaseContext(options);
            var service = new SimulationFrameSavingService(context);

            string testJson = "[[1,0],[0,1]]";

            // Act
            int id = await service.AddFrameJsonAsync(testJson);
            string? frameJson = await service.GetFrameJsonByIdAsync(id);

            // Assert
            Assert.True(frameJson != null);
        }
    }
}