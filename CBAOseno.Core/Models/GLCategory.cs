using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBAOseno.Core.Enums;

namespace CBAOseno.Core.Models
{
    public class GLCategory
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
		
		public string CategoryDescription  { get; set; }
		
		public long CategoryCode { get; set; }

        public Status Status { get; set; }
		
		public Categories Categories { get; set; }

        //public ICollection<GLAccount> GLAccount { get; set; }
    }
}
