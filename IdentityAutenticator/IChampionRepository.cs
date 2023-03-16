using GameBackEnd.Domain.Inventory.Models;

namespace IdentityAutenticator
{
    public interface IChampionRepository
    {
        Task<List<Champion>> GetChampionsByUserId(string userId);
    }
}