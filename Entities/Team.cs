using static IPL.Models.Enums;

namespace IPL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? Trophies { get; set; }
        public FanBaseType FanBaseType { get; set; }

        public string FancyName { get; set; }

        public List<Player> Players { get; set; }
    }
}
