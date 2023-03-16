using GameBackEnd.Application.Inventory.ApplicationServices.Dto;

namespace GameBackEnd.Application.Inventory.ApplicationServices
{
    public interface IChampionsService
    {
        Task<IEnumerable<ChampionDto>> GetChampions(string userId);
    }
}