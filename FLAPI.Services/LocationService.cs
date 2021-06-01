using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class LocationService
    {

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    Country = model.Country,
                    MetroArea = model.MetroArea,
                    Name = model.Name,
                    HistoryId=model.HistoryId,
                    GameId=model.GameId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Locations
                    .Select(
                        e =>
                        new LocationListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Country = e.Country,
                            MetroArea = e.MetroArea,
                            GameId = e.GameId,
                            HistoryId = e.HistoryId
                        }
                     );
                return query.ToArray();
            }

        }
        public LocationListItem GetLocationById(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.Id == locationId);
                return
                new LocationListItem
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Country = entity.Country,
                    MetroArea = entity.MetroArea,
                    GameId=entity.GameId,
                    HistoryId=entity.HistoryId
                };
            }
        }
        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.Id == locationId);
                ctx.Locations.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
        public bool UpdateLocation(LocationListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.Id == model.Id);
                entity.MetroArea = model.MetroArea;
                entity.Name = model.Name;
                entity.Country = model.Country;
                entity.HistoryId = model.HistoryId;
                entity.GameId = model.GameId;
                return ctx.SaveChanges() == 1;

            }
        }

        public object GetAllLocationsByCharacterId(int characterId)
        {
            throw new NotImplementedException();
        }

        public List<LocationListItem> GetLocationByGameId(int GameId)
        {
            List<LocationListItem> result = new List<LocationListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Where(e => e.GameId == GameId) 
                        .Select(
                            e => new LocationListItem
                            {
                                Id = e.Id,
                                Country = e.Country,
                                MetroArea = e.MetroArea,
                                Name = e.Name,
                                GameId=e.GameId,
                                HistoryId=e.HistoryId
                            }
                        );
                return query.ToList();
            }
        }
        public List<LocationListItem> GetLocationByHistoryId(int HistoryId)
        {
            List<LocationListItem> result = new List<LocationListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Where(e => e.HistoryId == HistoryId)
                        .Select(
                            e => new LocationListItem
                            {
                                Id = e.Id,
                                Country = e.Country,
                                MetroArea = e.MetroArea,
                                Name = e.Name,
                                GameId = e.GameId,
                                HistoryId = e.HistoryId
                            }
                        );
                return query.ToList();
            }
        }
        public bool AddCharacterToLocation(int characterId, int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundCharacter = ctx.Characters.Single(s=>s.CharacterId==characterId);
                var foundLocation = ctx.Locations.Single(s => s.Id == locationId);
                foundLocation.ListOfCharacters.Add(foundCharacter);
                return ctx.SaveChanges() == 1;


            }
        }
    }
}


