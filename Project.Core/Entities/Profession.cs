using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities
{
    public class Profession : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }

    }
}
