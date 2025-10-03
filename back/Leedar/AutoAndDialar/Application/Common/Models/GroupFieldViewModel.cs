using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class GroupFieldViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ViewOrder { get; set; }

        public string Title { get; set; }
        public string Type { get; set; }
        public List<EntityFieldViewModel> GroupFields { get; set; }
    }
}
