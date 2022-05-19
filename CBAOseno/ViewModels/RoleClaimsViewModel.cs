using System.Collections.Generic;

namespace CBAOseno.WebApi.ViewModels
{
    public class RoleClaimsViewModel
    {
        public RoleClaimsViewModel()
        {
            Cliams = new List<RoleClaim>();
        }
        public string Id { get; set; }       
        public List<RoleClaim> Cliams { get; set; }
    }
}
