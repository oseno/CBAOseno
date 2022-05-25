using CBAOseno.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBAOseno.Data.Interfaces
{
    public interface IConfigDao
    {
        //Configuration
        Configuration Save(Configuration item);
        Configuration RetrieveById(int id);
        Configuration Delete(long id);
        Configuration UpdateConfiguration(Configuration userChanges);
        IEnumerable<Configuration> GetAllConfigurations();
    }
}
