using IPL.Entities;
using static IPL.Models.Enums;

namespace IPL.Models
{
    public class TeamDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? Trophies { get; set; }
        public FanBaseType FanBaseType { get; set; }
        public string FancyName { get; set; }
        public List<PlayerDTO> players { get; set; }
    }
}
