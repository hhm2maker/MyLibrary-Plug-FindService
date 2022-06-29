using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindServicePlugin
{
    public class StyleFindPluginModel
    {
        public List<StyleFindPluginChildModel> Child { get; set; } = new List<StyleFindPluginChildModel>();

        public class StyleFindPluginChildModel
        {
            public string Name { get; set; } = "";

            public List<string> Tag { get; set; } = new List<string>();

            public string Cover { get; set; } = "";

            public string Link { get; set; } = "";

            public string Describe { get; set; } = "";
        }
    }
}
