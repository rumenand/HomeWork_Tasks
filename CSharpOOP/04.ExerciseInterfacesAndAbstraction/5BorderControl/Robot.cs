
namespace _5BorderControl
{
    class Robot : IID
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Id { get; set; }
        public string Model { get; set; }
    }
}
