using Business.Models;

namespace dotnet_rpg.DataProvider.DataServices
{
    public class AddCharacterDTO
    {
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Stength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; }
    }
}
