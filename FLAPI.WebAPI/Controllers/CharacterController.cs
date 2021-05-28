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
    //[Authorize]
    public class CharacterController : ApiController
    {
        private CharacterService CreateCharacterService()
        {
            var characterService = new CharacterService();
            return characterService;
        } private LocationService CreateLocationService()
        {
            var locationService = new LocationService();
            return locationService;
        }
        private VaultService CreateVaultService()
        {
            var vaultService = new VaultService();
            return vaultService;
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
        public IHttpActionResult GetVaultsByCharacterId(int characterId)
        {
            VaultService vaultService = CreateVaultService();
            var vaults = vaultService.GetAllVaultsByCharacterId(characterId);
            return Ok(vaults);
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
        public IHttpActionResult AddVaultToCharacter(int vaultId, int characterId)
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
        public IHttpActionResult GetLocationsByCharacterId(int characterId)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetAllLocationsByCharacterId(characterId);
            return Ok(location);
        
        }
    }
}

