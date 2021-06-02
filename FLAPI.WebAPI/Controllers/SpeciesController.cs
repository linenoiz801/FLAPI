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
    public class SpeciesController : ApiController
    {
        private SpeciesService CreateSpeciesService()
        {
            return new SpeciesService();
        }
        public IHttpActionResult Get()
        {
            SpeciesService speciesService = CreateSpeciesService();
            var species = speciesService.GetSpecies();
            return Ok(species);
        }
        public IHttpActionResult Post(SpeciesCreate species)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSpeciesService();

            if (!service.CreateSpecies(species))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult GetSpeciesByGameId(int gameId)
        {
            SpeciesService speciesService = CreateSpeciesService();
            var species = speciesService.GetSpeciesByGameId(gameId);
            return Ok(species);
        }
        public IHttpActionResult GetSpeciesById(int speciesId)
        {
            SpeciesService speciesService = CreateSpeciesService();
            var species = speciesService.GetSpeciesById(speciesId);
            return Ok(species);
        }
        public IHttpActionResult Put(SpeciesListItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSpeciesService();

            if (!service.UpdateSpecies(model))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int speciesId)
        {
            var service = CreateSpeciesService();

            if (!service.DeleteSpecies(speciesId))
                return InternalServerError();

            return Ok();
        }
        [HttpPost]
        public IHttpActionResult AddGameToSpecies(int gameId, int speciesId)
        {
            var service = CreateSpeciesService();

            if (!service.AddGameToSpecies(speciesId, gameId))
                return InternalServerError();

            return Ok();
        }

    }
}
