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
        public CharacterService()
        {
        }
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
    }
}
