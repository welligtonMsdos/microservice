using GeekShoppingUserAPI.Test.Data.ValueObjects;
using GeekShoppingUserAPI.Test.Model;

namespace GeekShoppingUserAPI.Test.Repository;

internal class UserRepository : IUserRepository
{
    public UserRepository()
    {
            
    }
    public Task<UserResult> Create(UserViewModel vo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserResult>> FindAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserViewModelWithId> FindById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByNameAndPassword(UserVO vo)
    {
        throw new NotImplementedException();
    }

    public Task<UserResult> Update(UserViewModelWithId vo)
    {
        throw new NotImplementedException();
    }
}
