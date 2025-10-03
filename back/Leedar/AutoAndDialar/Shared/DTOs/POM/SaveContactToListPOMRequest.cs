using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.POM
{
    public class SaveContactToListPOMRequest
    {
        public string? CallId { get; set; }
        public string? CampaginId { get; set; }
        public string? ProductId { get; set; }
        public string? ContactId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ListName { get; set; }
        public int Priority { get; set; } = 10;
        public string AgentID { get; set; } = "";
    }
}
