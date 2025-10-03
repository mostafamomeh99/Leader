namespace Domain.Entities.Application
{
    using Domain.Common;
    using Domain.Entities.Lookup;
    using Domain.Entities.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SystemProgress : AuditableEntity<Guid>
    {

        public Guid? EntityId { get; set; }
        public virtual Entity? Entity { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public int Max { get; set; }
        public int Currant { get; set; }
        public string? FilePath { get; set; }
        public string? Type { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? CampaignId { get; set; }
        public Guid? CallTypeId { get; set; }
        public Guid? PriorityId { get; set; }

    }
}
