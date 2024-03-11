using Microsoft.EntityFrameworkCore;
using Persistencia.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Context
{
    public class SqlContext : ProjectManagerContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
       
    }
}
