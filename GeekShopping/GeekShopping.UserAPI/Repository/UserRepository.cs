﻿using AutoMapper;
using GeekShopping.UserAPI.Data.ValueObjects;
using GeekShopping.UserAPI.Model;
using GeekShopping.UserAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.UserAPI.Repository;

public class UserRepository : IUserRepository
{
    private readonly MySQLContext _context;
    private readonly IMapper _mapper;

    public UserRepository(MySQLContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

    public async Task<IEnumerable<UserVO>> FindAll()
    {
        var users = await _context.Users.ToListAsync();

        return _mapper.Map<List<UserVO>>(users);
    }

    public async Task<User> FindById(long id)
    {
        var user = await _context.Users
             .Where(p => p.Id == id)
             .FirstOrDefaultAsync() ?? new User();

        return user;
    }

    public async Task<User> FindByNameAndPassword(string userName, string password)
    {
        var user = await _context.Users
            .Where(p=> p.UserName.Equals(userName) && p.Password.Equals(password))
            .FirstOrDefaultAsync() ?? new User();

        return user;
    }

    public async Task<UserVO> Create(UserVO vo)
    {
        var user = _mapper.Map<User>(vo);

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return _mapper.Map<UserVO>(user);
    }

    public async Task<UserVO> Update(UserVO vo)
    {
        var user = _mapper.Map<User>(vo);

        _context.Users.Update(user);

        await _context.SaveChangesAsync();

        return _mapper.Map<UserVO>(user);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            var user = await _context.Users
                 .Where(p => p.Id == id)
                 .FirstOrDefaultAsync() ?? new User();

            if (user.Id <= 0) return false;

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}