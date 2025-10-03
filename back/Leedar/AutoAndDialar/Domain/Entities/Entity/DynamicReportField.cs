using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Entity
{
    public class DynamicReportField
    {
        public Guid Id { get; set; }
        public Guid DynamicReportId { get; set; }
        public virtual required DynamicReport DynamicReport { get; set; }
        public Guid EntityMapId { get; set; }
        public virtual required EntityMap  EntityMap { get; set; }
    }
}
