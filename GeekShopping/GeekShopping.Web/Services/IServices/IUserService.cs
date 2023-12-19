using GeekShopping.Web.Data.ValueObjects;
using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices;

public interface IUserService
{
    Task<UserAuthenticatedVO>  AuthenticateAsync(UserVO user);
    Task<IEnumerable<UserResult>> FindAll();
    Task<UserResult> FindById(long id);
    Task<User> FindByNameAndPassword(UserVO vo);
    Task<UserResult> Create(UserViewModel vo);
    Task<UserResult> Update(UserViewModelWithId vo);
    Task<bool> Delete(long id);
}
