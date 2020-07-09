using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvCast.Entity.Entities;

namespace TvCast.Entity.Repositories.Impl
{
    public class CastRepository : ICastRepository
    {
        protected TvCastDbContext DbContext { get; set; }

        public CastRepository(TvCastDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> SaveRangeAsync(IEnumerable<Casting> entities)
        {
            var enumerable = entities.ToList();
            foreach (var c in enumerable)
            {
                var show = DbContext.Shows.Local.FirstOrDefault(p => p.Id == c.Show.Id) ?? DbContext.Shows.FirstOrDefault(p => p.Id == c.Show.Id);
                var person =DbContext.Persons.Local.FirstOrDefault(p => p.Id == c.Person.Id) ?? DbContext.Persons.FirstOrDefault(p => p.Id == c.Person.Id);
                var character = DbContext.Characters.Local.FirstOrDefault(p => p.Id == c.Character.Id) ?? DbContext.Characters.FirstOrDefault(p => p.Id == c.Character.Id);
                if (show != null)
                    c.Show = show;
                if (person != null)
                    c.Person = person;
                if (character != null)
                    c.Character = character;
               
                await DbContext.Castings.AddAsync(c);
            }
            
            return await DbContext.SaveChangesAsync();
        }

        public async Task<long?> FindLastInsertedShowAsync()
        {
            return await DbContext.Castings.MaxAsync(p => p.Show.Id);
        }
    }
}