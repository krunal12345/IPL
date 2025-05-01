using System.ComponentModel.DataAnnotations.Schema;

namespace IPL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int TotalRunsScored { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        [NotMapped]
        public string Name
        {
            get
            {
                return this.FirstName + " " + this.LastName; 
            }
        }
    }
}
