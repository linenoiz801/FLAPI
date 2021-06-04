using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        private CharacterService CreateCharacterService()
        {
            return new CharacterService();
        }
        public IHttpActionResult GetAll()
        {
            LocationService locationService = CreateLocationService();
            var locations = locationService.GetLocations();
            foreach (LocationListItem h in locations)
            {
                h.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + h.GameId;
                h.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + h.HistoryId;
            }
            return Ok(locations);
        }
        //gt by game id method

        public IHttpActionResult GetByGameId(int gameId)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationByGameId(gameId);
            foreach (LocationListItem h in location)
            {
                h.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + h.GameId;
                h.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + h.HistoryId;
            }
            return Ok(location);
        }
        public IHttpActionResult GetById(int locationId)
        {
          
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationById(locationId);

            location.GameURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/Game?GameId=" + location.GameId;
            location.HistoryURL = "https://" + HttpContext.Current.Request.Url.Authority + "/api/History?HistoryId=" + location.HistoryId;
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
        public IHttpActionResult AddCharacterToLocation(int characterId, int locationId)
        {
            var service = CreateLocationService();

            if (!service.AddCharacterToLocation(locationId, characterId))
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
         public IHttpActionResult GetCharactersByLocationId(int locationId)
        {
            CharacterService characterService = CreateCharacterService();
            var location = characterService.GetAllCharactersByLocationId(locationId);
            return Ok(location);
        
        }
    }
}
