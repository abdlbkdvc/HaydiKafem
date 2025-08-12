namespace HaydiKafem.Application.Dtos.Food
{
    public class CreateFoodDto
    {
        public string FoodName { get; set; }
        public string FoodImageUrl { get; set; }
        public decimal FoodPrice { get; set; }
        public string Description { get; set; }
    }
}
