using CBAOseno.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CBAOseno.Core.Models;
using CBAOseno.Core.Enums;
using System.Text;
using System.Threading.Tasks;

namespace CBAOseno.Data.Implementations
{
    public class ConfigDao : IConfigDao
    {
        private readonly ApplicationDbContext db;
        public ConfigDao(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Configuration Delete(long id)
        {
            Configuration Configuration = db.Configuration.Find(id);
            if (Configuration != null)
            {
                db.Configuration.Remove(Configuration);
                db.SaveChanges();
            }
            return Configuration;
        }

        public Configuration RetrieveById(int id)
        {
            Configuration Configuration = db.Configuration.Find(id);
            return Configuration;
        }

        public Configuration Save(Configuration Configuration)
        {
            db.Configuration.Add(Configuration);
            db.SaveChanges();
            return Configuration;
        }

      

        public Configuration UpdateConfiguration(Configuration ConfigurationsChanges)
        {
            var Configuration = db.Configuration.Attach(ConfigurationsChanges);
            Configuration.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return ConfigurationsChanges;
        }

        public IEnumerable<Configuration> GetAllConfigurations()
        {
            var Configurations = db.Configuration.ToList();
            return Configurations;
        }
		
		
    }
}
