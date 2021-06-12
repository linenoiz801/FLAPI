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
    public class WeaponController : ApiController
    {
        private WeaponService CreateWeaponService()
        {
            return new WeaponService();
        }
        public IHttpActionResult GetAllWeapons()
        {
            WeaponService weaponService = CreateWeaponService();
            var weapons = weaponService.GetWeapons();
            foreach (WeaponListItem h in weapons)
            {
                if (h.HistoryId != null)
                    h.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + h.HistoryId;

                if (h.GameId != null)
                    h.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + h.GameId;
            }
            return Ok(weapons);
        }
        public IHttpActionResult GetWeaponsByGameId(int gameId)
        {
            WeaponService weaponService = CreateWeaponService();
            var weapons = weaponService.GetWeaponByGameId(gameId);
            foreach (WeaponListItem h in weapons)
            {
                if (h.HistoryId != null)
                    h.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + h.HistoryId;

                if (h.GameId != null)
                    h.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + h.GameId;
            }
            return Ok(weapons);
        }
        public IHttpActionResult GetWeaponById(int weaponId)
        {
            WeaponService weaponService = CreateWeaponService();
            var weapon = weaponService.GetWeaponById(weaponId);
            if (weapon.HistoryId != null)
                weapon.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + weapon.HistoryId;

            if (weapon.GameId != null)
                weapon.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + weapon.GameId;
            return Ok(weapon);
        }
        public IHttpActionResult Post(WeaponCreate weapon)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWeaponService();

            if (!service.CreateWeapon(weapon))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(WeaponListItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWeaponService();

            if (!service.UpdateWeapon(model))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int weaponId)
        {
            var service = CreateWeaponService();

            if (!service.DeleteWeapon(weaponId))
                return InternalServerError();

            return Ok();
        }

    }
}
