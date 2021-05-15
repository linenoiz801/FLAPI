using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    class LocationService
    {

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    Country=model.Country,
                    MetroArea=model.MetroArea,
                    Name=model.Name
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
                            Name = e.Name,
                            Country = e.Country,
                            MetroArea = e.MetroArea
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
                        Id=entity.Id,
                        Name=entity.Name,
                        Country=entity.Country,
                        MetroArea=entity.MetroArea
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
                    .Single(e => e.Id==model.Id);
                entity.MetroArea = model.MetroArea;
                entity.Name = model.Name;
                entity.Country = model.Country;
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
