using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public abstract class AuditableEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? LastModifiedByUserId { get; set; }
        public byte StateCode { get; set; }
        [ForeignKey("CreatedByUserId")]
        [NotMapped]
        public virtual User CreatedByUser { get; set; }
        [ForeignKey("LastModifiedByUserId")]
        [NotMapped]
        public virtual User LastModifiedByUser { get; set; }
    }
    public abstract class AuditableEntityNoID
    {
        public DateTime CreatedOn { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? LastModifiedByUserId { get; set; }
        public byte StateCode { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual User CreatedByUser { get; set; }
        [ForeignKey("LastModifiedByUserId")]
        public virtual User LastModifiedByUser { get; set; }
    }
}
