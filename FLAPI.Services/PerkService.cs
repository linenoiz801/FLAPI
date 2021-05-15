using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class PerkService
    {
        public bool CreatePerk(PerkCreate model)
        {
            var entity =
                new Perk()
                {
                    Name = model.Name,
                    Prereq = model.Prereq
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Perks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public List<PerkListItem> GetPerksByGameId(int GameId)
        {
            List<PerkListItem> result = new List<PerkListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Perks
                        //.Where(e => e.GameId == gameId) //TODO: Cant do this part until the foreign keys are added
                        .Select(
                            e => new PerkListItem
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Prereq = e.Prereq
                            }
                        );
                return query.ToList();
            }
        }
        public IEnumerable<PerkListItem> GetPerks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Perks
                        .Select(
                            e =>
                                new PerkListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    Prereq = e.Prereq
                                }
                        );
                return query.ToArray();
            }
        }
        public PerkListItem GetPerkById(int perkId)
        {
            PerkListItem result = new PerkListItem();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Perks
                        .Single((b => b.Id == perkId));

                result.Id = query.Id;
                result.Name = query.Name;
                result.Prereq = query.Prereq;

                return result;
            }
        }
        public bool UpdatePerk(PerkListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Perks
                        .SingleOrDefault(e => e.Id == model.Id);

                if (query != null)
                {
                    query.Name = model.Name;
                    query.Prereq = model.Prereq;
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeletePerk(int perkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Perks
                        .SingleOrDefault(e => e.Id == perkId);

                if (query != null)
                {
                    ctx.Perks.Remove(query);
                    return ctx.SaveChanges() == 1;
                }
                else
                    return false;
            }
        }
    }
}
