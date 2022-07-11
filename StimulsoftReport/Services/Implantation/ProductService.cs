using StimulsoftReport.Entities;
using StimulsoftReport.Services.Interfaces;
using StimulsoftReport.ViewModels.Product;

namespace StimulsoftReport.Services.Implantation
{
    public class ProductService : IProductService
    {
        private StimulsoftDBContext _context;
        public ProductService(StimulsoftDBContext context)
        {
            _context = context;
        }
        public List<ProductViewModel> GetListProducts()
        {
            try
            {
                var product = _context.Products.Select(e => new ProductViewModel
                {
                  CategoryId = e.CategoryId,
                  ProductId = e.ProductId,
                  ProductName = e.ProductName,
                  Discontinued = e.Discontinued,
                  QuantityPerUnit = e.QuantityPerUnit,
                  UnitPrice = e.UnitPrice,
                  ReorderLevel = e.ReorderLevel,
                  SupplierId = e.SupplierId,
                  UnitsInStock = e.UnitsInStock,
                  UnitsOnOrder = e.UnitsOnOrder
                }).ToList();
                return product;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
