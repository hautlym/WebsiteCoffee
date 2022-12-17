using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_DoAn.Data.EF
{
    public class BTL_DoAnDbContextFactory : IDesignTimeDbContextFactory<BTL_DoAnDbContext>
    {
        public BTL_DoAnDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("datasetting.json")
                .Build();
            var optionBuilder = new DbContextOptionsBuilder<BTL_DoAnDbContext>();
            var ConnectionString = configuration.GetConnectionString("BTL_DoAn_Database");
            optionBuilder.UseSqlServer(ConnectionString);
            return new BTL_DoAnDbContext(optionBuilder.Options);
        }
    }
}
