using GeekShopping.UserAPI.Data.ValueObjects;
using GeekShopping.UserAPI.Model;

namespace GeekShopping.UserAPI.Repository;

public interface IUserRepository
{
    Task<IEnumerable<UserResult>> FindAll();
    Task<UserViewModelWithId> FindById(long id);
    Task<User> FindByNameAndPassword(UserVO vo);
    Task<UserResult> Create(UserViewModel vo);
    Task<UserResult> Update(UserViewModelWithId vo);
    Task<bool> Delete(long id);
}
