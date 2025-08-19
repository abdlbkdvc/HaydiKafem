namespace HaydiKafem.Application.Dtos.WeekDiscountDtos
{
    public class GetByIdWeekDiscountDto
    {
        public int WeekDiscountId { get; set; }
        public string DiscountDay { get; set; }
        public string DiscountPercent { get; set; }
    }
}
