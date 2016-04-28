﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContextDemo.Inspector
{
    interface IClientCheck
    {
        Dictionary<string,string> Tokens { get; set; }
        string[] TokenKeys { get; set; }
        bool ClientIdentityCheck();
    }
}
