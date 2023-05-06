using System.ComponentModel.DataAnnotations.Schema;

namespace Bot_API.EfCore
{
    [Table("exchange")]
    public class Exchange
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
