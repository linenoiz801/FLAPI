using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class VaultService
    {
        public bool CreateVault(VaultCreate model)
        {
            var entity =
                new Vault()
                {
                    VaultName = model.VaultName,
                    VaultNumber = model.VaultNumber,
                    LocationId = model.LocationId,
                    GameId = model.GameId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vaults.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool AddCharacterToVault(int characterId, int vaultId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundCharacter = ctx.Characters.Single(c => c.CharacterId == characterId);
                var foundVault = ctx.Vaults.Single(v => v.Id == vaultId);
                foundVault.ListOfCharacters.Add(foundCharacter);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<VaultListItem> GetVaults()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Vaults
                    .Select(
                        e =>
                        new VaultListItem
                        {
                            VaultId=e.Id,
                            VaultName=e.VaultName,
                            VaultNumber=e.VaultNumber,
                            LocationId=e.LocationId,
                            GameId = e.GameId
                        }
                        );
                return query.ToArray();
            }
        }
        public VaultListItem GetVaultById(int vaultId)
        {
            VaultListItem result = new VaultListItem();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Vaults
                    .Single(b => b.Id == vaultId);
                result.VaultId = query.Id;
                result.VaultName = query.VaultName;
                result.VaultNumber = query.VaultNumber;
                result.LocationId = query.LocationId;
                result.GameId = query.GameId;
                return result;
            }
        }
        public IEnumerable<VaultListItem> GetAllVaultsByCharacterId(int characterId)
        {
            List<VaultListItem> result = new List<VaultListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Characters
                    .Single(e => e.CharacterId == characterId);

                foreach (Vault v in query.ListOfVaults)
                {
                    VaultListItem e = new VaultListItem();
                    e.VaultId = v.Id;
                    e.GameId = v.GameId;
                    e.LocationId = v.LocationId;
                    e.VaultName = v.VaultName;
                    e.VaultNumber = v.VaultNumber;                    

                    result.Add(e);
                }
                return result;
            }
        }
        public List<VaultListItem> GetVaultsByGameId(int gameId)
        {
            List<VaultListItem> result = new List<VaultListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Vaults
                    .Where(e => e.GameId == gameId)
                    .Select(
                        e => new VaultListItem
                        {
                            VaultId = e.Id,
                            VaultName = e.VaultName,
                            VaultNumber = e.VaultNumber,
                            LocationId = e.LocationId,
                            GameId = e.GameId
                        }
                        );
                return query.ToList();
            }
        }
        public bool UpdateVault(VaultListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vaults
                        .SingleOrDefault(e => e.Id == model.VaultId);

                if (query != null)
                {
                    query.VaultName = model.VaultName;
                    query.VaultNumber = model.VaultNumber;
                    query.LocationId = model.LocationId;
                    query.GameId = model.GameId;
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteVaults(int vaultId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Vaults
                        .SingleOrDefault(e => e.Id == vaultId);

                if (query != null)
                {
                    ctx.Vaults.Remove(query);
                    return ctx.SaveChanges() == 1;
                }
                else 
                    return false;
            }
        }

    }
}

