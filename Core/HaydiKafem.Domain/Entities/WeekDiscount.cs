namespace HaydiKafem.Domain.Entities
{
    public class WeekDiscount
    {
        public int WeekDiscountId { get; set; }
        public string DiscountDay { get; set; }
        public string DiscountPercent { get; set; }
    }
}
