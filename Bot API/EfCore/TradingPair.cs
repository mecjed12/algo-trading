using System.ComponentModel.DataAnnotations.Schema;

namespace Bot_API.EfCore
{
    [Table("tradingPair")]
    public class TradingPair
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("Tradingpair name")]
        public string? Name { get; set; }

        [Column("url_symbol")]
        public string? UrlSymbol { get; set; }

        [Column("Decimal precision for currency")]
        public decimal BaseDecimalCurrency { get; set; }

        [Column("Decimal precision for counter currency")]
        public decimal CounterDecimalCurrency { get; set; }

        [Column("Decimal precision for buy/sell orders")]
        public decimal InstantOrderCounterDecimal { get; set; }

        [Column("Minum Order")]
        public int MinimumOrder { get; set; }

        [Column("Trading Engine Status")]
        public string? TradingEngine { get; set; }

        [Column("Market order status")]
        public string? OrderStatus { get; set; }

        [Column("Trading pair description")]
        public string? Description { get; set; }
    }
}
