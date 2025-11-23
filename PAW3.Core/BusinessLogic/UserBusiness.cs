using PAW3.Data.Repositories;
using PAW3.Models.DTO;
using PAW3.Models.Entities;
using System.Threading.Tasks;

namespace PAW3.Core.BusinessLogic;

public interface IUserBusiness
{
    /// <summary>
    /// Deletes the user associated with the user id.
    /// </summary>
    /// <param name="id">The user id.</param>
    /// <returns>True if deletion was successful, false otherwise.</returns>
    Task<bool> DeleteUserAsync(int id);

    /// <summary>
    /// Gets users. If id is provided, returns only that user; otherwise returns all users.
    /// </summary>
    /// <param name="id">Optional user id.</param>
    /// <returns>A collection of users.</returns>
    Task<UserDTO> GetUsers(int? id);

    /// <summary>
    /// Saves a user (creates or updates).
    /// </summary>
    /// <param name="user">The user to save.</param>
    /// <returns>True if save was successful, false otherwise.</returns>
    Task<bool> SaveUserAsync(User user);
}

public class UserBusiness(IRepositoryUser repositoryUser) : IUserBusiness
{
    /// <inheritdoc />
    public async Task<bool> SaveUserAsync(User user)
    {
        return await repositoryUser.UpdateAsync(user);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await repositoryUser.FindAsync(id);
        if (user == null) return false;
        return await repositoryUser.DeleteAsync(user);
    }

    /// <inheritdoc />
    public async Task<UserDTO> GetUsers(int? id)
    {
        var hasId = id.HasValue;
        var userDto = new UserDTO();

        var users = !hasId
            ? await repositoryUser.ReadAsync()
            : [await repositoryUser.FindAsync((int)id)];

        if (!hasId && users != null && users.Any())
        {
            userDto.Summaries.AddRange(users.Select(x => new
            {
                Id = x.UserId,
                Name = x.Username,
                Value = 0.00M,
            })
            .GroupBy(y => y.Name)
            .SelectMany(g => g.Select(sub => new Summary
            {
                Id = sub.Id,
                Name = sub.Name ?? "",
                Value = 0.00M,
                Count = g.Count()
            })).OrderByDescending(x => x.Count));
        }
        userDto.Users = users;
        return userDto;
    }
}

