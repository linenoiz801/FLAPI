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
    public class ArmorController : ApiController
    {
        private ArmorService CreateArmorService()
        {
            return new ArmorService();
        }
        public IHttpActionResult GetAll()
        {
            ArmorService armorService = CreateArmorService();
            var histories = armorService.GetArmors();
            return Ok(histories);
        }
        public IHttpActionResult GetByGameId(int gameId)
        {
            ArmorService armorService = CreateArmorService();
            var armors = armorService.GetArmorsByGameId(gameId);
            return Ok(armors);
        }
        public IHttpActionResult GetById(int armorId)
        {
            ArmorService armorService = CreateArmorService();
            var armor = armorService.GetArmorById(armorId);
            return Ok(armor);

        }
        public IHttpActionResult Post(ArmorCreate armor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArmorService();

            if (!service.CreateArmor(armor))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(ArmorListItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArmorService();
            if (!service.UpdateArmor(model))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int armorId)
        {
            var service = CreateArmorService();
            if (!service.DeleteArmor(armorId))
                return InternalServerError();

            return Ok();
        }

    }
}
