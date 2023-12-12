using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using SimpleShop.src.Api.Domains;

namespace SimpleShop.src.Api.Data.Seed;

/// <summary>
/// Seeds basic data to the database
/// </summary>
public class DataSeeder
{
    private readonly DataContext _dataContext;

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="dataContext"></param>
    public DataSeeder(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// Seed users 
    /// </summary>
    /// <returns></returns>
    public async Task SeedUsers()
    {
        var hasAnyRecord = await _dataContext.Users.AnyAsync().ConfigureAwait(false);

        if (hasAnyRecord)
            return;

        _dataContext.Users.AddRange(_users);
        await _dataContext.SaveChangesAsync().ConfigureAwait(false);
    }

    ///Users to seed
    private readonly IImmutableList<User> _users = ImmutableList.Create(
        new User(1, "Marie Curie"),
        new User(2, "Alain de Botton"),
        new User(3, "Linus Torvalds")
    );
}