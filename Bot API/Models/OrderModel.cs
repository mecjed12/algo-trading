using Bot_API.EfCore;

namespace Bot_API.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
