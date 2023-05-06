using System.ComponentModel.DataAnnotations.Schema;

namespace Bot_API.EfCore
{
    [Table("tradingPair")]
    public class TradingPair
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("coinId")]
        public int CoinId { get; set; }

        [Column("coin")]
        public Coin? Coin { get; set; }

        [Column("quoteCoinId")]
        public int QuoteCoinId { get; set; }

        [Column("quoteCoin")]
        public Coin QuoteCoin { get; set; }

        [Column("exchangeId")]
        public int ExchangeId { get; set; }

        [Column("exchange")]
        public Exchange? Exchange { get; set; }
    }
}
