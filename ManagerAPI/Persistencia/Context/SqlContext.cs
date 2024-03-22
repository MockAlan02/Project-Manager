using Microsoft.EntityFrameworkCore;

namespace Persistencia.Context
{
    public class SqlContext : ProjectManagerContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
       
    }
}
