namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
