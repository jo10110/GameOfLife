using System.ComponentModel.DataAnnotations;

namespace GameOfLive.Lib.DB.Models
{
    public class SimulationFrame
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FrameJson { get; set; } = string.Empty;
    }
}
