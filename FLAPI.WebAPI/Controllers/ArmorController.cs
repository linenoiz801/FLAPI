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
    public class ArmorController : ApiController
    {
        private ArmorService CreateArmorService()
        {
            return new ArmorService();
        }
        public IHttpActionResult GetAll()
        {
            ArmorService armorService = CreateArmorService();
            var armors = armorService.GetArmors();
            foreach (ArmorListItem h in armors)
            {
                if (h.GameId != null)
                    h.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + h.GameId;
                if (h.HistoryId != null)
                    h.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + h.HistoryId;
            }
            return Ok(armors);
        }
        public IHttpActionResult GetByGameId(int gameId)
        {
            ArmorService armorService = CreateArmorService();
            var armors = armorService.GetArmorsByGameId(gameId);
            foreach (ArmorListItem h in armors)
            {
                if (h.GameId != null)
                    h.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + h.GameId;
                if (h.HistoryId != null)
                    h.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + h.HistoryId;
            }
            return Ok(armors);
        }
        public IHttpActionResult GetById(int armorId)
        {
            ArmorService armorService = CreateArmorService();
            var armor = armorService.GetArmorById(armorId);
            if (armor.GameId != null)
                armor.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + armor.GameId;
            if (armor.HistoryId != null)
                armor.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + armor.HistoryId;
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
