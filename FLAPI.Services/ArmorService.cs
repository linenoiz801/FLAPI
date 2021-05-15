using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class ArmorService
    {
        public bool CreateArmor(ArmorCreate model)
        {
            var entity =
                new Armor()
                {
                    Name = model.Name,
                    Prereq = model.Prereq,
                    Description = model.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Armors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public List<ArmorListItem> GetArmorsByGameId(int GameId)
        {
            List<ArmorListItem> result = new List<ArmorListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Armors
                        //.Where(e => e.GameId == gameId) //TODO: Cant do this part until the foreign keys are added
                        .Select(
                            e => new ArmorListItem
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Prereq = e.Prereq,
                                Description = e.Description
                            }
                        );
                return query.ToList();
            }
        }
        public IEnumerable<ArmorListItem> GetArmors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Armors
                        .Select(
                            e =>
                                new ArmorListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    Prereq = e.Prereq,
                                    Description = e.Description
                                }
                        );
                return query.ToArray();
            }
        }
        public ArmorListItem GetArmorById(int armorId)
        {
            ArmorListItem result = new ArmorListItem();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Armors
                        .Single((b => b.Id == armorId));

                result.Id = query.Id;
                result.Name = query.Name;
                result.Prereq = query.Prereq;
                result.Description = query.Description;

                return result;
            }
        }
        public bool UpdateArmor(ArmorListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Armors
                        .SingleOrDefault(e => e.Id == model.Id);

                if (query != null)
                {
                    query.Name = model.Name;
                    query.Prereq = model.Prereq;
                    query.Description = model.Description;
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteArmor(int armorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Armors
                        .SingleOrDefault(e => e.Id == armorId);

                if (query != null)
                {
                    ctx.Armors.Remove(query);
                    return ctx.SaveChanges() == 1;
                }
                else
                    return false;
            }
        }
    }
}
