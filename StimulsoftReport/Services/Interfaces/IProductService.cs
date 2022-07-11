using StimulsoftReport.ViewModels.Product;

namespace StimulsoftReport.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetListProducts();
    }
}
