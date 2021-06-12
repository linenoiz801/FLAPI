﻿using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class HistoryService
    {
        public object HttpContext { get; private set; }

        public bool CreateHistory(HistoryCreate model)
        {
            var entity =
                new History()
                {
                    EventName = model.EventName,
                    EventDate = model.EventDate,
                    Description = model.Description,
                    GameId = model.GameId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Histories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public List<HistoryListItem> GetHistoriesByGameId(int gameId)
        {
            List<HistoryListItem> result = new List<HistoryListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Histories
                        .Where(e => e.GameId == gameId) 
                        .Select(
                            e => new HistoryListItem
                            {
                                Id = e.Id,
                                EventName = e.EventName,
                                EventDate = e.EventDate,
                                Description = e.Description,
                                GameId = e.GameId
                            }
                        );
                return query.ToList();
            }
        }
        public IEnumerable<HistoryListItem> GetHistories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Histories
                        .Select(
                            e =>
                                new HistoryListItem
                                {
                                    Id = e.Id,
                                    EventName = e.EventName,
                                    EventDate = e.EventDate,
                                    Description = e.Description,
                                    GameId = e.GameId
                                }
                        );
                return query.ToArray();
            }
        }
        public HistoryListItem GetHistoryById(int historyId)
        {
            HistoryListItem result = new HistoryListItem();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Histories
                        .Single((b => b.Id == historyId));

                result.Id = query.Id;
                result.EventName = query.EventName;
                result.EventDate = query.EventDate;
                result.Description = query.Description;
                result.GameId = query.GameId;

                return result;
            }
        }
        public bool UpdateHistory(HistoryListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Histories
                        .SingleOrDefault(e => e.Id == model.Id);

                if (query != null)
                {
                    query.EventDate = model.EventDate;
                    query.EventName = model.EventName;
                    query.Description = model.Description;
                    query.GameId = model.GameId;

                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteHistory(int historyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Histories
                        .SingleOrDefault(e => e.Id == historyId);

                if (query != null)
                {
                    ctx.Histories.Remove(query);
                    return ctx.SaveChanges() == 1;
                }
                else
                    return false;
            }
        }
    }
}
