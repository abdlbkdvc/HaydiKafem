namespace HaydiKafem.Application.Dtos.FooterAddressDtos
{
    public class GetByIdFooterAddressDto
    {
        public int FooterAddressId { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string PinterestUrl { get; set; }
    }
}
