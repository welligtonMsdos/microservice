using GeekShopping.UserAPI.Data.ValueObjects;
using GeekShopping.UserAPI.Model;

namespace GeekShopping.UserAPI.Repository;

public interface IUserRepository
{
    Task<IEnumerable<UserVO>> FindAll();
    Task<User> FindById(long id);
    Task<User> FindByNameAndPassword(string userName,string password);
    Task<UserVO> Create(UserVO vo);
    Task<UserVO> Update(UserVO vo);
    Task<bool> Delete(long id);
}
