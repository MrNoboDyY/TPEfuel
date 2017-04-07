using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace GestionTPE.Managers
{
    public class AppConfigManager
    {
        /// <summary>
        /// Récupère le premier endpoint de la liste des WS du Appconfig
        /// </summary>
        /// <returns>Url du WS</returns>
        public string GetEndPoint()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            ServiceModelSectionGroup serviceModelSectionGroup = ServiceModelSectionGroup.GetSectionGroup(configuration);
            ClientSection clientSection = serviceModelSectionGroup.Client;
            return clientSection.Endpoints[0].Address.AbsoluteUri;
        }
    }
}