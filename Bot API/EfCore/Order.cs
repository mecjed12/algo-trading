using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bot_API.EfCore
{
    [Table("order")]
    public class Order
    {
        [Key, Required]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
