using FLAPI.Data;
using FLAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAPI.Services
{
    public class CharacterService
    {
        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    CharacterName = model.CharacterName,
                    Age = model.Age,
                    Affiliation = model.Affiliation,
                    IsNPC = model.IsNPC,
                    IsHostile = model.IsHostile,
                    SpeciesId = model.SpeciesId,
                    GameId = model.GameId,
                    HistoryId = model.HistoryId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool AddVaultToCharacter(int vaultId, int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundVault = ctx.Vaults.Single(v => v.Id == vaultId);
                var foundCharacter = ctx.Characters.Single(c => c.CharacterId == characterId);
                foundCharacter.ListOfVaults.Add(foundVault);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Select(
                            e =>
                            new CharacterListItem
                            {
                                CharacterId = e.CharacterId,
                                CharacterName = e.CharacterName,
                                Age = e.Age,
                                Affiliation = e.Affiliation,
                                IsNPC = e.IsNPC,
                                IsHostile = e.IsHostile,
                                SpeciesId = e.SpeciesId,
                                GameId = e.GameId,
                                HistoryId = e.HistoryId
                            }
                            );
                return query.ToArray();
            }
        }
        public CharacterListItem GetCharacterById(int characterId)
        {
            CharacterListItem result = new CharacterListItem();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Single(b => b.CharacterId == characterId);
                result.CharacterId = query.CharacterId;
                result.CharacterName = query.CharacterName;
                result.Age = query.Age;
                result.Affiliation = query.Affiliation;
                result.IsNPC = query.IsNPC;
                result.IsHostile = query.IsHostile;
                result.SpeciesId = query.SpeciesId;
                result.GameId = query.GameId;
                result.HistoryId = query.HistoryId;

                return result;
            }
        }
        public IEnumerable<CharacterListItem> GetAllCharactersByVaultId(int vaultId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
                    ctx.Vaults.Single(c => c.Id == vaultId).ListOfCharacters
                    .Select(e => new CharacterListItem
                    {
                        CharacterId = e.CharacterId
                    }
                    );
                return foundItems.ToArray();
            }
        }public IEnumerable<CharacterListItem> GetAllCharactersByLocationId(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
                    ctx.Locations.Single(c => c.Id == locationId).ListOfCharacters
                    .Select(e => new CharacterListItem
                    {
                        CharacterId = e.CharacterId
                    }
                    );
                return foundItems.ToArray();
            }
        }
        public List<CharacterListItem> GetCharacterByGameId(int gameId)
        {
            List<CharacterListItem> result = new List<CharacterListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(e => e.GameId == gameId)
                        .Select(
                        e => new CharacterListItem
                        {
                            CharacterId = e.CharacterId,
                            CharacterName = e.CharacterName,
                            Age = e.Age,
                            Affiliation = e.Affiliation,
                            IsNPC = e.IsNPC,
                            IsHostile = e.IsHostile,
                            SpeciesId = e.SpeciesId,
                            GameId = e.GameId,
                            HistoryId = e.HistoryId
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
                    query.SpeciesId = model.SpeciesId;
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
        public bool DeleteCharacter(int characterId)
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
        public bool AddLocationToCharacter(int locationId, int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundLocation = ctx.Locations.Single(s => s.Id == locationId);
                var foundCharacter = ctx.Characters.Single(s => s.CharacterId == characterId);
                foundCharacter.ListOfLocations.Add(foundLocation);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
