using FLAPI.Models;
using FLAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class SpeciesService
    {
        public bool CreateSpecies(SpeciesCreate model)
        {
            var entity =
                new Species()
                {
                    SpeciesName = model.SpeciesName,
                    Strength = model.Strength,
                    Weakness = model.Weakness,
                    HistoryId = model.HistoryId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Species.Add(entity);
                return ctx.SaveChanges() ==1;
            }
        }
        public IEnumerable<SpeciesListItem> GetSpecies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Species
                    .Select(
                        e =>
                        new SpeciesListItem
                        {
                            Id = e.Id,
                            Weakness = e.Weakness,
                            SpeciesName = e.SpeciesName,
                            Strength = e.Strength,
                            HistoryId = e.HistoryId
                        }
                        );
                return query.ToArray();
            }
        }
        public SpeciesListItem GetSpeciesById(int speciesId)
        {
            SpeciesListItem result = new SpeciesListItem();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Species
                    .Single(b => b.Id == speciesId);
                result.Id = query.Id;
                result.SpeciesName = query.SpeciesName;
                result.Weakness = query.Weakness;
                result.Strength = query.Strength;
                result.HistoryId = query.HistoryId;
                

                return result;
            }
        }
        /*public List<SpeciesListItem> GetSpeciesByGameId(int gameId)
        {
            List<SpeciesListItem> result = new List<SpeciesListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Species
                    //.Where(e => e.GameId == gameId) 
                    .Select(
                        e => new SpeciesListItem
                        {
                            Id = e.Id,
                            HistoryId = e.HistoryId,
                            SpeciesName = e.SpeciesName,
                            Strength = e.Strength,
                            Weakness = e.Weakness
                        }
                        );
                return query.ToList();
            }
        }*/
        public bool UpdateSpecies(SpeciesListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Species
                    .SingleOrDefault(e => e.Id == model.Id);

                if (query != null)
                {
                    query.SpeciesName = model.SpeciesName;
                    query.Strength = model.Strength;
                    query.Weakness = model.Weakness;
                    query.HistoryId = model.HistoryId;
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteSpecies(int speciesId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Species
                    .SingleOrDefault(e => e.Id == speciesId);

                if (query != null)
                {
                    ctx.Species.Remove(query);
                    return ctx.SaveChanges() == 1;
                }
                else
                    return false;
            }
        }
        public bool AddGameToSpecies(int speciesId, int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundSpecies = ctx.Species.Single(s => s.Id == speciesId);
                var foundGame = ctx.Games.Single(g => g.Id == gameId);
                foundSpecies.ListOfGames.Add(foundGame);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
