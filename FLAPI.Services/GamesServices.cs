using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class GamesServices
    {
        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    GameName = model.GameName,
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameListItem> GetGame()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Select(
                        e =>
                        new GameListItem
                        {
                            Id = e.Id,
                            Description = e.Description,
                            GameName = e.GameName,
                            ReleaseDate = e.ReleaseDate
                        }
                        );
                return query.ToArray();

            }
        }
        public GameListItem GetGameById(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.Id == gameId);
                return
                    new GameListItem
                    {

                        Id = entity.Id,
                        Description = entity.Description,
                        GameName = entity.GameName,
                        ReleaseDate = entity.ReleaseDate
                    };
            }
        }
        public bool UpdateGame(GameListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.Id == model.Id);
                entity.GameName = model.GameName;
                entity.Description = model.Description;
                entity.ReleaseDate = model.ReleaseDate;

                return ctx.SaveChanges() == 1;
                
            }
        }
        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.Id == gameId);

                ctx.Games.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
