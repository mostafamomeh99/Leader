using Domain.Common;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookup
{
    public class CategoryPath : LookupEntity<Guid>
    {
        public virtual  ICollection<Category> Categorys { get; set; }
    }
}
