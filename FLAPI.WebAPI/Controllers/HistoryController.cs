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
    public class HistoryController : ApiController
    {
        private HistoryService CreateHistoryService()
        {
            return new HistoryService();
        }
        public IHttpActionResult GetAll()
        {
            HistoryService historyService = CreateHistoryService();
            var histories = historyService.GetHistories();
            return Ok(histories);
        }
        public IHttpActionResult GetByGameId(int gameId)
        {
            HistoryService historyService = CreateHistoryService();
            var histories = historyService.GetHistoriesByGameId(gameId);
            return Ok(histories);
        }
        public IHttpActionResult GetById(int historyId)
        {
            HistoryService historyService = CreateHistoryService();
            var history = historyService.GetHistoryById(historyId);
            return Ok(history);

        }
        public IHttpActionResult Post(HistoryCreate history)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateHistoryService();

            if (!service.CreateHistory(history))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(HistoryListItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateHistoryService();
            if (!service.UpdateHistory(model))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int historyId)
        {
            var service = CreateHistoryService();
            if (!service.DeleteHistory(historyId))
                return InternalServerError();

            return Ok();
        }
    }
}
