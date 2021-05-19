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
    }
}
