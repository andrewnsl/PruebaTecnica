using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.DataAccess.Repository
{
    public interface IDataRepository<TEntity> where TEntity : class, new()
    {
        DbContext _context { get; set; }
        public DbSet<TEntity> _entity { get; set; }       
        /// <summary>
        /// Obtiene una lista de registros por una expresion
        /// </summary>
        /// <param name="expresion"></param>
        /// <returns></returns>
        public Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? expresion = null);
        /// <summary>
        /// Obtiene una lista de registros por una expresion con includes
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ListInclude(List<string> properties, Expression<Func<TEntity, bool>>? expression = null);        
    }
}
