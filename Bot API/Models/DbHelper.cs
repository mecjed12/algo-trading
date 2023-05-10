using Bot_API.DataContext;
using Bot_API.EfCore;

namespace Bot_API.Models
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        // Get
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

        public ProduktModel GetProductById(int id)
        {
            ProduktModel response = new ProduktModel();
            var rows = _context.Products.Where(o => o.Id.Equals(id)).FirstOrDefault();
            return new ProduktModel()
            {
                Brand = rows.Brand,
                Id = rows.Id,
                Name = rows.Name,
                Price = rows.Price,
                Size = rows.Size
            };
        }

        //It Serve the Post/Put/Patch
        public void SaveOrder(OrderModel orderModel)
        {
            Order dbTable = new Order();
            if(orderModel.Id > 0)
            {
                dbTable = _context.Orders.Where(o => o.Id.Equals(orderModel.Id)).FirstOrDefault();
                if(dbTable != null)
                {
                    dbTable.Phone = orderModel.Phone;
                    dbTable.Address = orderModel.Address;
                }
                else
                {
                    dbTable.Phone = orderModel.Phone;
                    dbTable.Address = orderModel.Address;
                    dbTable.Name = orderModel.Name;
                    dbTable.Product = _context.Products.Where(o => o.Id.Equals(orderModel.ProductId)).FirstOrDefault();
                    _context.Orders.Add(dbTable);
                }
                _context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Where(o => o.Id.Equals(id)).FirstOrDefault();
            if(order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
