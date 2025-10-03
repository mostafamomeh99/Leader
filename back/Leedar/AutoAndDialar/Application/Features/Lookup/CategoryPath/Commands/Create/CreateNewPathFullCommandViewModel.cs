using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lookup.CategoryPath.Commands.Create
{
    public class CreateNewPathFullCommandViewModel
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        //public Guid? AVAYAAURACampaignPredictiveId { get; set; }

        public Guid? CallStatusFieldId { get; set; }
        public Guid? NoteId { get; set; }
        public Guid? SubNoteId { get; set; }
        public Guid? OtherNoteId { get; set; }
        public Guid? CallBillNumberId { get; set; }
        public Guid? VisitCenterTime { get; set; }
        public Guid? VisitCenter { get; set; }
        public Guid? NHCProject { get; set; }
        public Guid? NHCSuburb { get; set; }

        public List<GroupFieldViewModel> PathGroups { get; set; }
        public List<PathEventGroupViewModel> EventGroups { get; set; }

    }
}
