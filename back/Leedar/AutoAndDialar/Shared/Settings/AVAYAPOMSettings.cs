using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Settings
{
    public class AVAYAPOMSettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AgentAPIServiceURL { get; set; }
        public string CmpMgmtServiceURL { get; set; }
        public string POM_ODBCDSN { get; set; }
        public string AURA_ODBCDSN { get; set; }
    }
}
