using Bot_API.EfCore;

namespace Bot_API.Models
{
    public class HistoricalDataModel
    {
        public int Id { get; set; }

        public int TradingPairId { get; set; }

        public TradingPair TradingPair { get; set; }

        public int TimeStamp { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }
    }
}
