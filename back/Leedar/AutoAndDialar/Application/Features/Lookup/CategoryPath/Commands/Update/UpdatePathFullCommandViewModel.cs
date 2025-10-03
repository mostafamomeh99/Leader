using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lookup.CategoryPath.Commands.Update
{
    public class UpdatePathFullCommandViewModel
    {
        public Guid Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public Guid? CallStatusFieldId { get; set; }
        public Guid? NoteId { get; set; }
        public Guid? SubNoteId { get; set; }
        public Guid? OtherNoteId { get; set; }
       

        public List<GroupFieldViewModel> PathGroups { get; set; }
        public List<PathEventGroupViewModel> EventsGroup { get; set; }
        public Dictionary<Guid, string> Result { get; set; }

    }
}
