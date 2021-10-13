using DbProject.DatabaseComponents.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbProject.DatabaseComponents
{
    public class DatabaseRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> table;

        public DatabaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task<List<T>> GetElements()
        {
            if (await table.AnyAsync())
            {
                return await table.ToListAsync();
            }
            else
                throw new Exception("The database is empty");
        }

        public async Task<T> GetElement(int id)
        {
            var element = await table.FirstOrDefaultAsync(e => e.Id == id);
            if (element != null)
            {
                return element;
            }
            else
                throw new ArgumentException("An element with this id dosen't exist in database");
        }

        public async Task PostElement(T element)
        {
            await table.AddAsync(element);
            await context.SaveChangesAsync();
        }

        public async Task DeleteElement(int i)
        {
            var element = await table.FindAsync(i);
            table.Remove(element);
            await context.SaveChangesAsync();
        }
        public async Task DeleteElement(T element)
        {
            table.Remove(element);
            await context.SaveChangesAsync();
        }
    }
}
