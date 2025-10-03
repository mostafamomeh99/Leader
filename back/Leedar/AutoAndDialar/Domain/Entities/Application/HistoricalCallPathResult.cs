
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Entity;

namespace Domain.Entities.Application
{
    public class HistoricalCallPathResult
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HistoricalCallId { get; set; }
        public virtual  HistoricalCall? HistoricalCall { get; set; }
        public Guid EntityFieldId { get; set; }
        public virtual  EntityField? EntityField { get; set; }
        public string? Value { get; set; }
        public string? ValueString { get; set; }
    }
}
