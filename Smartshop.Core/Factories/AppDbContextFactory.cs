using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Smartshop.Core.Data;
using Smartshop.Core.Models;
using Smartshop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartshop.Core.Factories
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private readonly AppDataProviderService? _dataProvider;
        public AppDbContext CreateDbContext(string[]? args = null)
        {
            var conStr = _dataProvider!.GetConnectionString();
            if (conStr.IsOk)
            {
                var options = new DbContextOptionsBuilder<AppDbContext>();
                options.UseNpgsql(conStr.Value);
                return new AppDbContext(options.Options);
            }
            else
            {
                return null;
            }
            
        }
    }
}
