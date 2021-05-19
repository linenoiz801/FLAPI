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
    }
}
