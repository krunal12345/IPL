using IPL.Entities;

namespace IPL.Models
{
    public class PlayerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int TotalRunsScored { get; set; }
        public string Name { get; set; }

        public int TeamId { get; set; }
    }
}
