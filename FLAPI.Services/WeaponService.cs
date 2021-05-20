﻿using FLAPI.Data;
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
                    Description = model.Description,
                    GameId = model.GameId,
                    HistoryId = model.HistoryId
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
                                Description = e.Description,
                                GameId = e.GameId,
                                HistoryId = e.HistoryId
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
                result.GameId = query.GameId;
                result.HistoryId = query.HistoryId;

                return result;
            }
        }
        public List<WeaponListItem> GetWeaponByGameId(int gameId)
        {
            List<WeaponListItem> result = new List<WeaponListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Weapons
                        //.Where(e => e.GameId == gameId) //TODO: Cant do this part until the foreign keys are added
                        .Select(
                        e => new WeaponListItem
                        {
                            WeaponId = e.WeaponId,
                            WeaponName = e.WeaponName,
                            WeaponType = e.WeaponType,
                            AmmoType = e.AmmoType,
                            BaseDamage = e.BaseDamage,
                            Description = e.Description,
                            GameId = e.GameId,
                            HistoryId = e.HistoryId
                        }
                    );
                return query.ToList();
            }
        }
        public bool UpdateWeapon(WeaponListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Weapons
                        .SingleOrDefault(e => e.WeaponId == model.WeaponId);

                if (query != null)
                {
                    query.WeaponName = model.WeaponName;
                    query.WeaponType = model.WeaponType;
                    query.AmmoType = model.AmmoType;
                    query.BaseDamage = model.BaseDamage;
                    query.Description = model.Description;
                    query.GameId = model.GameId;
                    query.HistoryId = model.HistoryId;
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteWeapon(int weaponId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Weapons
                        .SingleOrDefault(e => e.WeaponId == weaponId);

                if (query != null)
                {
                    ctx.Weapons.Remove(query);
                    return ctx.SaveChanges() == 1;
                }
                else
                    return false;
            }
        }
    }
}
