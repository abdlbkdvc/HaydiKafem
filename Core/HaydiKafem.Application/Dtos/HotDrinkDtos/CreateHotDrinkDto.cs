namespace HaydiKafem.Application.Dtos.HotDrinkDtos
{
    public class CreateHotDrinkDto
    {
        public string HotDrinkName { get; set; }
        public string HotDrinkImageUrl { get; set; }
        public decimal HotDrinkPrice { get; set; }
        public string Description { get; set; }
    }
}
