using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskTry5.DAL.Entities
{
    public class AccessMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
