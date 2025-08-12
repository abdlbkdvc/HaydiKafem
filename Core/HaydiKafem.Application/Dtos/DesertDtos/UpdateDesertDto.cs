namespace HaydiKafem.Application.Dtos.DesertDtos
{
    public class UpdateDesertDto
    {
        public int DesertId { get; set; }
        public string DesertName { get; set; }
        public string DesertImageUrl { get; set; }
        public decimal DesertPrice { get; set; }
        public string Description { get; set; }
    }
}
