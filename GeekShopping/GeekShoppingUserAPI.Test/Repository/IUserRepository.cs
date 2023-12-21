using GeekShoppingUserAPI.Test.Data.ValueObjects;
using GeekShoppingUserAPI.Test.Model;

namespace GeekShoppingUserAPI.Test.Repository;

internal interface IUserRepository
{
    Task<IEnumerable<UserResult>> FindAll();
    Task<UserViewModelWithId> FindById(long id);
    Task<User> FindByNameAndPassword(UserVO vo);
    Task<UserResult> Create(UserViewModel vo);
    Task<UserResult> Update(UserViewModelWithId vo);
    Task<bool> Delete(long id);
}
