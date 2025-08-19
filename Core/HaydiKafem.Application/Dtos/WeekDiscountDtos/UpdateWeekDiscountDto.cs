namespace HaydiKafem.Application.Dtos.WeekDiscountDtos
{
    public class UpdateWeekDiscountDto
    {
        public int WeekDiscountId { get; set; }
        public string DiscountDay { get; set; }
        public string DiscountPercent { get; set; }
    }
}
