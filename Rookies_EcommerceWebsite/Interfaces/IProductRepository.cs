using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> Search(string searchString);
        Task<Product> Create(Product entity);
        Task<Product> Update(string id, Product entity);
        Task Delete(string id);
        Task<Product> GetBySlug(string slug);
        Task<Product> GetById(string id);
        Task Save();
    }
}
