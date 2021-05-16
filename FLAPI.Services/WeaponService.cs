using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class WeaponService
    {
        public bool CreateWeapon(WeaponCreate model)
        {
            var entity =
                new Weapon()
                {
                    WeaponName = model.WeaponName,
                    WeaponType = model.WeaponType,
                    AmmoType = model.AmmoType,
                    BaseDamage = model.BaseDamage,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Weapons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<WeaponListItem> GetWeapons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Weapons
                        .Select(
                            e =>
                            new WeaponListItem
                            {
                                WeaponId = e.WeaponId,
                                WeaponName = e.WeaponName,
                                WeaponType = e.WeaponType,
                                AmmoType = e.AmmoType,
                                BaseDamage = e.BaseDamage,
                                Description = e.Description
                            }
                            );
                return query.ToArray();
            }
        }
        public WeaponListItem GetWeaponById(int weaponId)
        {
            WeaponListItem result = new WeaponListItem();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Weapons
                        .Single(b => b.WeaponId == weaponId);
                result.WeaponId = query.WeaponId;
                result.WeaponName = query.WeaponName;
                result.WeaponType = query.WeaponType;
                result.AmmoType = query.AmmoType;
                result.BaseDamage = query.BaseDamage;
                result.Description = query.Description;

                return result;
            }
        }
        public List<CharacterListItem> GetCharacterByGameId(int GameId)
        {
            List<CharacterListItem> result = new List<CharacterListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        //.Where(e => e.GameId == gameId) //TODO: Cant do this part until the foreign keys are added
                        .Select(
                        e => new CharacterListItem
                        {
                            CharacterId = e.CharacterId,
                            CharacterName = e.CharacterName,
                            Age = e.Age,
                            Affiliation = e.Affiliation,
                            IsNPC = e.IsNPC,
                            IsHostile = e.IsHostile
                        }
                    );
                return query.ToList();
            }
        }
        public bool UpdateCharacter(CharacterListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .SingleOrDefault(e => e.CharacterId == model.CharacterId);

                if (query != null)
                {
                    query.CharacterName = model.CharacterName;
                    query.Age = model.Age;
                    query.Affiliation = model.Affiliation;
                    query.IsNPC = model.IsNPC;
                    query.IsHostile = model.IsHostile;
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteHistory(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .SingleOrDefault(e => e.CharacterId == characterId);

                if (query != null)
                {
                    ctx.Characters.Remove(query);
                    return ctx.SaveChanges() == 1;
                }
                else
                    return false;
            }
        }
    }
}
