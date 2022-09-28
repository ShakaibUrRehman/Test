using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shakaib_UR_Rehman.Models
{
    public class dataClass
    {
        [Key]
        public int ID { get; set; }
        public string empl_name { get; set; }
        public string city { get; set; }

        internal object GetAllEmployess()
        {
            throw new NotImplementedException();
        }

        internal void savechanges()
        {
            throw new NotImplementedException();
        }
    }
}
