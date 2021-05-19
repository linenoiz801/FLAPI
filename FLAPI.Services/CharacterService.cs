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
                    IsHostile = model.IsHostile
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
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
                                IsHostile = e.IsHostile
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

    }
}
