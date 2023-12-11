using GeekShopping.UserAPI.Data.ValueObjects;
using GeekShopping.UserAPI.Model;

namespace GeekShopping.UserAPI.Repository;

public interface IUserRepository
{
    Task<IEnumerable<UserResult>> FindAll();
    Task<UserResult> FindById(long id);
    Task<User> FindByNameAndPassword(string userName,string password);
    Task<UserResult> Create(UserViewModel vo);
    Task<UserResult> Update(UserViewModelWithId vo);
    Task<bool> Delete(long id);
}
