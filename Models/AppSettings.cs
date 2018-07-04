using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SourceryWeb.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://sourceryweb.azurewebsites.net:443/{0}";
        public static string Name { get; set; } = "SourceryBot";
        public static string Key { get; set; } = "575657984:AAEysWHYdr-obTLTsLA3jjJ8dYR2Kuf-gmA";
    }
}