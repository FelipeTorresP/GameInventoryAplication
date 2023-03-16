using GameBackEnd.Application.Inventory.ApplicationServices;
using GameBackEnd.Domain.Inventory.Models;
using IdentityAutenticator;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameBackEnd.Tests.UnitTests.Application
{
    [TestClass]
    public class ChampionsServiceTests
    {
        private Mock<IChampionRepository>? _championRepositoryMock;
        private IChampionsService? _championsService;

        [TestInitialize]
        public void Initialize()
        {
            _championRepositoryMock = new Mock<IChampionRepository>();
            _championsService = new ChampionsService(_championRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetChampions_WithValidUserId_ReturnsChampionDtos()
        {
            // Arrange
            string userId = "testUserId";
            var champions = new List<Champion>
            {
            new Champion { Id = "123", Name = "Champion1", Description = "Champion1 Description", Stats = 1, Level = 1, Attributes= new ChampionAttributes{ Ascension ="", Claws="", CoreEssence="", Divinity="", Edition="", Family="", Horns="", Piercing="", Tail="", Wings="" } },
            new Champion { Id = "432", Name = "Champion2", Description = "Champion2 Description", Stats = 2, Level = 2, Attributes= new ChampionAttributes{ Ascension ="", Claws="", CoreEssence="", Divinity="", Edition="", Family="", Horns="", Piercing="", Tail="", Wings="" } }    };
            _championRepositoryMock.Setup(x => x.GetChampionsByUserId(userId)).ReturnsAsync(champions);

            // Act
            var result = await _championsService.GetChampions(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(champions.Count, result.Count());

            foreach (var championDto in result)
            {
                var champion = champions.SingleOrDefault(x => x.Id == championDto.Id);
                Assert.IsNotNull(champion);
                Assert.AreEqual(champion.Name, championDto.Name);
                Assert.AreEqual(champion.Description, championDto.Description);
                Assert.AreEqual(champion.Attributes.Claws ?? "", championDto.Claws);
                Assert.AreEqual(champion.Attributes.CoreEssence ?? "", championDto.CoreEssence);
                Assert.AreEqual(champion.Attributes.Divinity ?? "", championDto.Divinity);
                Assert.AreEqual(champion.Attributes.Edition ?? "", championDto.Edition);
                Assert.AreEqual(champion.Attributes.Family ?? "", championDto.Family);
                Assert.AreEqual(champion.Attributes.Horns ?? "", championDto.Horns);
                Assert.AreEqual(champion.Attributes.Piercing ?? "", championDto.Piercing);
                Assert.AreEqual(champion.Attributes.Tail ?? "", championDto.Tail);
                Assert.AreEqual(champion.Attributes.Wings ?? "", championDto.Wings);
            }
        }

        [TestMethod]
        public async Task GetChampions_WithInvalidUserId_ReturnsEmptyList()
        {
            // Arrange
            string userId = "testUserId";
            _championRepositoryMock.Setup(x => x.GetChampionsByUserId(userId)).ReturnsAsync(new List<Champion>());

            // Act
            var result = await _championsService.GetChampions(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
