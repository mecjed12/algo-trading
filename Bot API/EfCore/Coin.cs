﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Bot_API.EfCore
{
    [Table("coins")]
    public class Coin
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("symbol")]
        public string Symbol { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
