namespace HaydiKafem.Application.Dtos.IceCreamDtos
{
    public class CreateIceCreamDto
    {
        public string IceCreamName { get; set; }
        public string IceCreamImageUrl { get; set; }
        public decimal IceCreamPrice { get; set; }
        public string Description { get; set; }
    }
}
