using FLAPI.Models;
using FLAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FLAPI.WebAPI.Controllers
{
    //[Authorize]
    public class VaultController : ApiController
    {
        private VaultService CreateVaultService()
        {
            return new VaultService();
        }
        private CharacterService CreateCharacterService()
        {
            return new CharacterService();
        }
        public IHttpActionResult Get()
        {
            VaultService vaultService = CreateVaultService();
            var vaults = vaultService.GetVaults();
            foreach (VaultListItem h in vaults)
            {
                if (h.GameId != null)
                    h.GameUrl = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + h.GameId;
                if (h.LocationId != null)
                    h.LocationUrl = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Location?LocationId=" + h.LocationId;
            }
            return Ok(vaults);
        }
        public IHttpActionResult Post(VaultCreate vault)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVaultService();

            if (!service.CreateVault(vault))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult GetCharactersByVaultId(int characterVaultId)
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetAllCharactersByVaultId(characterVaultId);
            return Ok(characters);
        }
        public IHttpActionResult GetVaultsByGameId(int gameId)
        {
            VaultService vaultService = CreateVaultService();
            var vault = vaultService.GetVaultsByGameId(gameId);
            foreach (VaultListItem h in vault)
            {
                if (h.GameId != null)
                    h.GameUrl = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + h.GameId;
                if (h.LocationId != null)
                    h.LocationUrl = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Location?LocationId=" + h.LocationId;
            }
            return Ok(vault);
        }
        public IHttpActionResult GetVaultById(int vaultId)
        {
            VaultService vaultService = CreateVaultService();
            var vault = vaultService.GetVaultById(vaultId);
                if (vault.GameId != null)
                    vault.GameUrl = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + vault.GameId;
                if (vault.LocationId != null)
                    vault.LocationUrl = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Location?LocationId=" + vault.LocationId;
            return Ok(vault);
        }
        public IHttpActionResult Put(VaultListItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVaultService();

            if (!service.UpdateVault(model))
                return InternalServerError();

            return Ok();
        }
        [HttpPost]
        public IHttpActionResult AddCharacterToVault(int characterId, int vaultId)
        {
            var service = CreateVaultService();

            if (!service.AddCharacterToVault(characterId, vaultId))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int vaultId) 
        {
            var service = CreateVaultService();

            if (!service.DeleteVaults(vaultId))
                return InternalServerError();

            return Ok();
        }
            
    }
}
