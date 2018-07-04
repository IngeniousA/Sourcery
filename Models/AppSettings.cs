using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SourceryWeb.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "<ADDRESS>{0}";
        public static string Name { get; set; } = "SourceryBot";
        public static string Key { get; set; } = "<KEY>";
    }
}
