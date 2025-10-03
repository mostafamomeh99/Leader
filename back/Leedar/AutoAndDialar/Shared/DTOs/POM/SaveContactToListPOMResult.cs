using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.POM
{
    public class SaveContactToListPOMResult
    {
        public bool IsSuccess { get; set; }
        public string? Result { get; set; }


        public string? CallId { get; set; }
        public string? CampaginId { get; set; }
        public string? ProductId { get; set; }
        public string? ContactId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ListName { get; set; }
        public int Priority { get; set; }
        public string? AgentID { get; set; }
    }
}
