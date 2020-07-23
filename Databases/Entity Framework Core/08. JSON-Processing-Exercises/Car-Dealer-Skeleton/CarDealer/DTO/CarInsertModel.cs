
namespace CarDealer.DTO
{
    public class CarInsertModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int TravelledDistance { get; set; }
        public int [] PartsId { get; set; }
    }
}
