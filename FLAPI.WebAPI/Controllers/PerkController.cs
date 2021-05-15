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
    public class PerkController : ApiController
    {
        private PerkService CreatePerkService()
        {
            return new PerkService();
        }
        public IHttpActionResult GetAll()
        {
            PerkService perkService = CreatePerkService();
            var histories = perkService.GetPerks();
            return Ok(histories);
        }
        public IHttpActionResult GetByGameId(int gameId)
        {
            PerkService perkService = CreatePerkService();
            var perks = perkService.GetPerksByGameId(gameId);
            return Ok(perks);
        }
        public IHttpActionResult GetById(int perkId)
        {
            PerkService perkService = CreatePerkService();
            var perk = perkService.GetPerkById(perkId);
            return Ok(perk);

        }
        public IHttpActionResult Post(PerkCreate perk)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePerkService();

            if (!service.CreatePerk(perk))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(PerkListItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePerkService();
            if (!service.UpdatePerk(model))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int perkId)
        {
            var service = CreatePerkService();
            if (!service.DeletePerk(perkId))
                return InternalServerError();

            return Ok();
        }
    }
}
