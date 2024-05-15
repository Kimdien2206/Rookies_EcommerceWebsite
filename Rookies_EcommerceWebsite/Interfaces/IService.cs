namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IService<T>
    {
        Task<IResult> GetById(string id);
        Task<IResult> GetAll();
        Task<IResult> Create(T entity);
        Task<IResult> Delete(string id);
        Task<IResult> Update(string id, T entity);
    }
}
