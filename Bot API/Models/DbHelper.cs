using Bot_API.DataContext;

namespace Bot_API.Models
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        public List<ProduktModel> GetProdukts()
        {
            List<ProduktModel> response = new List<ProduktModel>();
            var dataList = _context.Products.ToList();
            dataList.ForEach(rows => response.Add(new ProduktModel()
            {
                Brand = rows.Brand,
                Id = rows.Id,
                Name = rows.Name,
                Price = rows.Price,
                Size = rows.Size
            }));
            return response;
        }

        public void SaveOrder()
        {

        }
    }
}
