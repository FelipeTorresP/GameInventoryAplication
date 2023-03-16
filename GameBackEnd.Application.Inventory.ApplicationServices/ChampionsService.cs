using GameBackEnd.Application.Inventory.ApplicationServices.Dto;
using IdentityAutenticator;

namespace GameBackEnd.Application.Inventory.ApplicationServices
{
    public class ChampionsService : IChampionsService
    {
        private readonly IChampionRepository _championRepository;

        public ChampionsService(IChampionRepository championRepository)
        {
            _championRepository = championRepository;
        }

        public async Task<IEnumerable<ChampionDto>> GetChampions(string userId)
        {
            var inventory = await _championRepository.GetChampionsByUserId(userId);

            return inventory.Select(c => new ChampionDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Stats = c.Stats,
                Levels = c.Level,
                Ascension = c.Attributes.Ascension ?? "",
                Claws = c.Attributes.Claws ?? "",
                CoreEssence = c.Attributes.CoreEssence ?? "",
                Divinity = c.Attributes.Divinity ?? "",
                Edition = c.Attributes.Edition ?? "",
                Family = c.Attributes.Family ?? "",
                Horns = c.Attributes.Horns ?? "",
                Piercing = c.Attributes.Piercing ?? "",
                Tail = c.Attributes.Tail ?? "",
                Wings = c.Attributes.Wings ?? ""
            });
        }
    }
}