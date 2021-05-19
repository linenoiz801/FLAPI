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
    public class VaultController : ApiController
    {
        private VaultService CreateVaultService()
        {
            return new VaultService();
        }
        public IHttpActionResult Get()
        {
            VaultService vaultService = CreateVaultService();
            var vaults = vaultService.GetVaults();
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
        public IHttpActionResult GetVaultsByGameId(int gameId)
        {
            VaultService vaultService = CreateVaultService();
            var vault = vaultService.GetVaultsByGameId(gameId);
            return Ok(vault);
        }
        public IHttpActionResult GetVaultById(int vaultId)
        {
            VaultService vaultService = CreateVaultService();
            var vault = vaultService.GetVaultById(vaultId);
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
        public IHttpActionResult Delete(int vaultId) 
        {
            var service = CreateVaultService();

            if (!service.DeleteVaults(vaultId))
                return InternalServerError();

            return Ok();
        }
            
    }
}
