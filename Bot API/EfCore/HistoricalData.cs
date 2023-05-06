using System.ComponentModel.DataAnnotations.Schema;

namespace Bot_API.EfCore
{
    [Table("historiacalData")]
    public class HistoricalData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("tradingPairId")]
        public int TradingPairId { get; set; }

        [Column("tradingPair")]
        public TradingPair TradingPair { get; set; }

        [Column("timeStamp")]
        public DateTime TimeStamp { get; set; }

        [Column("open")]
        public decimal Open { get; set; }

        [Column("high")]
        public decimal High { get; set; }

        [Column("low")]
        public decimal Low { get; set; }

        [Column("close")]
        public decimal Close { get; set; }

        [Column("volume")]
        public decimal Volume { get; set; }
    }
}
