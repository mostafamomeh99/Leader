using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class DynamicReport : LookupEntity<Guid>
    {
        public Guid? EntityId { get; set; }
        public virtual required Entity? Entity { get; set; }

        public virtual ICollection<DynamicReportField>? DynamicReportFields { get; set; }


    }
}
