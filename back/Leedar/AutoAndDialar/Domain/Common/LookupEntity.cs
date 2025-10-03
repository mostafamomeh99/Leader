using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    [Serializable]
    public abstract class LookupEntity<T> : AuditableEntity<T>
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int ViewOrder { get; set; }
        public bool IsStatic { get; set; }

        [NotMapped]
        public string DisplayName { get; set; }
    }
}
