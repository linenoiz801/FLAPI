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
                    VaultNumber = model.VaultNumber
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vaults.Add(entity);
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
                            VaultNumber=e.VaultNumber
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

                return result;
            }
        }
        public IEnumerable<VaultListItem> GetAllVaultsByCharacterId(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
                    ctx.Characters.Single(c => c.CharacterId == characterId).ListOfVaults
                    .Select(e => new VaultListItem
                    {
                        VaultId = e.Id
                    }
                    );
                return foundItems.ToArray();
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
                    .Where(e => e.Id == gameId) //TODO: Can't do this part until the foreign keys are added
                    .Select(
                        e => new VaultListItem
                        {
                            VaultId = e.Id,
                            VaultName = e.VaultName,
                            VaultNumber = e.VaultNumber
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

