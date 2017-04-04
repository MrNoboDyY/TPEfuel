using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Managers
{
    internal class ManageRegEx : RegularExpressionAttribute
    {
        public ManageRegEx(string patternConfigKey)
            : base(ConfigurationManager.AppSettings[patternConfigKey])
        { }
    }
}