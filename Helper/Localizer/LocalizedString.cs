using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace livestockProject
{
    public class LocalizedString
    {
        public string Key { get; set; }

        public Dictionary<string, string> Values = new Dictionary<string, string>();
    }
}