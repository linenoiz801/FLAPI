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
            return Ok(weapons);
        }
        public IHttpActionResult GetWeaponsByGameId(int gameId)
        {
            WeaponService weaponService = CreateWeaponService();
            var weapons = weaponService.GetWeaponByGameId(gameId);
            return Ok(weapons);
        }
        public IHttpActionResult GetWeaponById(int weaponId)
        {
            WeaponService weaponService = CreateWeaponService();
            var weapon = weaponService.GetWeaponById(weaponId);
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
