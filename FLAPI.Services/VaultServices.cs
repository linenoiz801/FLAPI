using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class VaultServices
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
        public List<VaultListItem> GetVaultsByGameId(int GameId)
        {
            List<VaultListItem> result = new List<VaultListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Vaults
                    //.Where(e => e.GameId == gameId) //TODO: Can't do this part until the foreign keys are added
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
    }
}

