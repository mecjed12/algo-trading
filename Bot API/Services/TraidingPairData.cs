using Bot_API.EfCore;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Bot_API.Services
{
    public class TraidingPairData : ITraidingData
    {
        private readonly IEF_DataContext _context;

        public TraidingPairData(IEF_DataContext context)
        {
            _context = context;
        }

        public class PairData
        {
            public string? Name { get; set; }
            public string? UrlSymbol { get; set; }
            public string? BaseDecimalCurrency { get; set; }
            public string? CounterDecimalCurrency { get; set; }
            public string? InstantOrderCounterDecimal { get; set; }
            public string? MinimumOrder { get; set; }
            public string? TradingEngine { get; set; }
            public string? OrderStatus { get; set; }
            public string? Description { get; set; }
        }

        public async Task ScrapTradingPairData()
        {
            string url = "https://www.bitstamp.net/api/v2/trading-pairs-info/";

            List<PairData> pairs = new List<PairData>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if(!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failer to get data : {response.StatusCode}");
                }

                var data = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"{data}");

                var tradingPairData = pairs.Select(o => new TradingPair
                {
                    Name = o.Name,
                    UrlSymbol = o.UrlSymbol,
                    BaseDecimalCurrency = decimal.Parse(o.BaseDecimalCurrency, CultureInfo.InvariantCulture),
                    CounterDecimalCurrency = decimal.Parse(o.CounterDecimalCurrency, CultureInfo.InvariantCulture),
                    InstantOrderCounterDecimal = decimal.Parse(o.CounterDecimalCurrency,CultureInfo.InvariantCulture),
                    MinimumOrder = int.Parse(o.MinimumOrder, CultureInfo.InvariantCulture),
                    TradingEngine = o.TradingEngine,
                    OrderStatus = o.OrderStatus,
                    Description = o.Description,
                });
                
                await _context.SaveChangesAsync();
            }
        }


    }
}
