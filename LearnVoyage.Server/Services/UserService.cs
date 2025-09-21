using System;
using Microsoft.EntityFrameworkCore;
using LearnVoyage.Server.Data;
using LearnVoyage.Server.Models;

namespace LearnVoyage.Server.Services;

public class UserService
{
    private readonly AppDbContext _appDbcontext;

    // DI経由でAppDbcontextをフィールドへ依存注入
    public UserService(AppDbContext appDbContext)
    {
        _appDbcontext = appDbContext;
    }

    // 全権取得の機能
    public async Task<List<User>> GetAllUserAsync()
    {
        return await _appDbcontext.Users.ToListAsync();
    }
}