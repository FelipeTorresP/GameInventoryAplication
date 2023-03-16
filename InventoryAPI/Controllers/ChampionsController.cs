using GameBackEnd.Application.Inventory.ApplicationServices;
using GameBackEnd.Application.Inventory.ApplicationServices.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChampionsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IChampionsService _championsService;

        public ChampionsController(IAuthenticationService authenticationService, IChampionsService championsService)
        {
            _authenticationService = authenticationService;
            _championsService = championsService;
        }

        [HttpGet("inventory")]
        [Authorize]
        public async Task<ActionResult<List<ChampionDto>>> GetInventory()
        {
            // Obtener el id del usuario a partir del token

            var userId = _authenticationService?.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("No se puede obtener el id del usuario desde el token.");
            }

            // Realizar una consulta al servicio de inventario para obtener la lista de campeones del usuario
            var champions = await _championsService.GetChampions(userId);

            if (champions == null)
            {
                return NotFound();
            }
            // Devolver la lista de campeones como respuesta
            return Ok(champions);
        }
    }
}