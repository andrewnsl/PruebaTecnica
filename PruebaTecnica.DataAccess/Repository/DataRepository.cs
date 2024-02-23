using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DataAccess.Repository
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class, new()
    {
        public DbContext _context { get; set; }

        public DbSet<TEntity> _entity { get; set; }

        public DataRepository(DbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }      
        
        public async Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? expresion = null)
        {
            return (expresion != null) ? (await _entity.Where(expresion).ToListAsync()) : (await _entity.ToListAsync());
        }

        public async Task<List<TEntity>> ListInclude(List<string> properties, Expression<Func<TEntity, bool>>? expression = null)
        {
            if (properties.Count == 0)
            {
                return await List(expression);
            }

            IQueryable<TEntity> source = _entity.Includes(properties);
            return (expression != null) ? (await source.Where(expression).ToListAsync()) : (await source.ToListAsync());
        }     

    }
}
