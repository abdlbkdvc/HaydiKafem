namespace HaydiKafem.Application.Dtos.ColdDrinkDtos
{
    public class CreateColdDrinkDto
    {
        public string ColdDrinkName { get; set; }
        public string ColdDrinkImageUrl { get; set; }
        public decimal ColdDrinkPrice { get; set; }
        public string Description { get; set; }
    }
}
