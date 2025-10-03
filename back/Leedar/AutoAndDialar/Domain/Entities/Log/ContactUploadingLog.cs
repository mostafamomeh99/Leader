using Domain.Common;
using Domain.Entities.Application;
using Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Log
{
    public class ContactUploadingLog : AuditableEntity<Guid>
    {
        public Guid? ContactId { get; set; }
        public virtual Contact? Contact { get; set; }

        public Guid? CampaignId { get; set; }
        public virtual Campaign? Campaign { get; set; }

        public Guid? CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public Guid? PriorityId { get; set; }
        public virtual Priority? Priority { get; set; }
        public Guid? SystemProgressId { get; set; }
        public virtual SystemProgress? SystemProgress { get; set; }

        public bool IsUploadedSuccessfully { get; set; }
        public int FileRow { get; set; }
        public string? FileName { get; set; }
        public string? Description { get; set; }
        public string? DescriptionOthers { get; set; }
    }
}
