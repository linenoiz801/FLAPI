using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FLAPI.Models;
using FLAPI.Services;

namespace FLAPI.WebAPI.Controllers
{
    public class LocationController : ApiController
    {
        private LocationService CreateLocationService()
        {
            return new LocationService();
        }
        public IHttpActionResult GetAll()
        {
            LocationService locationService = CreateLocationService();
            var histories = locationService.GetLocations();
            return Ok(histories);
        }
        //gt by game id method

        //public IHttpActionResult GetByGameId(int gameId)
        //{
        //    LocationService locationService = CreateLocationService();
        //    var location = locationService.GetLocationByGameId(gameId);
        //    return Ok(location);
        //} 
        public IHttpActionResult GetById(int locationId)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationById(locationId);
            return Ok(location);
        }
        public IHttpActionResult Post(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }       
        public IHttpActionResult Put(LocationListItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.UpdateLocation(model))
                return InternalServerError();

            return Ok();
        }  
        public IHttpActionResult Delete(int locationId)
        {
            var service = CreateLocationService();

            if (!service.DeleteLocation(locationId))
                return InternalServerError();

            return Ok();
        }

 

    }
}
