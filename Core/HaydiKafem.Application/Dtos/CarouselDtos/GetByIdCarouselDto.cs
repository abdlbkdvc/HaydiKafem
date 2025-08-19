namespace HaydiKafem.Application.Dtos.CarouselDtos
{
    public class GetByIdCarouselDto
    {
        public int CarouselId { get; set; }
        public string RestourantName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
