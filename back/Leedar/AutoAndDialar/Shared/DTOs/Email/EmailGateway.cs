﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Email
{
    public class EmailGateway
    {
        public string Mail { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}
