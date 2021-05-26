using FLAPI.Models;
using FLAPI.Services;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FLAPI.WebAPI.Controllers
{
    public class GameController : ApiController
    {
        private GamesServices CreateGameService()
        {
            return new GamesServices();
        }
        public IHttpActionResult GetAll()
        {
            GamesServices gameService = CreateGameService();
            var games = gameService.GetGame();
            return Ok(games);
        }
        public IHttpActionResult GetById(int gameId)
        {
            GamesServices gameService = CreateGameService();
            var game = gameService.GetGameById(gameId);
            return Ok(game);
        }

        public IHttpActionResult Post(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame(game))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(GameListItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.UpdateGame(model))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int gameId)
        {
            var service = CreateGameService();

            if (!service.DeleteGame(gameId))
                return InternalServerError();

            return Ok();
        }

    }
}