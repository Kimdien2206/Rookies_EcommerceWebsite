namespace Rookies_EcommerceWebsite.Interfaces
{
    public interface IAuthRepository
    {

        public Task<IResult> Login(string email, string password);
        public Task<IResult> Register(string userName, string email, string password);

    }
}
