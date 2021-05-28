using FLAPI.Models;
using FLAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FLAPI.WebAPI.Controllers
{
    [Authorize]
    public class CharacterController : ApiController
    {
        private CharacterService CreateCharacterService()
        {
            var characterService = new CharacterService();
            return characterService;
        }
        public IHttpActionResult GetAllCharacters()
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacters();
            return Ok(characters);
        }
        public IHttpActionResult GetCharacterByID(int characterId)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterById(characterId);
            return Ok(character);
        }
        public IHttpActionResult GetCharactersByGameId(int gameId)
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacterByGameId(gameId);
            return Ok(characters);
        }
        public IHttpActionResult Post(CharacterCreate character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCharacterService();

            if (!service.CreateCharacter(character))
                return InternalServerError();

            return Ok();
        }
        [HttpPost]
        public IHttpActionResult AddVaultToCharacter(int characterId, int vaultId)
        {
            var service = CreateCharacterService();

            if (!service.AddVaultToCharacter(vaultId, characterId))
                return InternalServerError();

            return Ok();
        }
        [HttpPost]
        public IHttpActionResult AddLocationToCharacter(int characterId, int locationId)
        {
            var service = CreateCharacterService();

            if (!service.AddLocationToCharacter(locationId, characterId))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int characterId)
        {
            var service = CreateCharacterService();
            if (!service.DeleteCharacter(characterId))
                return InternalServerError();

            return Ok();
        }
    }
}
