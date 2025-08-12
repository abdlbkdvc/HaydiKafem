namespace HaydiKafem.Domain.Entities
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodImageUrl { get; set; }
        public decimal FoodPrice { get; set; }
        public string Description { get; set; }
    }
}
