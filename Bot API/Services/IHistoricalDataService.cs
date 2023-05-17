namespace Bot_API.Services
{
    public interface IHistoricalDataService
    {
        Task ScrapTheHIstoricalData();
        Task DeleteTheHistoricalDataSet(int id);
    }
}
